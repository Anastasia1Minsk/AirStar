using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class MonetaryIndicatorsViewModel
    {
        [Display(Name = "Profit", ResourceType = typeof(Resources.PredictionRes))]
        public decimal Profit { get; set; }

        [Display(Name = "Max total profit")]
        public decimal ProfitMax { get; set; }

        [Display(Name = "AverageFee", ResourceType = typeof(Resources.PredictionRes))]
        public decimal AverageFee { get; set; }

        [Display(Name = "AverageEconomyCost", ResourceType = typeof(Resources.PredictionRes))]
        public decimal? AverageEconomyCost { get; set; }

        [Display(Name = "AverageBusinessCost", ResourceType = typeof(Resources.PredictionRes))]
        public decimal? AverageBusinessCost { get; set; }

        [Display(Name = "AverageFirstCost", ResourceType = typeof(Resources.PredictionRes))]
        public decimal? AverageFirstCost { get; set; }
    }
}
