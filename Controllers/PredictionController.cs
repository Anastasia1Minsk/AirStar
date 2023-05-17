using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AirStar.Controllers
{
    [Authorize]
    public class PredictionController : Controller
    {
        private readonly IRouteService _routeService;

        public PredictionController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<IActionResult> RouteList()
        {
            var routes = await _routeService.SelectForLastThreeMonthsAsync();
            return View(routes);
        }

        [HttpGet]
        public async Task<IActionResult> PerfomanceIndicators(int id)
        {
            return View();
        }
    }
}
