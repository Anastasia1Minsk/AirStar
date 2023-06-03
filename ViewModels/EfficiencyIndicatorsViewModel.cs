using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class EfficiencyIndicatorsViewModel
    {
        [Display(Name = "Passenger traffic")]
        public int PassengerTraffic { get; set; }//пассажиропоток
        [Display(Name = "Max possible passenger traffic")]
        public int PassengerTrafficMax { get; set; }

        [Display(Name = "Passenger turnover")]
        public int PassengerTurnover { get; set; }//пассажирооборот
        [Display(Name = "Max possible passenger turnover")]
        public int PassengerTurnoverMax { get; set; }
        public decimal PassengerTurnoverPercent => PassengerTurnover * 100 / PassengerTurnoverMax;

        [Display(Name = "Load factor")]
        public decimal LoadFactor => PassengerTraffic * 100 / PassengerTrafficMax;//коэффициент загрузки бортов

        [Display(Name = "Part passenger traffic")]
        public decimal PartPassengerTraffic { get; set; }//доля пассажиропотока отн всех маршрутов

        [Display(Name = "Proportion of reservated and unused seats")]
        public decimal UnusedProportion { get; set; }//соотношение бронирования и реального полета(сколько % не пришли)

        [Display(Name = "Tonnage")]
        public ulong Tonnage { get; set; }//тоннометраж
        [Display(Name = "Max possible tonnage")]
        public ulong TonnageMax { get; set; }
        public decimal TonnagePercent => Tonnage * 100 / TonnageMax;

        [Display(Name = "Option luggage")]
        public bool Luggage { get; set; }
        [Display(Name = "Option food")]
        public bool Food { get; set; }
        [Display(Name = "Business and first classes")]
        public bool BusinessAndFirstClasses { get; set; }

        [Display(Name = "Flight duration more then 6 hours")]
        public bool LongDuration{ get; set; }
        [Display(Name = "Arrival airport is hub")]
        public bool ToHub { get; set; }

        public int Score { get; set; }//итого баллов
        [Display(Name = "Max possible score")]
        public int ScoreMax { get; set; }
        public decimal ScorePercent => Score * ScoreMax / 100;
    }
}
