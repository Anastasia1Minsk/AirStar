﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> List()
        {
            var result = await _service.SelectAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Country country)
        {
            if (!ModelState.IsValid)
            {
                return View(country);
            }

            if (await _service.IsCountryExistsAsync(country.Name))
            {
                ModelState.AddModelError("Name", "Such country exists");
                return View(country);
            }

            await _service.InsertAsync(country);

            return RedirectToAction("List", "Country");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Country country)
        {
            if (!ModelState.IsValid)
            {
                return View(country);
            }

            if (await _service.IsCountryUpdatesAsync(country.Name, country.Id))
            {
                ModelState.AddModelError("Name", "Such country exists");
                return View(country);
            }

            await _service.UpdateAsync(country);

            return RedirectToAction("List", "Country");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(int id, bool? impossibleToDelete = false)
        {
            if (impossibleToDelete.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. The country operates airports";
            }

            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> TryDelete(int id)
        {
            if (await _service.CountryHasDependenciesAsync(id))
            {
                return RedirectToAction("DeleteConfirm", "Country", new { id = id, impossibleToDelete = true });
            }

            return RedirectToAction("Delete", "Country", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("List", "Country");
        }
    }
}
