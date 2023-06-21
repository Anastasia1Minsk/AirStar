using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class PerfomanceIndicatorsViewModel
    {
        public List<FlightViewModel> Flights { get; set; }
        public EfficiencyIndicatorsViewModel EfficiencyIndicators {get; set; }
        public MonetaryIndicatorsViewModel MonetaryIndicators { get; set; }
        public FlightIndicatorsViewModel FlightIndicators { get; set; }
    }
}
