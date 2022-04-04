using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models.Enums;

namespace AirStar.Models
{
    public class Price : BaseModel
    {
        public int ReservationID { get; set; }
        public RateTypes RateType { get; set; }
        /*public  Cost { get; set; }*/
        public int Amount { get; set; }
    }
}
