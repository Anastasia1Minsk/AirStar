using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Controllers
{
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

            await _service.UpdateAsync(country);

            return RedirectToAction("List", "Country");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("List", "Country");
        }
    }
}
