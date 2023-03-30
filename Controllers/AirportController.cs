using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.ViewModels;
using AutoMapper;

namespace AirStar.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportService _service;
        private readonly IMapper _mapper;

        public AirportController(IAirportService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            var airports = await _service.SelectWithCountiesAsync();
            var result = _mapper.Map<List<AirportViewModel>>(airports);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

    }
}
