using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AirStar.Controllers
{
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
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var aircraft = await _service.GetByIdAsync(id);
            var aircraftViewModel = _mapper.Map<AircraftViewModel>(aircraft);

            await _service.DeletePicruteAsync(aircraftViewModel);
            await _service.DeleteAsync(aircraft);

            return RedirectToAction("List", "Aircraft");
        }
    }
}
