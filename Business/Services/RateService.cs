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
    public class RateService : ServiceBase<Rate>, IRateService
    {
        private readonly IRateRepository _repository;
        public RateService(IRateRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Rate>> GetRatesByFlightAsync(int flightId)
        {
            var result = await SelectAsync(predicate: rates => rates.FlightID == flightId);

            return result;
        }
    }
}
