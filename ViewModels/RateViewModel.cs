﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models.Enums;
using AirStar.Infrastructure.Extension;

namespace AirStar.ViewModels
{
    public class RateViewModel
    {
        public int Id { get; set; }


        public RateTypes RateType { get; set; }
        public decimal Price { get; set; }
        public string RateTypeName => EnumHelper.GetEnumDescription(RateType);
    }
}
