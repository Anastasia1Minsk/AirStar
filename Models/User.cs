using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models.Enums;

namespace AirStar.Models
{
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleTypes RoleType { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
