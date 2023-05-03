using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;

namespace AirStar.Business.Interfaces
{
    public interface ICountryService : IServiceBase<Country>
    {
        public Task<bool> IsCountryExistsAsync(string name);
        public Task<bool> IsCountryUpdatesAsync(string name, int id);
        public Task<bool> CountryHasDependenciesAsync(int id);
    }
}
