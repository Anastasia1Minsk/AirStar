using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class RateValidator : AbstractValidator<RateViewModel>
    {
        public RateValidator()
        {

        }
    }
}
