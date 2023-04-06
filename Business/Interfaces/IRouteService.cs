using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;

namespace AirStar.Business.Interfaces
{
    public interface IRouteService : IServiceBase<Route>
    {
        public Task<IEnumerable<Route>> SelectWithAirportsAsync();
        public Task<Route> SelectOneWithAirportsAsync(int id);
        public Task<bool> IsRouteExistsAsync(int DepartureAirport_ID, int ArrivalAirport_ID);
        public Task<bool> IsRouteUpdatesAsync(int DepartureAirport_ID, int ArrivalAirport_ID, int routeId);
    }
}
