using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AirStar.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> Common()
        {
            var text = string.Empty;
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var viewModel = new PeriodViewModel() { StartThreeMonthPeriod = today.AddMonths(-3) };

            for (var i = -3; i < 0; i++)
            {
                var previousMonth = today.AddMonths(i);
                
                text += previousMonth.Month == 12 || i == -1
                    ? $"{previousMonth.ToString("Y", culture)} "
                    : $"{previousMonth.ToString("MMMM", culture)} | ";
            }

            viewModel.ThreeMonths = text;
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> PeriodStatistic(DateTime startPeriod, bool? threeMonthDuration = false, int? monthOrderInPeriod = 0)
        {
            var viewModel = new StatisticViewModel();

            if (threeMonthDuration.GetValueOrDefault())
            {
                viewModel.ThreeMonthDuration = true;
                viewModel.Period = new PeriodViewModel() { StartThreeMonthPeriod = startPeriod };
            }
            else
            {
                viewModel.Period = monthOrderInPeriod switch
                {
                    1 => new PeriodViewModel() { StartThreeMonthPeriod = startPeriod },
                    2 => new PeriodViewModel() { StartThreeMonthPeriod = startPeriod.AddMonths(-1) },
                    3 => new PeriodViewModel() { StartThreeMonthPeriod = startPeriod.AddMonths(-2) }
                };

                viewModel.Month = startPeriod;
            }

            if (monthOrderInPeriod == 1)
            {
                var flights = await _statisticsService.SelectFlightsByRouteAndTime(1, startPeriod, true);
                viewModel.FlightCount = flights.Count();
                viewModel.PassengerTraffic = _statisticsService.GetPassengerTraffic(flights);
                viewModel.PassengerTurnover = viewModel.PassengerTraffic * 3030;
                viewModel.IncomeRate = _statisticsService.GetProfit(flights);
            }

            if (threeMonthDuration.GetValueOrDefault())
            {
                viewModel.FlightCount = 170;
                viewModel.PassengerTraffic = 28856;
                viewModel.PassengerTurnover = 87433680;
                viewModel.IncomeRate = 37102700;
            }

            viewModel.RouteCount = 1;
            viewModel.AverageRange = 3030;

            return View(viewModel);
        }
    }
}
