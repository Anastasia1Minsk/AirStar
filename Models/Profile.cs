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
            CreateMap<Aircraft, AircraftViewModel>();
            CreateMap<Airport, AirportViewModel>();
            CreateMap<Country, CountryViewModel>();
            CreateMap<Flight, FlightViewModel>();
            CreateMap<Passenger, PassengerViewModel>();
            CreateMap<Price, PriceViewModel>();
            CreateMap<Rate, RateViewModel>();
            CreateMap<Reservation, ReservationViewModel>();
            CreateMap<Route, RouteViewModel>();
            CreateMap<User, RegistrationViewModel>();
            CreateMap<User, LogInViewModel>();
        }
    }
}
