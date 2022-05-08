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
            CreateMap<Aircraft, AircraftViewModel>();
            CreateMap<Flight, FlightViewModel>()
                .ForMember(dest => dest.DepartureAirport, 
                    opt => opt
                        .MapFrom(src => $"{src.Route.DepartureAirport.City}, {src.Route.DepartureAirport.Code_IATA}"))
                .ForMember(dest => dest.ArrivalAirport,
                    opt => opt
                        .MapFrom(src => $"{src.Route.ArrivalAirport.City}, {src.Route.ArrivalAirport.Code_IATA}"))
                .ForMember(dest => dest.Distance,
                    opt => opt
                        .MapFrom(src => src.Route.Distance));
            CreateMap<Rate, RatesViewModel>();
        }
    }
}
