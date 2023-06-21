using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;

namespace AirStar.Business.Interfaces
{
    public interface IStatisticsService
    {
        public Task<IEnumerable<Flight>> SelectFlightsByRouteAndTime(int routeId, DateTime startPeriod, bool? oneMonth);
        public int GetPassengerTraffic(IEnumerable<Flight> flights);
        public decimal GetProfit(IEnumerable<Flight> flights);
    }
}
