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
                                            "Reservations.Passengers", "Reservations.Prices", "Rates" });
            return flights;
        }

        public int GetPassengerTraffic(IEnumerable<Flight> flights)
        {
            var sum = 0;

            foreach (var price in GetPrices(flights))
            {
                sum += price.Amount;
            }

            return sum;
        }

        public decimal GetProfit(IEnumerable<Flight> flights)
        {
            decimal sum = 0;

            foreach (var price in GetPrices(flights))
            {
                sum += price.Amount * price.Cost;
            }

            return sum;
        }

        private List<Price> GetPrices(IEnumerable<Flight> flights)
        {
            var prices = new List<Price>();

            foreach (var f in flights)
            {
                if (f.Reservations.Any())
                {
                    foreach (var r in f.Reservations)
                    {
                        prices.AddRange(r.Prices.Where(x => x.RateType == RateTypes.AdultEconomyFlight
                                                            || x.RateType == RateTypes.AdultBusinessFlight
                                                            || x.RateType == RateTypes.AdultFirstFlight)
                                                 .ToList());
                        
                    }
                }
            }

            return prices;
        }

        public decimal GetMaxProfit(IEnumerable<Flight> flights)
        {
            decimal sum = 0;

            foreach (var f in flights)
            {
                sum += f.Aircraft.EconomyClassSeats *
                       f.Rates.Single(x => x.RateType == RateTypes.AdultEconomyFlight).Price;

                if (f.Aircraft.BusinessClassSeats is not null)
                {
                    sum += f.Aircraft.BusinessClassSeats.GetValueOrDefault() *
                           f.Rates.Single(x => x.RateType == RateTypes.AdultBusinessFlight).Price;
                }

                if (f.Aircraft.FirstClassSeats is not null)
                {
                    sum += f.Aircraft.FirstClassSeats.GetValueOrDefault() *
                           f.Rates.Single(x => x.RateType == RateTypes.AdultFirstFlight).Price;
                }
            }

            return sum;
        }

        public decimal GetAverageCost(IEnumerable<Flight> flights, RateTypes type)
        {
            decimal sumCost = 0;
            var seats = 0;

            foreach (var f in flights)
            {
                var aircraftSeats = type switch
                {
                    RateTypes.AdultEconomyFlight => f.Aircraft.EconomyClassSeats,
                    RateTypes.AdultBusinessFlight => f.Aircraft.BusinessClassSeats.GetValueOrDefault(),
                    RateTypes.AdultFirstFlight => f.Aircraft.FirstClassSeats.GetValueOrDefault(),
                    _ => throw new NotImplementedException()
                };
                seats += aircraftSeats;

                sumCost += aircraftSeats * f.Rates.Single(x => x.RateType == type).Price;
            }

            return sumCost / seats;
        }
    }
}
