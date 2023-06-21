using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class FlightIndicatorsViewModel
    {
        [Display(Name = "LoadFactor", ResourceType = typeof(Resources.PredictionRes))]
        public decimal LoadFactor { get; set; }//коэффициент загрузки бортов

        [Display(Name = "Aircrafts", ResourceType = typeof(Resources.PredictionRes))]
        public List<string> Aircrafts { get; set; }

        [Display(Name = "EconomyPercent", ResourceType = typeof(Resources.PredictionRes))]
        public decimal EconomyPercent { get; set; }//доля пассажиров определенного класса отн всех забронированных билетов

        [Display(Name = "BusinessPercent", ResourceType = typeof(Resources.PredictionRes))]
        public decimal BusinessPercent { get; set; }

        [Display(Name = "FirstPercent", ResourceType = typeof(Resources.PredictionRes))]
        public decimal FirstPercent { get; set; }

        [Display(Name = "EconomyLoadFactor", ResourceType = typeof(Resources.PredictionRes))]
        public decimal EconomyLoadFactor { get; set; }//доля пассажиров определенного класса отн доступного количества мест в данном классе

        [Display(Name = "BusinessLoadFactor", ResourceType = typeof(Resources.PredictionRes))]
        public decimal BusinessLoadFactor { get; set; }

        [Display(Name = "FirstLoadFactor", ResourceType = typeof(Resources.PredictionRes))]
        public decimal FirstLoadFactor { get; set; }
    }
}
