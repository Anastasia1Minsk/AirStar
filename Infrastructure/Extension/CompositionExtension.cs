using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AirStar.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirStar.Infrastructure.Extension
{
    public static class CompositionExtension
    {
        public static void ConfigureCompositionModules(this IServiceCollection services, IConfiguration configuration)
        {
            var modules = new List<ICompositionModule>()
            {
                new Business.CompositionModule(),
                new Data.CompositionModule()
            };

            modules.ForEach(x => x.RegisterTypes(services));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth/LogIn");
                });
        }
    }
}
