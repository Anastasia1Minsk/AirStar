using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models
{
    public class Airport : BaseModel
    {
        [Display(Name = "code IATA")]
        public string Code_IATA { get; set; }
        public int CountryID { get; set; }
        public string City { get; set; }
        public int TimeZone { get; set; }

        public Country Country { get; set; }
        public ICollection<Route> DepartureRoutes { get; set; }
        public ICollection<Route> ArrivalRoutes { get; set; }
    }
}
