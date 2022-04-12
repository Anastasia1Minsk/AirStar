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
            /*CreateMap<AircraftViewModel, Aircraft>();
            CreateMap<AirportViewModel, Airport>();
            CreateMap<CountryViewModel, Country>();
            CreateMap<FlightViewModel, Flight>();
            CreateMap<PassengerViewModel, Passenger>();
            CreateMap<PriceViewModel, Price>();
            CreateMap<RateViewModel, Rate>();
            CreateMap<ReservationViewModel, Reservation>();
            CreateMap<RouteViewModel, Route>();*/
            CreateMap<RegistrationViewModel, User>();
            CreateMap<LogInViewModel, User>();
        }
    }
}
