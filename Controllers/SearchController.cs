using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirStar.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICountryService _countryService;

        public SearchController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> SearchForm()
        {
            var countries = await _countryService.SelectAsync();
            SelectList countryNames = new SelectList(countries, "Id", "Name");
            ViewBag.CountryNames = countryNames;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchForm(SearchViewModel searchViewModel)
        {

            return View();
        }
    }
}
