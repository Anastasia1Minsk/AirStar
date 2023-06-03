using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using AirStar.Models.Enums;

namespace AirStar.Business.Interfaces
{
    public interface IPredictionService
    {
        public Task<IEnumerable<Route>> SelectRoutesForLastThreeMonthsAsync();
        public Task<IEnumerable<Flight>> SelectFlightsByRouteAndTime(int routeId, DateTime minDepartureDate);
        public int GetPassengerTraffic(IEnumerable<Flight> flights);
        public decimal GetProfit(IEnumerable<Flight> flights);
        public decimal GetMaxProfit(IEnumerable<Flight> flights);
        public decimal GetAverageCost(IEnumerable<Flight> flights, RateTypes type);
    }
}
