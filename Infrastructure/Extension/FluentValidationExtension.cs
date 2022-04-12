using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace AirStar.Infrastructure.Extension
{
    public static class FluentValidationExtension
    {
        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<PaymentOrderPost>, PaymentOrderPostValidator>();
        }
    }
}
