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
    public class PredictionController : Controller
    {
        private readonly IRouteService _routeService;
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public PredictionController(IRouteService routeService, IFlightService flightService, IMapper mapper)
        {
            _routeService = routeService;
            _flightService = flightService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> RouteList()
        {
            var routes = await _routeService.SelectForLastThreeMonthsAsync();
            return View(routes);
        }

        [HttpGet]
        public async Task<IActionResult> PerfomanceIndicators(int routeId)
        {
            /*var f = await _flightService.SelectAsync(x => x.Route.Id == routeId,
                new List<string>() {"Route"});
            var fVM = _mapper.Map<PerfomanceIndicatorsViewModel>()*/
            var model = new PerfomanceIndicatorsViewModel();
            return View(model);
        }
    }
}
