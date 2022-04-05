using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models.Enums
{
    public enum RateTypes
    {
        [Description("Cost ot flight")]
        Flight = 0,
        [Description("Cost ot food")]
        Food = 1,
        [Description("Cost ot luggage")]
        Luggage = 2
    }
}
