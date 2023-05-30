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
        private readonly IPredictionService _predictionService;
        private readonly IMapper _mapper;

        public PredictionController(IPredictionService predictionService, IMapper mapper)
        {
            _predictionService = predictionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> RouteList()
        {
            var routes = await _predictionService.SelectRoutesForLastThreeMonthsAsync();
            return View(routes);
        }

        [HttpGet]
        public async Task<IActionResult> PerfomanceIndicators(int routeId)
        {
            var firstDayOfCurrentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var threeMonthAgo = firstDayOfCurrentMonth.AddMonths(-3);

            var flights = await _predictionService.SelectFlightsByRouteAndTime(routeId, threeMonthAgo);
            var listOfFlights = _mapper.Map<IEnumerable<FlightViewModel>>(flights).ToList();

            var efficiencyIndicators = new EfficiencyIndicatorsViewModel();
            efficiencyIndicators.PassengerTraffic = await _predictionService.GetPassengerTraffic(flights);

            efficiencyIndicators.PassengerTrafficMax = 44100;
            efficiencyIndicators.PassengerTurnover = efficiencyIndicators.PassengerTraffic * 3030;
            efficiencyIndicators.PassengerTurnoverMax = efficiencyIndicators.PassengerTrafficMax * 3030;
            efficiencyIndicators.LoadFactor = efficiencyIndicators.PassengerTrafficPercent;
            efficiencyIndicators.PartPassengerTraffic = 100;
            efficiencyIndicators.UnusedProportion = 5.1;
            efficiencyIndicators.Tonnage = 3030 * efficiencyIndicators.PassengerTraffic * (90 + 32);

            var model = new PerfomanceIndicatorsViewModel()
            {
                Flights = listOfFlights,
                EfficiencyIndicators = efficiencyIndicators
            };

            return View(model);
        }
    }
}
