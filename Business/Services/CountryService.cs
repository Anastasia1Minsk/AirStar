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
    }
}
