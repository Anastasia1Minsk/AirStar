using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class RouteViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Departure airport (IATA)")]
        public string DepartureAirport_IATA { get; set; }

        [Display(Name = "City")]
        public string DepartureAirport_City { get; set; }

        [Display(Name = "Country")]
        public string DepartureAirport_Country { get; set; }

        [Display(Name = "TimeZone")]
        public string DepartureAirport_TimeZone { get; set; }


        [Display(Name = "Arrival airport (IATA)")]
        public string ArrivalAirport_IATA { get; set; }

        [Display(Name = "City")]
        public string ArrivalAirport_City { get; set; }

        [Display(Name = "Country")]
        public string ArrivalAirport_Country { get; set; }

        [Display(Name = "TimeZone")]
        public string ArrivalAirport_TimeZone { get; set; }

        public int Distance { get; set; }
    }
}
