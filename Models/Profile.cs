using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.ViewModels;
using AutoMapper;

namespace AirStar.Models
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<User, RegistrationViewModel>();
            CreateMap<User, LogInViewModel>();
        }
    }
}
