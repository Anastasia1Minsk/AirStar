using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models
{
    public class Route : BaseModel
    {
        public int DepartureAirport_ID { get; set; }
        public int ArrivalAirport_ID { get; set; }
        public int Distance { get; set; }

        public ICollection<Flight> Flights { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
    }
}
