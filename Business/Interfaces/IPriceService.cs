using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;

namespace AirStar.Business.Interfaces
{
    public interface IPriceService : IServiceBase<Price>
    {
        public Task<decimal> GetTotalByReservationAsync(int reservationId);
    }
}
