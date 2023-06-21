using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Resources;

namespace AirStar.Controllers
{
    [Authorize]
    public class AircraftController : Controller
    {
        private readonly IAircraftService _service;
        private readonly IMapper _mapper;

        public AircraftController(IAircraftService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
        public async Task<IActionResult> Create(AircraftViewModel aircraftViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(aircraftViewModel);
            }

            await _service.InsertAsync(aircraftViewModel);

            return RedirectToAction("List", "Aircraft");
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var aircraft = await _service.GetByIdAsync(id);
            var result = _mapper.Map<AircraftViewModel>(aircraft);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AircraftViewModel aircraftViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(aircraftViewModel);
            }

            await _service.UpdateAsync(aircraftViewModel);

            return RedirectToAction("List", "Aircraft");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(int id, bool? impossibleToDelete = false)
        {
            if (impossibleToDelete.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = AircraftRes.ErrorMessege;
            }
            
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> TryDelete(int id)
        {
            if (await _service.AircraftHasDependenciesAsync(id))
            {
                return RedirectToAction("DeleteConfirm", "Aircraft", new { id = id, impossibleToDelete = true });
            }

            return RedirectToAction("Delete", "Aircraft", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var aircraft = await _service.GetByIdAsync(id);
            await _service.DeletePicruteAsync(aircraft);
            await _service.DeleteAsync(aircraft);

            return RedirectToAction("List", "Aircraft");
        }
    }
}
