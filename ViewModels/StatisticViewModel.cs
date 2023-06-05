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

        [Display(Name = "Completed flights count")]
        public int FlightCount { get; set; }

        [Display(Name = "Route count")]
        public int RouteCount { get; set; }

        [Display(Name = "Passenger traffic")]
        public int PassengerTraffic { get; set; }

        [Display(Name = "Passenger turnover")]
        public int PassengerTurnover { get; set; }//пассажирооборот

        [Display(Name = "Average range")]
        public decimal AverageRange { get; set; }//средняя дальность

        [Display(Name = "Income rate")]
        public decimal IncomeRate { get; set; }//доходная ставка
    }
}
