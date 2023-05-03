using Microsoft.AspNetCore.Mvc;
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
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;

        public RouteController(IRouteService routeService, IAirportService airportService, IMapper mapper)
        {
            _routeService = routeService;
            _airportService = airportService;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            var routes = await _routeService.SelectWithAirportsAsync();
            return View(routes);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Airports = await ListOfAirports();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Route route)
        {
            ViewBag.Airports = await ListOfAirports();

            if (!ModelState.IsValid)
            {
                return View(route);
            }

            if (route.DepartureAirport_ID == route.ArrivalAirport_ID)
            {
                ModelState.AddModelError("ArrivalAirport_ID", "Seems like obseesed");
                return View(route);
            }

            if (await _routeService.IsRouteExistsAsync(route.DepartureAirport_ID, route.ArrivalAirport_ID))
            {
                ModelState.AddModelError("ArrivalAirport_ID", "Such route exists");
                return View(route);
            }

            await _routeService.InsertAsync(route);

            return RedirectToAction("List", "Route");
        }

        private async Task<SelectList> ListOfAirports()
        {
            var airports = await _airportService.SelectWithCountiesAsync();
            var airportsNames = new SelectList(airports.Select(x => new { x.Id, Name = $"{x.Code_IATA}, {x.City}, {x.Country.Name}" }),
                "Id", "Name");
            return airportsNames;
        }

        public async Task<IActionResult> Details(int id)
        {
            var route = await _routeService.SelectOneWithAirportsAsync(id);
            var result = _mapper.Map<RouteViewModel>(route);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Airports = await ListOfAirports();

            var route = await _routeService.SelectOneWithAirportsAsync(id);
            return View(route);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Route route)
        {
            ViewBag.Airports = await ListOfAirports();

            if (!ModelState.IsValid)
            {
                return View(route);
            }

            if (route.DepartureAirport_ID == route.ArrivalAirport_ID)
            {
                ModelState.AddModelError("ArrivalAirport_ID", "Seems like obseesed");
                return View(route);
            }

            if (await _routeService.IsRouteUpdatesAsync(route.DepartureAirport_ID, route.ArrivalAirport_ID, route.Id))
            {
                ModelState.AddModelError("ArrivalAirport_ID", "Such route exists");
                return View(route);
            }
            
            await _routeService.UpdateAsync(route);

            return RedirectToAction("List", "Route");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(int id, bool? impossibleToDelete = false)
        {
            if (impossibleToDelete.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. The route operates flights";
            }

            var route = await _routeService.SelectOneWithAirportsAsync(id);
            var result = _mapper.Map<RouteViewModel>(route);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> TryDelete(int id)
        {
            if (await _routeService.RouteHasDependenciesAsync(id))
            {
                return RedirectToAction("DeleteConfirm", "Route", new { id = id, impossibleToDelete = true });
            }

            return RedirectToAction("Delete", "Route", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _routeService.DeleteAsync(id);
            return RedirectToAction("List", "Route");
        }
    }
}
