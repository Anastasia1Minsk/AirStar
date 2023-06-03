using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class MonetaryIndicatorsViewModel
    {
        [Display(Name = "Total profit")]
        public decimal Profit { get; set; }

        [Display(Name = "Max total profit")]
        public decimal ProfitMax { get; set; }

        [Display(Name = "Average fee")]
        public decimal AverageFee { get; set; }

        [Display(Name = "Average economy cost")]
        public decimal? AverageEconomyCost { get; set; }

        [Display(Name = "Average business cost")]
        public decimal? AverageBusinessCost { get; set; }

        [Display(Name = "Average first cost")]
        public decimal? AverageFirstCost { get; set; }
    }
}
