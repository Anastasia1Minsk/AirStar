using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.Models.Enums;

namespace AirStar.Business.Services
{
    public class PredictionService : IPredictionService
    {
        private readonly IRouteService _routeService;
        private readonly IFlightService _flightService;

        public PredictionService(IRouteService routeService, IFlightService flightService)
        {
            _routeService = routeService;
            _flightService = flightService;
        }

        public async Task<IEnumerable<Route>> SelectRoutesForLastThreeMonthsAsync() =>
            await _routeService.SelectForLastThreeMonthsAsync();

        public async Task<IEnumerable<Flight>> SelectFlightsByRouteAndTime(int routeId, DateTime minDepartureDate)
        {
            var currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var flights = await _flightService
                .SelectAsync(x => x.Route.Id == routeId && x.DepartureDate >= minDepartureDate && x.DepartureDate < currentMonth,
                new List<string>() {"Aircraft", "Route", "Route.DepartureAirport", "Route.ArrivalAirport", "Reservations", 
                    "Reservations.Passengers", "Reservations.Prices" });
            return flights;
        }

        public async Task<int> GetPassengerTraffic(IEnumerable<Flight> flights)
        {
            var sum = 0;
            foreach (var f in flights)
            {
                if (f.Reservations.Any())
                {
                    foreach (var r in f.Reservations)
                    {
                        /*sum += r.Prices.Where(x => x.RateType == RateTypes.AdultEconomyFlight
                                                   || x.RateType == RateTypes.AdultBusinessFlight 
                                                   || x.RateType == RateTypes.AdultFirstFlight)
                            .ToList()
                            .ForEach(x => x)
                            .Select(x => x.Amount);*/

                        var prices = r.Prices.Where(x => x.RateType == RateTypes.AdultEconomyFlight
                                                    || x.RateType == RateTypes.AdultBusinessFlight
                                                    || x.RateType == RateTypes.AdultFirstFlight)
                            .ToList();

                        foreach (var p in prices)
                        {
                            sum += p.Amount;
                        }
                    }
                }
            }

            return sum;
        }
    }
}
