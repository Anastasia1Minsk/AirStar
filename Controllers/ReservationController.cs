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

namespace AirStar.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public ReservationController(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> PassengerInformation(int flightId, int classId, int numberOfPassengers)
        {
            var chosenFlight = await _flightService.SelectOneAsync(
                predicate: flight => flight.Id == flightId,
                includes: (new List<string>() { "Aircraft", "Rates", "Route", "Route.DepartureAirport", "Route.ArrivalAirport" }));

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
                var flight = await _flightService.SelectOneAsync(
                    predicate: flight => flight.Id == passengerInformationViewModel.Flight.Id,
                    includes: (new List<string>() { "Aircraft", "Rates", "Route", "Route.DepartureAirport", "Route.ArrivalAirport" }));
                passengerInformationViewModel.Flight = _mapper.Map<FlightViewModel>(flight);

                return View(passengerInformationViewModel);
            }

            return RedirectToAction("Payment", "Reservation");
        }

        public async Task<IActionResult> Payment()
        {
            return View();
        }
    }
}
