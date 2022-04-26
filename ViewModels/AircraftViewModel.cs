﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AirStar.ViewModels
{
    public class AircraftViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }

        [Display(Name = "Year Of Build")]
        public int YearOfBuild { get; set; }

        [Display(Name = "Economy Class Seats")]
        public int EconomyClassSeats { get; set; }

        [Display(Name = "Business Class Seats")]
        public int? BusinessClassSeats { get; set; }

        [Display(Name = "First Class Seats")]
        public int? FirstClassSeats { get; set; }

        [Display(Name = "Maximum Flight Range")]
        public int MaxFlightRange { get; set; }
        public IFormFile PictureFile { get; set; }
        public string Picture { get; set; }
    }
}
