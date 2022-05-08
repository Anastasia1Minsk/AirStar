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
    public class PriceService : ServiceBase<Price>, IPriceService
    {
        private readonly IPriceRepository _repository;
        public PriceService(IPriceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<decimal> GetTotalByReservationAsync(int reservationId)
        {
            var list = await SelectAsync(predicate: x => x.ReservationID == reservationId);
            var total = list.Sum(x => x.Amount * x.Cost);

            return total;
        }
    }
}
