using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;

namespace AirStar.Business.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
