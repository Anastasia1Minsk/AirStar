using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models
{
    public class Aircraft : BaseModel
    {
        [Display(Name = "Model", ResourceType = typeof(Resources.AircraftRes))]
        public string Model { get; set; }

        [Display(Name = "Brand", ResourceType = typeof(Resources.AircraftRes))]
        public string Brand { get; set; }

        [Display(Name = "YearOfBuild", ResourceType = typeof(Resources.AircraftRes))]
        public int YearOfBuild { get; set; }

        [Display(Name = "EconomyClassSeats", ResourceType = typeof(Resources.AircraftRes))]
        public int EconomyClassSeats { get; set; }

        [Display(Name = "BusinessClassSeats", ResourceType = typeof(Resources.AircraftRes))]
        public int? BusinessClassSeats { get; set; }

        [Display(Name = "FirstClassSeats", ResourceType = typeof(Resources.AircraftRes))]
        public int? FirstClassSeats { get; set; }

        [Display(Name = "MaxFlightRange", ResourceType = typeof(Resources.AircraftRes))]
        public int MaxFlightRange { get; set; }

        public string Picture { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
