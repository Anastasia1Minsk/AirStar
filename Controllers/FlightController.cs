using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace AirStar.Controllers
{
    [Authorize]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IRateService _rateService;
        private readonly IMapper _mapper;

        public FlightController(IFlightService flightService, IRateService rateService, IMapper mapper)
        {
            _flightService = flightService;
            _rateService = rateService;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            var flights = await _flightService.SelectFlightsListAsync();
            var result = _mapper.Map<List<FlightViewModel>>(flights);
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var flight = await _flightService.SelectOneFlightListAsync(id);
            var result = _mapper.Map<FlightViewModel>(flight);
            return View(result);
        }
    }
}
