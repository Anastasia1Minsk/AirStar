using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Data.Interfaces;
using AirStar.Infrastructure.Bases;
using AirStar.Models;

namespace AirStar.Business.Services
{
    public class CountryService : ServiceBase<Country>, ICountryService
    {
        private readonly ICountryRepository _repository;
        public CountryService(ICountryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsCountryExistsAsync(string name)
        {
            var result = await SelectOneAsync(predicate: x => x.Name == name);
            return result != null;
        }

        public async Task<bool> IsCountryUpdatesAsync(string name, int id)
        {
            var result = await SelectOneAsync(x => x.Name == name && x.Id != id);
            return result != null;
        }

        public async Task<bool> CountryHasDependenciesAsync(int id)
        {
            var country = await SelectOneAsync(predicate: x => x.Id == id,
                                                includes: new List<string>() {"Airports"});
            return country.Airports.Any();
        }
    }
}
