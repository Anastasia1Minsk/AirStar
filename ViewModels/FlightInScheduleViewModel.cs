using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class FlightInScheduleViewModel : FlightViewModel
    {
        public int? EconomySoldSeats { get; set; }
        public int? BusinessSoldSeats { get; set; }
        public int? FirstSoldSeats { get; set; }
        public int? MaxEconomySeats { get; set; }
        public int? MaxBusinessSeats { get; set; }
        public int? MaxFirstSeats { get; set; }

        public string DepartureTime => DepartureDate.ToString("t");
        public string DepartureDay => DepartureDate.ToString("MM.dd.yyyy");
        public string ArrivalTime => ArrivalDate.ToString("t");
        public string DurationTime => Duration.ToString("t");

    }
}
