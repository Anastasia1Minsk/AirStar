using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class PeriodViewModel
    {
        public DateTime StartThreeMonthPeriod { get; set; }
        public DateTime StartFirstMonth => StartThreeMonthPeriod;
        //public string FirstMonth => StartFirstMonth.Month.ToString("Y", CultureInfo.CreateSpecificCulture("en-US"));
        public DateTime StartSecondMonth => StartThreeMonthPeriod.AddMonths(1);
        //public string SecondMonth => StartSecondMonth.Month.ToString("Y", CultureInfo.CreateSpecificCulture("en-US"));
        public DateTime StartThirdMonth => StartThreeMonthPeriod.AddMonths(2);
        //public string ThirdMonth => StartThirdMonth.Month.ToString("Y", CultureInfo.CreateSpecificCulture("en-US"));
        public List<string> Months => AddMonth();
        public string ThreeMonths { get; set; }

        private List<string> AddMonth()
        {
            //var culture = CultureInfo.CreateSpecificCulture("en-US");
            
            var list = new List<string>();
            /*list.Add(StartThreeMonthPeriod.Month.ToString("Y", culture));
            list.Add(StartThreeMonthPeriod.AddMonths(1).Month.ToString("Y", culture));
            list.Add(StartThreeMonthPeriod.AddMonths(2).Month.ToString("Y", culture));*/

            list.Add(StartThreeMonthPeriod.Month.ToString("Y"));
            list.Add(StartThreeMonthPeriod.AddMonths(1).Month.ToString("Y"));
            list.Add(StartThreeMonthPeriod.AddMonths(2).Month.ToString("Y"));
            return list;
        }
    }
}
