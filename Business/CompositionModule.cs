using AirStar.Business.Interfaces;
using AirStar.Business.Services;
using AirStar.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AirStar.Business
{
    public class CompositionModule : ICompositionModule
    {
        public void RegisterTypes(IServiceCollection services)
        {
            services.AddScoped<IAircraftService, AircraftService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IPassengerService, PassengerService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPredictionService, PredictionService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
        }
    }
}
