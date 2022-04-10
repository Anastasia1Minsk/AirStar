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
    public class RouteService : ServiceBase<Route>, IRouteService
    {
        private readonly IRouteRepository _repository;
        public RouteService(IRouteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
