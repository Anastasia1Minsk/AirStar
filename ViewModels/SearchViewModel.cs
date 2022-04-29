using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class SearchViewModel
    {
        public int DepartureCityID { get; set; }
        public int ArrivalCityID { get; set; }
        public int NumberOfPassengers { get; set; }
        public DateTime DepartureDate { get; set; }
}
}
