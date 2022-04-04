using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models.Enums;

namespace AirStar.Models
{
    public class Rate : BaseModel
    {
        public int FlightID { get; set; }
        public RateTypes RateType { get; set; }
        /*public  Rate { get; set; }*/
    }
}
