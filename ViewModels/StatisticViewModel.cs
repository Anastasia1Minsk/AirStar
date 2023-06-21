using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class StatisticViewModel
    {
        public PeriodViewModel Period { get; set; }

        public bool ThreeMonthDuration = false;

        public DateTime? Month { get; set; }
        public string MonthText => Month.GetValueOrDefault().ToString("Y", CultureInfo.CreateSpecificCulture("en-US"));

        [Display(Name = "FlightCount", ResourceType = typeof(Resources.PredictionRes))]
        public int FlightCount { get; set; }

        [Display(Name = "RouteCount", ResourceType = typeof(Resources.PredictionRes))]
        public int RouteCount { get; set; }

        [Display(Name = "PassengerTraffic", ResourceType = typeof(Resources.PredictionRes))]
        public int PassengerTraffic { get; set; }

        [Display(Name = "PassengerTurnover", ResourceType = typeof(Resources.PredictionRes))]
        public int PassengerTurnover { get; set; }//пассажирооборот

        [Display(Name = "AverageRange", ResourceType = typeof(Resources.PredictionRes))]
        public decimal AverageRange { get; set; }//средняя дальность

        [Display(Name = "IncomeRate", ResourceType = typeof(Resources.PredictionRes))]
        public decimal IncomeRate { get; set; }//доходная ставка
    }
}
