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

            var efficiencyIndicators = GetEfficiencyIndicators(flights);

            var model = new PerfomanceIndicatorsViewModel()
            {
                Flights = listOfFlights,
                EfficiencyIndicators = efficiencyIndicators,
                MonetaryIndicators = GetMonetaryIndicators(flights, efficiencyIndicators.PassengerTraffic),
                FlightIndicators = GetFlightIndicators(flights, efficiencyIndicators.LoadFactor, efficiencyIndicators.PassengerTraffic)
            };

            return View(model);
        }

        private EfficiencyIndicatorsViewModel GetEfficiencyIndicators(IEnumerable<Flight> flights)
        {
            var efInd = new EfficiencyIndicatorsViewModel();

            efInd.PassengerTraffic = _predictionService.GetPassengerTraffic(flights);

            efInd.PassengerTrafficMax = (108 + 80 + 8) * flights.Count();
            efInd.PassengerTurnover = efInd.PassengerTraffic * 3030;
            efInd.PassengerTurnoverMax = efInd.PassengerTrafficMax * 3030;
            efInd.PartPassengerTraffic = 100;
            efInd.UnusedProportion = 8.84m;
            efInd.Tonnage = (ulong)(efInd.PassengerTraffic * (90 + 32));
            efInd.TonnageMax = (ulong)(efInd.PassengerTrafficMax * (90 + 32));

            efInd.Luggage = true;
            efInd.Food = true;
            efInd.BusinessAndFirstClasses = true;
            efInd.LongDuration = false;
            efInd.ToHub = false;

            var temp = efInd.UnusedProportion * 10 * 2;

            efInd.Score = Convert.ToInt32(efInd.LoadFactor + efInd.LoadFactor + temp + efInd.TonnagePercent);
            efInd.Score += 10 + 10 + 40;
            efInd.ScoreMax = 600;

            return efInd;
        }

        private MonetaryIndicatorsViewModel GetMonetaryIndicators(IEnumerable<Flight> flights, int passengers)
        {
            var mInd = new MonetaryIndicatorsViewModel();

            mInd.Profit = _predictionService.GetProfit(flights);
            mInd.ProfitMax = _predictionService.GetMaxProfit(flights);
            mInd.AverageFee = mInd.Profit / passengers;

            mInd.AverageEconomyCost = _predictionService.GetAverageCost(flights, RateTypes.AdultEconomyFlight);
            mInd.AverageBusinessCost = _predictionService.GetAverageCost(flights, RateTypes.AdultBusinessFlight);
            mInd.AverageFirstCost = _predictionService.GetAverageCost(flights, RateTypes.AdultFirstFlight);

            return mInd;
        }

        private FlightIndicatorsViewModel GetFlightIndicators(IEnumerable<Flight> flights, decimal loadFactor, int passengers)
        {
            var flInd = new FlightIndicatorsViewModel();

            flInd.LoadFactor = loadFactor;
            flInd.Aircrafts = new List<string>() {"Boeing B777-300ER (E/B/F)"};

            GetClassParameters(flights, flInd, RateTypes.AdultEconomyFlight, passengers);
            GetClassParameters(flights, flInd, RateTypes.AdultBusinessFlight, passengers);
            GetClassParameters(flights, flInd, RateTypes.AdultFirstFlight, passengers);

            return flInd;
        }

        private void GetClassParameters(IEnumerable<Flight> flights, FlightIndicatorsViewModel viewModel, RateTypes type, int passengers)
        {
            var trafficForClass = _predictionService.GetPassengerTraffic(flights, type);

            var parameterPercent = GetPercent(trafficForClass, passengers);
            var parameterLoadFactor = GetPercent(trafficForClass, _predictionService.GetClassSeatsCount(flights, type));

            _ = type switch
            {
                RateTypes.AdultEconomyFlight => viewModel.EconomyPercent = parameterPercent,
                RateTypes.AdultBusinessFlight => viewModel.BusinessPercent = parameterPercent,
                RateTypes.AdultFirstFlight => viewModel.FirstPercent = parameterPercent,
                _ => throw new NotImplementedException()
            };

            _ = type switch
            {
                RateTypes.AdultEconomyFlight => viewModel.EconomyLoadFactor = parameterLoadFactor,
                RateTypes.AdultBusinessFlight => viewModel.BusinessLoadFactor = parameterLoadFactor,
                RateTypes.AdultFirstFlight => viewModel.FirstLoadFactor = parameterLoadFactor,
                _ => throw new NotImplementedException()
            };
        }

        private decimal GetPercent(int part, int whole) => (decimal)part * 100 / whole;
    }
}
