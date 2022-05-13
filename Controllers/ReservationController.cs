using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.Models.Enums;
using AirStar.ViewModels;
using AutoMapper;
using iText.Html2pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Razor.Templating.Core;

namespace AirStar.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IReservationService _reservationService;
        private readonly IRateService _rateService;
        private readonly IPriceService _priceService;
        private readonly IMapper _mapper;

        public ReservationController(IFlightService flightService, IReservationService reservationService, IRateService rateService,
            IPriceService priceService, IMapper mapper)
        {
            _flightService = flightService;
            _reservationService = reservationService;
            _rateService = rateService;
            _priceService = priceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> PassengerInformation(int flightId, int classId, int numberOfPassengers)
        {
            var chosenFlight = await SelectChosenFlight(flightId);

            var passengers = new List<Passenger>(numberOfPassengers);
            for (int i = 0; i < numberOfPassengers; i++)
            {
                passengers.Add(null);
            }
            
            var result = new PassengerInformationViewModel()
            {
                Flight = _mapper.Map<FlightViewModel>(chosenFlight),
                Reservation = new ReservationViewModel()
                {
                    NumberOfPassengers = numberOfPassengers,
                    ClassId = classId,
                    Passengers = passengers
                }
            };

            return View(result);
        }

        public async Task<JsonResult> JsonPassengerInformation(int flightId, int classId)
        {
            var rates = (await _rateService.GetRatesByFlightAsync(flightId)).ToList();
            rates = rates.Where(x =>
                x.RateType == RateTypes.Food || x.RateType == RateTypes.Luggage || x.Id == classId).ToList();

            return Json(rates);
        }
        
        [HttpPost]
        public async Task<IActionResult> PassengerInformation(PassengerInformationViewModel passengerInformationViewModel)
        {
            if (!ModelState.IsValid)
            {
                var flight = await SelectChosenFlight(passengerInformationViewModel.Flight.Id);
                passengerInformationViewModel.Flight = _mapper.Map<FlightViewModel>(flight);

                return View(passengerInformationViewModel);
            }

            var reservationId = await _reservationService.CreateReservation(passengerInformationViewModel);

            var routeValues = new RouteValueDictionary {
                { "reservationId", reservationId}
            };

            return RedirectToAction("Payment", "Reservation", routeValues);
        }

        private async Task<Flight> SelectChosenFlight(int flightId)
        {
           return await _flightService.SelectOneAsync(
                    predicate: flight => flight.Id == flightId,
                    includes: (new List<string>() { "Aircraft", "Rates", "Route", "Route.DepartureAirport", "Route.ArrivalAirport" }));
        }

        [HttpGet]
        public async Task<IActionResult> Payment(int reservationId)
        {
            var result = new PaymentViewModel()
            {
                ReservationId = reservationId,
                TotalCost = await _priceService.GetTotalByReservationAsync(reservationId)
            };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentViewModel paymentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(paymentViewModel);
            }

            var reservation = await _reservationService.GetByIdAsync(paymentViewModel.ReservationId);
            reservation.Paid = true;
            await _reservationService.UpdateAsync(reservation);

            var routeValues = new RouteValueDictionary {
                { "id", reservation.Id}
            };

            return RedirectToAction("PrintTicket", "Reservation", routeValues);
        }

        [HttpGet]
        public async Task<IActionResult> PrintTicket(int id)
        {
            var reservation = await _reservationService.SelectOneAsync(x => x.Id == id, new List<string>()
                {"Passengers", "Prices", "Flight", "Flight.Route", "Flight.Route.DepartureAirport", "Flight.Route.ArrivalAirport"});

            var html = await RazorTemplateEngine.RenderAsync("/Views/Reservation/PrintTicket.cshtml", reservation);

            using (var stream = new MemoryStream())
            {
                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(html, stream, converterProperties);

                return new FileContentResult(stream.ToArray(), "application/pdf");
            }
        }
    }
}
