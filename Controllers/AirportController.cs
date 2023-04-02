﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirStar.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportService _airportService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public AirportController(IAirportService airportService, ICountryService countryService, IMapper mapper)
        {
            _airportService = airportService;
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            var airports = await _airportService.SelectWithCountiesAsync();
            var result = _mapper.Map<List<AirportViewModel>>(airports);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CountryNames = await ListOfCountries();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AirportViewModel airportViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CountryNames = await ListOfCountries();
                return View(airportViewModel);
            }

            if (await _airportService.IsCodeExistsInDB(airportViewModel.Code_IATA))
            {
                ModelState.AddModelError("Code_IATA", "\"Code IATA\" isn't unique");
                ViewBag.CountryNames = await ListOfCountries();
                return View(airportViewModel);
            }

            var airport = _mapper.Map<Airport>(airportViewModel);
            await _airportService.InsertAsync(airport);

            return RedirectToAction("List", "Airport");
        }

        public async Task<SelectList> ListOfCountries()
        {
            var countries = await _countryService.SelectAsync();
            var countriesNames = new SelectList(countries.Select(x => new { x.Id, x.Name }),
                "Id", "Name");
            return countriesNames;
        }
    }
}