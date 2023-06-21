using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirStar.ViewModels
{
    public class FlightViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Route", ResourceType = typeof(Resources.FlightRes))]
        public int RouteId { get; set; }

        [Display(Name = "DepartureAirport", ResourceType = typeof(Resources.FlightRes))]
        public string DepartureAirport { get; set; }

        [Display(Name = "ArrivalAirport", ResourceType = typeof(Resources.FlightRes))]
        public string ArrivalAirport { get; set; }

        [Display(Name = "Aircraft", ResourceType = typeof(Resources.FlightRes))]
        public int AircraftId { get; set; }

        [Display(Name = "Aircraft", ResourceType = typeof(Resources.FlightRes))]
        public string Aircraft { get; set; }

        [Display(Name = "Distance", ResourceType = typeof(Resources.FlightRes))]
        public int Distance { get; set; }

        [Display(Name = "DepartureDate", ResourceType = typeof(Resources.FlightRes))]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "ArrivalDate", ResourceType = typeof(Resources.FlightRes))]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Food", ResourceType = typeof(Resources.FlightRes))]
        public bool Food { get; set; }

        [Display(Name = "Luggage", ResourceType = typeof(Resources.FlightRes))]
        public bool Luggage { get; set; }

        [Display(Name = "Canceled", ResourceType = typeof(Resources.FlightRes))]
        public bool Canceled { get; set; }

        [Display(Name = "Duration", ResourceType = typeof(Resources.FlightRes))]
        public TimeSpan Duration => ArrivalDate - DepartureDate;


        public List<RateViewModel> Rates { get; set; }

    }
}
