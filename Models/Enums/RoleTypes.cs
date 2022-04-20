using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models.Enums
{
    public enum RoleTypes
    {
        [Description("User with this role is a customer")]
        Customer = 0,
        [Description("User with this role is a admin")]
        Admin = 1
    }
}
