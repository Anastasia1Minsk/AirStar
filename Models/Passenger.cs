using AirStar.Models.Enums;

namespace AirStar.Models
{
    public class Passenger : BaseModel
    {
        public int ReservationID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public AgeСategories AgeStatus { get; set; }
        public bool Food { get; set; }
        public bool Luggage { get; set; }
        public bool Used { get; set; }

        public Reservation Reservation { get; set; }
    }
}
