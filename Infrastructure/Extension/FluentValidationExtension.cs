using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }
    }
}
