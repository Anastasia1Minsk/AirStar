using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirStar.Attributes;
using AirStar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace AirStar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Language()
        {
            var cultures = new List<string>() { "ru-BY", "en-US" };
            var cultureName = cultures[1];
            if (Request.Cookies.ContainsKey("lang"))
            {
                cultureName = Request.Cookies["lang"];
            }
           

            if (!cultures.Contains(cultureName))
            {
                cultureName = cultures[1];
            }

            var newCulture = cultureName == "en-US" ? "ru-BY" : "en-US";

            Response.Cookies.Append("lang", newCulture);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
