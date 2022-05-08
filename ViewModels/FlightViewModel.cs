using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models.Enums;

namespace AirStar.ViewModels
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public int Distance { get; set; }
        public string AircraftModel { get; set; }
        public string AircraftBrand { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        public TimeSpan Duration => ArrivalDate - DepartureDate;


        public List<RatesViewModel> Rates { get; set; }

    }
}
