using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models.Enums;

namespace AirStar.ViewModels
{
    public class FlightViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Route")]
        public int RouteId { get; set; }

        [Display(Name = "Departure airport")]
        public string DepartureAirport { get; set; }

        [Display(Name = "Arrival airport")]
        public string ArrivalAirport { get; set; }

        [Display(Name = "Aircraft")]
        public int AircraftId { get; set; }
        public string Aircraft { get; set; }
        public int Distance { get; set; }

        [Display(Name = "Departure date")]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Arrival date")]
        public DateTime ArrivalDate { get; set; }
        public bool Food { get; set; }
        public bool Luggage { get; set; }

        public TimeSpan Duration => ArrivalDate - DepartureDate;


        public List<RatesViewModel> Rates { get; set; }

    }
}
