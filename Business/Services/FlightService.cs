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
    public class FlightService : ServiceBase<Flight>, IFlightService
    {
        private readonly IFlightRepository _repository;
        public FlightService(IFlightRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
