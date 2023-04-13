using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class FlightValidator : AbstractValidator<FlightViewModel>
    {
        public FlightValidator()
        {
            RuleFor(x => x.RouteId)
                .NotEmpty()
                .WithMessage("Please fill out the \"Route\" field");
            RuleFor(x => x.AircraftId)
                .NotEmpty()
                .WithMessage("Please fill out the \"Aircraft\" field");
        }
    }
}
