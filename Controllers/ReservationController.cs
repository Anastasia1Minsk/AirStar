using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AirStar.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(IFlightService flightService, IReservationService reservationService, IMapper mapper)
        {
            _flightService = flightService;
            _reservationService = reservationService;
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

        /*public async Task<IActionResult> AjaxPassengerInformation(int flightId, int classId, int numberOfPassengers)
        {
            var chosenFlight = await _flightService.SelectOneAsync(
                predicate: flight => flight.Id == flightId,
                includes: (new List<string>() { "Aircraft", "Rates", "Route", "Route.DepartureAirport", "Route.ArrivalAirport" }),
                );
        }*/

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
                ReservationId = reservationId
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

            return RedirectToAction("PrintTicket", "Reservation");
        }

        [HttpGet]
        public async Task<IActionResult> PrintTicket()
        {
            return View();
        }
    }
}
