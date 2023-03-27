using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Controllers
{
    public class AirportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
