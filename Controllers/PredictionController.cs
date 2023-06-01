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

            var efInd = new EfficiencyIndicatorsViewModel();

            efInd.PassengerTraffic = await _predictionService.GetPassengerTraffic(flights);

            efInd.PassengerTrafficMax = (108 + 80 + 8) * flights.Count();
            efInd.PassengerTurnover = efInd.PassengerTraffic * 3030;
            efInd.PassengerTurnoverMax = efInd.PassengerTrafficMax * 3030;
            efInd.LoadFactor = efInd.PassengerTrafficPercent;
            efInd.PartPassengerTraffic = 100;
            efInd.UnusedProportion = 8.84;
            efInd.Tonnage = (ulong)(efInd.PassengerTraffic * (90 + 32));
            efInd.TonnageMax = (ulong)(efInd.PassengerTrafficMax * (90 + 32));

            efInd.Luggage = true;
            efInd.Food = true;
            efInd.BusinessAndFirstClasses = true;
            efInd.LongDuration = false;
            efInd.ToHub = false;

            var temp = efInd.UnusedProportion * 10 * 2;
            
            efInd.Score = Convert.ToInt32(efInd.PassengerTrafficPercent + efInd.LoadFactor + temp + efInd.TonnagePercent);
            efInd.Score += 10 + 10 + 40;
            efInd.ScoreMax = 600;

            var model = new PerfomanceIndicatorsViewModel()
            {
                Flights = listOfFlights,
                EfficiencyIndicators = efInd
            };

            return View(model);
        }
    }
}
