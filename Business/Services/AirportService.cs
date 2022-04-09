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
    public class AirportService : ServiceBase<Airport>, IAirportService
    {
        private readonly IAirportRepository _repository;
        public AirportService(IAirportRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
