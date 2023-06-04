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

        [Display(Name = "Percent of economy class passengers")]
        public decimal EconomyPercent { get; set; }//доля пассажиров определенного класса отн всех забронированных билетов
        
        [Display(Name = "Percent of business class passengers")]
        public decimal BusinessPercent { get; set; }
        
        [Display(Name = "Percent of first class passengers")]
        public decimal FirstPercent { get; set; }

        [Display(Name = "Economy class load factor")]
        public decimal EconomyLoadFactor { get; set; }//доля пассажиров определенного класса отн доступного количества мест в данном классе

        [Display(Name = "Business class load factor")]
        public decimal BusinessLoadFactor { get; set; }

        [Display(Name = "First class load factor")]
        public decimal FirstLoadFactor { get; set; }
    }
}
