﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirStar.Controllers
{
    [Authorize]
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
            ViewBag.CountryNames = await ListOfCountries();

            if (!ModelState.IsValid)
            {
                return View(airportViewModel);
            }

            if (await _airportService.IsCodeExistsAsync(airportViewModel.Code_IATA))
            {
                ModelState.AddModelError("Code_IATA", "\"Code IATA\" isn't unique");
                return View(airportViewModel);
            }

            var airport = _mapper.Map<Airport>(airportViewModel);
            await _airportService.InsertAsync(airport);

            return RedirectToAction("List", "Airport");
        }

        private async Task<SelectList> ListOfCountries()
        {
            var countries = await _countryService.SelectAsync();
            var countriesNames = new SelectList(countries.Select(x => new { x.Id, x.Name }),
                "Id", "Name");
            return countriesNames;
        }

        public async Task<IActionResult> Details(int id)
        {
            var airport = await _airportService.SelectOneWithCountiesAsync(id);
            var result = _mapper.Map<AirportViewModel>(airport);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CountryNames = await ListOfCountries();

            var airport = await _airportService.SelectOneWithCountiesAsync(id);
            var result = _mapper.Map<AirportViewModel>(airport);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AirportViewModel airportViewModel)
        {
            ViewBag.CountryNames = await ListOfCountries();

            if (!ModelState.IsValid)
            {
                return View(airportViewModel);
            }

            if (await _airportService.IsCodeUpdatesAsync(airportViewModel.Id, airportViewModel.Code_IATA))
            {
                ModelState.AddModelError("Code_IATA", "\"Code IATA\" isn't unique");
                return View(airportViewModel);
            }

            var airport = _mapper.Map<Airport>(airportViewModel);
            await _airportService.UpdateAsync(airport);

            return RedirectToAction("List", "Airport");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(int id, bool? impossibleToDelete = false)
        {
            if (impossibleToDelete.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. The airport operates routes";
            }

            var airport = await _airportService.SelectOneWithCountiesAsync(id);
            var result = _mapper.Map<AirportViewModel>(airport);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> TryDelete(int id)
        {
            if (await _airportService.AirportHasDependenciesAsync(id))
            {
                return RedirectToAction("DeleteConfirm", "Airport", new { id = id, impossibleToDelete = true });
            }

            return RedirectToAction("Delete", "Airport", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _airportService.DeleteAsync(id);
            return RedirectToAction("List", "Airport");
        }
    }
}
