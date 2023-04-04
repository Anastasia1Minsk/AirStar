using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models
{
    public class Aircraft : BaseModel
    {
        public string Model { get; set; }

        public string Brand { get; set; }

        [Display(Name = "Year of build")]
        public int YearOfBuild { get; set; }

        [Display(Name = "Economy class seats")]
        public int EconomyClassSeats { get; set; }

        [Display(Name = "Business class seats")]
        public int? BusinessClassSeats { get; set; }

        [Display(Name = "First class seats")]
        public int? FirstClassSeats { get; set; }

        [Display(Name = "Maximum flight range")]
        public int MaxFlightRange { get; set; }

        public string Picture { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
