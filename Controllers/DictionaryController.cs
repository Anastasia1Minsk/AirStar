using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AirStar.Controllers
{
    [Authorize]
    public class DictionaryController : Controller
    {
        public async Task<IActionResult> List()
        {
            return View();
        }
    }
}
