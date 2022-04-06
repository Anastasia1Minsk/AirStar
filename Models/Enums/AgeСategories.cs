using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Models.Enums
{
    public enum AgeСategories
    {
        [Description("Age: 12+")]
        Adult = 0,
        [Description("Age: 2- 12")]
        Children = 1,
        [Description("Age: 0-2")]
        Infant = 2
    }
}
