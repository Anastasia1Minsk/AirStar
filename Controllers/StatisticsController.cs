using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AirStar.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AirStar.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Common()
        {
            var text = string.Empty;
            var culture = CultureInfo.CreateSpecificCulture("en-US");

            for (var i = -3; i < 0; i++)
            {
                var previousMonth = DateTime.Now.AddMonths(i);
                
                text += previousMonth.Month == 12 || i == -1
                    ? $"{previousMonth.ToString("Y", culture)} "
                    : $"{previousMonth.ToString("MMMM", culture)} | ";
            }

            var result = new PeriodViewModel{ ThreeMonths = text};
            return View(result);
        }
    }
}
