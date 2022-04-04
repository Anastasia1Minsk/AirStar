using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models
{
    public class Reservation : BaseModel
    {
        public int UserID { get; set; }
        public int FlightID { get; set; }
        public bool Paid { get; set; }
    }
}
