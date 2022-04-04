using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models
{
    public class Aircraft : BaseModel
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int YearOfBuild { get; set; }
        public int EconomyClassSeats { get; set; }
        public int BusinessClassSeats { get; set; }
        public int FirstClassSeats { get; set; }
        public int MaxFlightRange { get; set; }
    }
}
