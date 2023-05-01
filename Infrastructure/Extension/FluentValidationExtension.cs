using AirStar.Models;
using AirStar.Validations;
using AirStar.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace AirStar.Infrastructure.Extension
{
    public static class FluentValidationExtension
    {
        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<RegistrationViewModel>, RegistrationValidator>();
            services.AddTransient<IValidator<LogInViewModel>, LogInValidator>();

            services.AddTransient<IValidator<Country>, CountryValidator>();
            services.AddTransient<IValidator<AircraftViewModel>, AircraftValidator>();
            services.AddTransient<IValidator<AirportViewModel>, AirportValidator>();
            services.AddTransient<IValidator<Route>, RouteValidator>();
            services.AddTransient<IValidator<FlightViewModel>, FlightValidator>();
            services.AddTransient<IValidator<RateViewModel>, RateValidator>();

            services.AddTransient<IValidator<SearchViewModel>, SearchValidator>();

            services.AddTransient<IValidator<PassengerInformationViewModel>, PassengerInformationValidator>();
            services.AddTransient<IValidator<ReservationViewModel>, ReservationValidator>();
            services.AddTransient<IValidator<Passenger>, PassengerValidator>();

            services.AddTransient<IValidator<PaymentViewModel>, PaymentValidator>();

            
        }
    }
}
