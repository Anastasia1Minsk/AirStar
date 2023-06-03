using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class FlightIndicatorsViewModel
    {
        [Display(Name = "Load factor")]
        public decimal LoadFactor { get; set; }//коэффициент загрузки бортов
        
        public List<string> Aircrafts { get; set; }


        public decimal EconomyPercent { get; set; }
        public decimal BusinessPercent { get; set; }
        public decimal FirstPercent { get; set; }

        public decimal EconomyLoadFactor { get; set; }
        public decimal BusinessLoadFactor { get; set; }
        public decimal FirstLoadFactor { get; set; }
    }
}
