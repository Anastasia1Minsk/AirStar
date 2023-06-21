using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AirStar.Infrastructure
{
    public class LocaliseMiddleware
    {
        private readonly RequestDelegate _next;

        public LocaliseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            LanguageFromCookie(context);

            await _next(context);
        }


        private void LanguageFromCookie(HttpContext context)
        {
            var cultureCookie = "en-US";

            if (!context.Request.Cookies.ContainsKey("lang"))
            {
                context.Response.Cookies.Append("lang", cultureCookie);
            }
            else
            {
                cultureCookie = context.Request.Cookies["lang"];
            }

            CultureInfo.DefaultThreadCurrentUICulture = cultureCookie == "ru-BY" 
                ? new CultureInfo("ru-BY")
                : new CultureInfo("en-US");

            CultureInfo.DefaultThreadCurrentCulture = cultureCookie == "ru-BY"
                ? new CultureInfo("ru-BY")
                : new CultureInfo("en-US");
        }
    }
}
