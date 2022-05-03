using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Infrastructure.Bases;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace AirStar.Controllers
{
    public class SearchController : Controller
    {
        private readonly IAirportService _airportService;
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public SearchController(IAirportService airportService, IFlightService flightService, IMapper mapper)
        {
            _airportService = airportService;
            _flightService = flightService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SearchForm()
        {
            ViewBag.CityNames = await ListOfCities();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchForm(SearchViewModel searchViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CityNames = await ListOfCities();
                return View(searchViewModel);
            }

            var routeValues = new RouteValueDictionary {
                { "DepartureAirportID", searchViewModel.DepartureAirportID },
                { "ArrivalAirportID", searchViewModel.ArrivalAirportID },
                { "NumberOfPassengers", searchViewModel.NumberOfPassengers },
                { "DepartureDate", searchViewModel.DepartureDate }
            };

            return RedirectToAction("Flights", "Search", routeValues);
        }

        private async Task<SelectList> ListOfCities()
        {
            var airports = await _airportService.SelectAsync();
            SelectList cityNames = new SelectList(airports.Select(x => new { x.Id, Name = $"{x.City}, {x.Code_IATA}"}),
                                                    "Id", "Name");
            return cityNames;
        }

        [HttpGet]
        public async Task<IActionResult> Flights(int departureAirportID, int arrivalAirportID, int numberOfPassengers, DateTime departureDate,
            int page = 1)
        {
            var searchViewModel = new SearchViewModel()
            {
                DepartureAirportID = departureAirportID,
                ArrivalAirportID = arrivalAirportID,
                NumberOfPassengers = numberOfPassengers,
                DepartureDate = departureDate
            };

            var suitableFlights = await _flightService.FlightSearch(searchViewModel, page);

            var result = new PagedList<FlightViewModel>()
            {
                CurrentPage = suitableFlights.CurrentPage,
                PageSize = suitableFlights.PageSize,
                TotalCount = suitableFlights.TotalCount,
                TotalPages = suitableFlights.TotalPages,
                Data = _mapper.Map<List<FlightViewModel>>(suitableFlights.Data)
            };

            return View(result);
        }
    }
}
