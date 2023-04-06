using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;

namespace AirStar.Business.Interfaces
{
    public interface IAirportService : IServiceBase<Airport>
    {
        public Task<IEnumerable<Airport>> SelectWithCountiesAsync();
        public Task<Airport> SelectOneWithCountiesAsync(int id);
        public Task<bool> IsCodeExistsAsync(string code);
        public Task<bool> IsCodeUpdatesAsync(int airportId, string code);
    }
}
