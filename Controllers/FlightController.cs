﻿using Microsoft.AspNetCore.Mvc;
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

            var flight = _mapper.Map<Flight>(flightViewModel);
            if (await _flightService.IsFlightExistsAsync(flight))
            {
                ModelState.AddModelError("RouteId", "Such flight exists");
                return View(flightViewModel);
            }

            flight.Rates = DeleteNullableRatesAsync(flight.Rates);
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

        private ICollection<Rate> DeleteNullableRatesAsync(ICollection<Rate> rates)
        {
            var list = rates.ToList();
            list.RemoveAll(x => x.Price == 0);
            return list;
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
            if (result.Rates.Count < 5)
            {
                var tempRatesList = new List<RateViewModel>();
                tempRatesList.AddRange(new List<RateViewModel>{
                    new RateViewModel{RateType = RateTypes.AdultEconomyFlight},
                    new RateViewModel{RateType = RateTypes.AdultBusinessFlight},
                    new RateViewModel{RateType = RateTypes.AdultFirstFlight},
                    new RateViewModel{RateType = RateTypes.Luggage},
                    new RateViewModel{RateType = RateTypes.Food}
                });
                foreach (var rate in result.Rates)
                {
                    switch (rate.RateType)
                    {
                        case RateTypes.AdultEconomyFlight: 
                            tempRatesList[0].Price = rate.Price;
                            break;
                        case RateTypes.AdultBusinessFlight:
                            tempRatesList[1].Price = rate.Price;
                            break;
                        case RateTypes.AdultFirstFlight:
                            tempRatesList[2].Price = rate.Price;
                            break;
                        case RateTypes.Luggage:
                            tempRatesList[3].Price = rate.Price;
                            break;
                        case RateTypes.Food:
                            tempRatesList[4].Price = rate.Price;
                            break;
                    }

                    result.Rates = tempRatesList;
                }
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FlightViewModel flightViewModel)
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

            var flight = _mapper.Map<Flight>(flightViewModel);
            if (await _flightService.IsFlightUpdatesAsync(flight))
            {
                ModelState.AddModelError("RouteId", "Such flight exists");
                return View(flightViewModel);
            }

            flight.Rates = DeleteNullableRatesAsync(flight.Rates);
            var existingRates = await _rateService.SelectAsync(x => x.FlightID == flight.Id);
            await _rateService.DeleteAsync(existingRates);
            await _flightService.UpdateAsync(flight);

            return RedirectToAction("List", "Flight");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(int id, bool? impossibleToDelete = false)
        {
            if (impossibleToDelete.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. The flight has reservations";
            }
            
            var flight = await _flightService.SelectOneFlightAsync(id);
            var result = _mapper.Map<FlightViewModel>(flight);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> TryDelete(int id)
        {
            if (await _flightService.FlightHasDependenciesAsync(id))
            {
                return RedirectToAction("DeleteConfirm", "Flight", new { id = id, impossibleToDelete = true });
            }

            return RedirectToAction("Delete", "Flight", new {id = id});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var rates =  await _rateService.SelectAsync(x => x.FlightID == id);
            await _rateService.DeleteAsync(rates);
            await _flightService.DeleteAsync(id);
            return RedirectToAction("List", "Flight");
        }
    }
}
