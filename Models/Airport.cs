using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models
{
    public class Airport : BaseModel
    {
        public string Code_IATA { get; set; }
        public int CountyID { get; set; }
        public string City { get; set; }
        public int TimeZone { get; set; }

        public Country Country { get; set; }
        public ICollection<Route> Routes { get; set; }
    }
}
