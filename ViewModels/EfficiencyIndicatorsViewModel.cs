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
        public double PassengerTrafficPercent => PassengerTraffic * 100 / PassengerTrafficMax;

        [Display(Name = "Passenger turnover")]
        public int PassengerTurnover { get; set; }//пассажирооборот
        [Display(Name = "Max possible passenger turnover")]
        public int PassengerTurnoverMax { get; set; }
        public double PassengerTurnoverPercent => PassengerTurnover * 100 / PassengerTurnoverMax;

        [Display(Name = "Load factor")]
        public double LoadFactor { get; set; }//коэффициент загрузки бортов
        [Display(Name = "Max possible load factor")]
        public int LoadFactorMax { get; set; }

        public double LoadFactorPercent => LoadFactor * 100 / LoadFactorMax;

        [Display(Name = "Part passenger traffic")]
        public double PartPassengerTraffic { get; set; }//доля пассажиропотока отн всех маршрутов

        [Display(Name = "Proportion of reservated and unused seats")]
        public double UnusedProportion { get; set; }//соотношение бронирования и реального полета(сколько % не пришли)

        [Display(Name = "Tonnage")]
        public ulong Tonnage { get; set; }//тоннометраж
        [Display(Name = "Max possible tonnage")]
        public ulong TonnageMax { get; set; }
        public double TonnagePercent => Tonnage * 100 / TonnageMax;

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
        public double ScorePercent => Score * ScoreMax / 100;
    }
}
