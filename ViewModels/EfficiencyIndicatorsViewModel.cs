using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class EfficiencyIndicatorsViewModel
    {
        [Display(Name = "PassengerTraffic", ResourceType = typeof(Resources.PredictionRes))]
        public int PassengerTraffic { get; set; }//пассажиропоток
        
        public int PassengerTrafficMax { get; set; }//Max possible passenger traffic

        [Display(Name = "PassengerTurnover", ResourceType = typeof(Resources.PredictionRes))]
        public int PassengerTurnover { get; set; }//пассажирооборот
        
        public int PassengerTurnoverMax { get; set; }//Max possible passenger turnover
        public decimal PassengerTurnoverPercent => PassengerTurnover * 100 / PassengerTurnoverMax;

        [Display(Name = "LoadFactor", ResourceType = typeof(Resources.PredictionRes))]
        public decimal LoadFactor => PassengerTraffic * 100 / PassengerTrafficMax;//коэффициент загрузки бортов

        [Display(Name = "PartPassengerTraffic", ResourceType = typeof(Resources.PredictionRes))]
        public decimal PartPassengerTraffic { get; set; }//доля пассажиропотока отн всех маршрутов

        [Display(Name = "UnusedProportion", ResourceType = typeof(Resources.PredictionRes))]
        public decimal UnusedProportion { get; set; }//соотношение бронирования и реального полета(сколько % не пришли)

        [Display(Name = "Tonnage", ResourceType = typeof(Resources.PredictionRes))]
        public ulong Tonnage { get; set; }//тоннометраж
        [Display(Name = "Max possible tonnage")]
        public ulong TonnageMax { get; set; }
        public decimal TonnagePercent => Tonnage * 100 / TonnageMax;

        [Display(Name = "Luggage", ResourceType = typeof(Resources.PredictionRes))]
        public bool Luggage { get; set; }

        [Display(Name = "Food", ResourceType = typeof(Resources.PredictionRes))]
        public bool Food { get; set; }

        [Display(Name = "BusinessAndFirstClasses", ResourceType = typeof(Resources.PredictionRes))]
        public bool BusinessAndFirstClasses { get; set; }

        [Display(Name = "LongDuration", ResourceType = typeof(Resources.PredictionRes))]
        public bool LongDuration{ get; set; }

        [Display(Name = "ToHub", ResourceType = typeof(Resources.PredictionRes))]
        public bool ToHub { get; set; }

        [Display(Name = "Score", ResourceType = typeof(Resources.PredictionRes))]
        public int Score { get; set; }//итого баллов
        
        public int ScoreMax { get; set; }
        public decimal ScorePercent => Score * ScoreMax / 100;
    }
}
