using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
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
            flight.Rates = new List<RatesViewModel>();
            flight.Rates.AddRange(new List<RatesViewModel>{
                new RatesViewModel{RateType = RateTypes.AdultEconomyFlight},
                new RatesViewModel{ RateType = RateTypes.AdultBusinessFlight },
                new RatesViewModel{ RateType = RateTypes.AdultFirstFlight }});
            
            return View(flight);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AirportViewModel airportViewModel)
        {
            /*if (!ModelState.IsValid)
            {
                ViewBag.CountryNames = await ListOfCountries();
                return View(airportViewModel);
            }

            if (await _airportService.IsCodeExistsAsync(airportViewModel.Code_IATA))
            {
                ModelState.AddModelError("Code_IATA", "\"Code IATA\" isn't unique");
                ViewBag.CountryNames = await ListOfCountries();
                return View(airportViewModel);
            }

            var airport = _mapper.Map<Airport>(airportViewModel);
            await _airportService.InsertAsync(airport);*/

            return RedirectToAction("List", "Flight");
        }

        private async Task<SelectList> ListOfRoutes()
        {
            var routes = await _routeService.SelectWithAirportsAsync();
            var routesNames = new SelectList(routes.Select(x => new { x.Id, 
                    Name = $"{x.DepartureAirport.Code_IATA}|{x.DepartureAirport.City}|{x.DepartureAirport.Country.Name} to {x.ArrivalAirport.Code_IATA}|{x.ArrivalAirport.City}|{x.ArrivalAirport.Country.Name}" }),
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
            var flight = await _flightService.SelectOneFlightListAsync(id);
            var result = _mapper.Map<FlightViewModel>(flight);
            return View(result);
        }
    }
}
