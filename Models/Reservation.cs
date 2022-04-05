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

        public ICollection<Passenger> Passengers { get; set; }
        public User User { get; set; }
        public ICollection<Price> Prices { get; set; }
    }
}
