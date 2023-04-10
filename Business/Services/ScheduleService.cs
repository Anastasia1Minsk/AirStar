using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;

namespace AirStar.Business.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IFlightService _flightService;
        private readonly IRateService _rateService;

        public ScheduleService(IFlightService flightService, IRateService rateService)
        {
            _flightService = flightService;
            _rateService = rateService;
        }


    }
}
