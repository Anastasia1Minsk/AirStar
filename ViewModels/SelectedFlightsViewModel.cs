using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases;

namespace AirStar.ViewModels
{
    public class SelectedFlightsViewModel
    {
        public SearchViewModel SearchViewModel { get; set; }
        public PagedList<FlightViewModel> Flights { get; set; }
    }
}
