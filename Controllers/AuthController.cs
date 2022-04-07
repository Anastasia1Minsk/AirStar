using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using AirStar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AirStar.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel registrationViewModel)
        {
            return View(registrationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel logInViewModel)
        {
            return View(logInViewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            return View();
        }
    }
}
