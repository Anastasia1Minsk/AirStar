using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;

namespace AirStar.Business.Interfaces
{
    public interface IFlightService : IServiceBase<Flight>
    {
        public Task<IPagedList<Flight>> FlightSearchAsync(SearchViewModel searchViewModel, int page);
        public Task<IEnumerable<Flight>> SelectFlightsListAsync();
        public Task<Flight> SelectOneFlightAsync(int id);
        public Task<bool> IsFlightExistsAsync(Flight flight);
        public Task<bool> IsFlightUpdatesAsync(Flight flight);
    }
}
