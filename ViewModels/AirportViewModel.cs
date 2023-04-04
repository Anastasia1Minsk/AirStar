using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class AirportViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Code IATA")]
        public string Code_IATA { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        [Display(Name = "Time zone")]
        public string TimeZone { get; set; }
    }
}
