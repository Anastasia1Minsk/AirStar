using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models.Enums
{
    public enum RateTypes
    {
        [Description("Flight price for economy class passenger")]
        AdultEconomyFlight = 0,
        [Description("Flight price for business class passenger")]
        AdultBusinessFlight = 1,
        [Description("Flight price for first class passenger")]
        AdultFirstFlight = 2,

        /*[Description("Flight price for economy class passenger(child)")]
        ChildEconomyFlight = 3,
        [Description("Flight price for business class passenger(child)")]
        ChildBusinessFlight = 4,
        [Description("Flight price for first class passenger(child)")]
        ChildFirstFlight = 5,

        [Description("Flight price for economy class passenger(infant)")]
        InfantEconomyFlight = 6,
        [Description("Flight price for business class passenger(infant)")]
        InfantBusinessFlight = 7,
        [Description("Flight price for first class passenger(infant)")]
        InfantFirstFlight = 8,*/


        [Description("Cost of food")]
        Food = 9,
        [Description("Cost of luggage")]
        Luggage = 10
    }
}
