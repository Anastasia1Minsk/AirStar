using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Data.Interfaces;
using AirStar.Data.Repositories;
using AirStar.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AirStar.Data
{
    public class CompositionModule : ICompositionModule
    {
        public void RegisterTypes(IServiceCollection services)
        {
            services.AddScoped<IDataContextFactory, DataContextFactory>();

            services.AddScoped<IAircraftRepository, AircraftRepository>();
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
