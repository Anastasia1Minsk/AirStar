using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.Models.Enums;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirStar.Controllers
{
    [Authorize]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IRateService _rateService;
        private readonly IRouteService _routeService;
        private readonly IAircraftService _aircraftService;
        private readonly IMapper _mapper;

        public FlightController(IFlightService flightService, IRateService rateService, IRouteService routeService,
            IAircraftService aircraftService ,IMapper mapper)
        {
            _flightService = flightService;
            _rateService = rateService;
            _routeService = routeService;
            _aircraftService = aircraftService;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            var flights = await _flightService.SelectFlightsListAsync();
            var result = _mapper.Map<List<FlightViewModel>>(flights);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Routes = await ListOfRoutes();
            ViewBag.Aircrafts = await ListOfAircrafts();

            var flight = new FlightViewModel();
            flight.Rates = new List<RateViewModel>();
            flight.Rates.AddRange(new List<RateViewModel>{
                new RateViewModel{RateType = RateTypes.AdultEconomyFlight},
                new RateViewModel{RateType = RateTypes.AdultBusinessFlight},
                new RateViewModel{RateType = RateTypes.AdultFirstFlight},
                new RateViewModel{RateType = RateTypes.Luggage},
                new RateViewModel{RateType = RateTypes.Food}
            });
            
            return View(flight);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlightViewModel flightViewModel)
        {
            ViewBag.Routes = await ListOfRoutes();
            ViewBag.Aircrafts = await ListOfAircrafts();

            if (!ModelState.IsValid)
            {
                return View(flightViewModel);
            }

            if (flightViewModel.Luggage && flightViewModel.Rates[3].Price <= 0)
            {
                ModelState.AddModelError("Rates[3].Price", "Invalid rate");
            }

            if (flightViewModel.Food && flightViewModel.Rates[4].Price <= 0)
            {
                ModelState.AddModelError("Rates[4].Price", "Invalid rate");
            }

            var aircraft = await _aircraftService.SelectOneAsync(x => x.Id == flightViewModel.AircraftId);
            if (aircraft.EconomyClassSeats > 0 && flightViewModel.Rates[0].Price <= 0)
            {
                ModelState.AddModelError("Rates[0].Price", "Invalid rate");
            }

            if (aircraft.BusinessClassSeats > 0 && flightViewModel.Rates[1].Price <= 0)
            {
                ModelState.AddModelError("Rates[1].Price", "Invalid rate");
            }

            if (aircraft.FirstClassSeats > 0 && flightViewModel.Rates[2].Price <= 0)
            {
                ModelState.AddModelError("Rates[2].Price", "Invalid rate");
            }

            if (!ModelState.IsValid)
            {
                return View(flightViewModel);
            }


            flightViewModel.Rates.RemoveAll(x => x.Price == 0);
            var flight = _mapper.Map<Flight>(flightViewModel);
            await _flightService.InsertAsync(flight);
            
            return RedirectToAction("List", "Flight");
        }

        private async Task<SelectList> ListOfRoutes()
        {
            var routes = await _routeService.SelectWithAirportsAsync();
            var routesNames = new SelectList(routes.Select(x => new { x.Id, 
                    Name = $"{x.DepartureAirport.Code_IATA}|{x.DepartureAirport.City}|{x.DepartureAirport.Country.Name} => {x.ArrivalAirport.Code_IATA}|{x.ArrivalAirport.City}|{x.ArrivalAirport.Country.Name}" }),
                "Id", "Name");
            return routesNames;
        }

        private async Task<SelectList> ListOfAircrafts()
        {
            var aircrafts = await _aircraftService.SelectAsync();
            var aircraftsNames = new SelectList(aircrafts.Select(x => new {x.Id, Name = $"{x.Brand} {x.Model}"}),
                "Id", "Name");
            return aircraftsNames;
        }

        public async Task<JsonResult> JsonAircraftClasses()
        {
            return Json((await _aircraftService.SelectAsync()).ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var flight = await _flightService.SelectOneFlightAsync(id);
            var result = _mapper.Map<FlightViewModel>(flight);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Routes = await ListOfRoutes();
            ViewBag.Aircrafts = await ListOfAircrafts();

            var flight = await _flightService.SelectOneFlightAsync(id);
            var result = _mapper.Map<FlightViewModel>(flight);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FlightViewModel flightViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(flightViewModel);
            }

            if (flightViewModel.Luggage && flightViewModel.Rates[3].Price <= 0)
            {
                ModelState.AddModelError("Rates[3].Price", "Invalid rate");
            }

            if (flightViewModel.Food && flightViewModel.Rates[4].Price <= 0)
            {
                ModelState.AddModelError("Rates[4].Price", "Invalid rate");
            }

            var aircraft = await _aircraftService.SelectOneAsync(x => x.Id == flightViewModel.AircraftId);
            if (aircraft.EconomyClassSeats > 0 && flightViewModel.Rates[0].Price <= 0)
            {
                ModelState.AddModelError("Rates[0].Price", "Invalid rate");
            }

            if (aircraft.BusinessClassSeats > 0 && flightViewModel.Rates[1].Price <= 0)
            {
                ModelState.AddModelError("Rates[1].Price", "Invalid rate");
            }

            if (aircraft.FirstClassSeats > 0 && flightViewModel.Rates[2].Price <= 0)
            {
                ModelState.AddModelError("Rates[2].Price", "Invalid rate");
            }

            if (!ModelState.IsValid)
            {
                return View(flightViewModel);
            }


            /*await _routeService.UpdateAsync(route);*/

            return RedirectToAction("List", "Flight");
        }

        /*[HttpGet]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var route = await _routeService.SelectOneWithAirportsAsync(id);
            var result = _mapper.Map<RouteViewModel>(route);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _routeService.DeleteAsync(id);
            return RedirectToAction("List", "Route");
        }*/
    }
}
