using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class PassengerInformationViewModel
    {
        public FlightViewModel Flight { get; set; }
        public ReservationViewModel Reservation { get; set; }
    }
}
