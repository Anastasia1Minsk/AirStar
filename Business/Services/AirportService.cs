using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Data.Interfaces;
using AirStar.Infrastructure.Bases;
using AirStar.Models;
using AirStar.ViewModels;

namespace AirStar.Business.Services
{
    public class AirportService : ServiceBase<Airport>, IAirportService
    {
        private readonly IAirportRepository _repository;
        public AirportService(IAirportRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Airport>> SelectWithCountiesAsync()
        {
            return await SelectAsync(includes: new List<string>() { "Country" });
        }
    }
}
