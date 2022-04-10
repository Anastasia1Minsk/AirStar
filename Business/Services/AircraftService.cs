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
    public class AircraftService : ServiceBase<Aircraft>, IAircraftService
    {
        private readonly IAircraftRepository _repository;
        public AircraftService(IAircraftRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
