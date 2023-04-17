using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;

namespace AirStar.ViewModels
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<RegistrationViewModel, User>();
            CreateMap<LogInViewModel, User>();
            CreateMap<AircraftViewModel, Aircraft>();
            CreateMap<AirportViewModel, Airport>()
                .ForMember(dest => dest.TimeZone,
                    opt => opt
                        .MapFrom(src => int.Parse(src.TimeZone)));
            CreateMap<FlightViewModel, Flight>();
            CreateMap<RateViewModel, Rate>();
        }
    }
}
