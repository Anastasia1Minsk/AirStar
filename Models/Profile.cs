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
                .ForMember(dest => dest.RouteId,
                    opt => opt
                        .MapFrom(src => src.Route.Id))
                .ForMember(dest => dest.DepartureAirport, 
                    opt => opt
                        .MapFrom(src => $"{src.Route.DepartureAirport.Code_IATA}, {src.Route.DepartureAirport.City}"))
                .ForMember(dest => dest.ArrivalAirport,
                    opt => opt
                        .MapFrom(src => $"{src.Route.ArrivalAirport.Code_IATA}, {src.Route.ArrivalAirport.City}"))
                .ForMember(dest => dest.Distance,
                    opt => opt
                        .MapFrom(src => src.Route.Distance))
                .ForMember(dest => dest.AircraftId,
                    opt => opt
                        .MapFrom(src => src.Aircraft.Id))
                .ForMember(dest => dest.Aircraft,
                    opt => opt
                        .MapFrom(src => $"{src.Aircraft.Brand} {src.Aircraft.Model}"));
            CreateMap<Rate, RateViewModel>();
            CreateMap<Airport, AirportViewModel>()
                .ForMember(dest => dest.TimeZone,
                    opt => opt
                        .MapFrom(src => src.TimeZone > 0 ? $"+{src.TimeZone}" : src.TimeZone.ToString()))
                .ForMember(dest => dest.Country,
                    opt => opt
                        .MapFrom(src => src.Country.Name));
            CreateMap<Route, RouteViewModel>()
                .ForMember(dest => dest.DepartureAirport_IATA,
                    opt => opt
                        .MapFrom(src => src.DepartureAirport.Code_IATA))
                .ForMember(dest => dest.DepartureAirport_Country,
                    opt => opt
                        .MapFrom(src => src.DepartureAirport.Country.Name))
                .ForMember(dest => dest.DepartureAirport_TimeZone,
                    opt => opt
                        .MapFrom(src => src.DepartureAirport.TimeZone > 0
                            ? $"+{src.DepartureAirport.TimeZone}"
                            : src.DepartureAirport.TimeZone.ToString()))
                .ForMember(dest => dest.ArrivalAirport_IATA,
                    opt => opt
                        .MapFrom(src => src.ArrivalAirport.Code_IATA))
                .ForMember(dest => dest.ArrivalAirport_Country,
                    opt => opt
                        .MapFrom(src => src.ArrivalAirport.Country.Name))
                .ForMember(dest => dest.ArrivalAirport_TimeZone,
                    opt => opt
                        .MapFrom(src => src.ArrivalAirport.TimeZone > 0
                            ? $"+{src.ArrivalAirport.TimeZone}"
                            : src.ArrivalAirport.TimeZone.ToString()));
        }
    }
}
