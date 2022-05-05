using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;

namespace AirStar.ViewModels
{
    public class ReservationViewModel
    {
        public List<Passenger> Passengers { get; set; }
        public int NumberOfPassengers { get; set; }
        public int ClassId { get; set; }
    }
}
