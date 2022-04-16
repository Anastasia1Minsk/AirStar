using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;

namespace AirStar.Business.Interfaces
{
    public interface IAuthService
    {
        Task<int> RegistrationAsync(RegistrationViewModel registrationViewModel);
        Task<bool> LogInAsync(LogInViewModel logInViewModel);
        Task LogOffAsync();
    }
}
