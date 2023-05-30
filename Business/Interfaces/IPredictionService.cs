using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;

namespace AirStar.Business.Interfaces
{
    public interface IPredictionService
    {
        public Task<IEnumerable<Route>> SelectRoutesForLastThreeMonthsAsync();
        public Task<IEnumerable<Flight>> SelectFlightsByRouteAndTime(int routeId, DateTime minDepartureDate);
        public Task<int> GetPassengerTraffic(IEnumerable<Flight> flights);
    }
}
