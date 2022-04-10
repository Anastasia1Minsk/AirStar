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
    public class ReservationService : ServiceBase<Reservation>, IReservationService
    {
        private readonly IReservationRepository _repository;
        public ReservationService(IReservationRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
