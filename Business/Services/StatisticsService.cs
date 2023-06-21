using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;

namespace AirStar.Business.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRouteService _routeService;
        private readonly IFlightService _flightService;
        private readonly IPredictionService _predictionService;

        public StatisticsService(IRouteService routeService, IFlightService flightService, IPredictionService predictionService)
        {
            _routeService = routeService;
            _flightService = flightService;
            _predictionService = predictionService;
        }

        public async Task<IEnumerable<Flight>> SelectFlightsByRouteAndTime(int routeId, DateTime startPeriod, bool? oneMonth)
        {
            var endPeriod = oneMonth.GetValueOrDefault() ? startPeriod.AddMonths(1) : new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            
            var flights = await _flightService
                .SelectAsync(x => x.Route.Id == routeId && x.DepartureDate >= startPeriod && x.DepartureDate < endPeriod,
                    new List<string>() {"Aircraft", "Route", "Route.DepartureAirport", "Route.ArrivalAirport", "Reservations",
                        "Reservations.Passengers", "Reservations.Prices", "Rates" });
            return flights;
        }

        public int GetPassengerTraffic(IEnumerable<Flight> flights) => _predictionService.GetPassengerTraffic(flights);

        public decimal GetProfit(IEnumerable<Flight> flights) => _predictionService.GetProfit(flights);
    }
}
