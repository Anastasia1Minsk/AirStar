using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models
{
    public class Route : BaseModel
    {
        public string DepartureAirport_IATA { get; set; }
        public string ArrivalAirport_IATA { get; set; }
        public int Distance { get; set; }
    }
}
