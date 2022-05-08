using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.Models.Enums;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirStar.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public UserController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Reservations()
        {
            var reservations =  await _reservationService.GetReservationByUser();
            return View(reservations);
        }
    }
}
