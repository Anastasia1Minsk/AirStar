using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models
{
    public class Flight : BaseModel
    {
        public int AircraftID { get; set; }
        public int RouteID { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public bool Food { get; set; }
        public bool Luggage { get; set; }

        public Aircraft Aircraft { get; set; }
        public Route Route { get; set; }
        public ICollection<Rate> Rates { get; set; }
    }
}
