using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace AirStar.Attributes
{
    public class CultureAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            /*string cultureName = null;
            
            var cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            cultureName = cultureCookie ?? "en-US";
            
            List<string> cultures = new List<string>() { "ru-BY", "en-US" };
            if (!cultures.Contains(cultureName))
            {
                cultureName = "en-US";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);*/
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureName = null;

            var cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            cultureName = cultureCookie ?? "en-US";

            List<string> cultures = new List<string>() { "ru-BY", "en-US" };
            if (!cultures.Contains(cultureName))
            {
                cultureName = "en-US";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }
    }
}
