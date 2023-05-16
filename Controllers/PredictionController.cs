using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AirStar.Controllers
{
    [Authorize]
    public class PredictionController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> RouteList()
        {
            return View();
        }
    }
}
