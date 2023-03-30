using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class AirportViewModel
    {
        public int Id { get; set; }
        public string Code_IATA { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string TimeZone { get; set; }
    }
}
