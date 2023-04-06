using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using FluentValidation;

namespace AirStar.Validations
{
    public class RouteValidator : AbstractValidator<Route>
    {
        public RouteValidator()
        {
            RuleFor(x => x.DepartureAirport_ID)
                .NotEmpty()
                .WithMessage("Please fill out the \"Departure airport\" field");
            RuleFor(x => x.ArrivalAirport_ID)
                .NotEmpty()
                .WithMessage("Please fill out the \"Arrival airport\" field");
            RuleFor(x => x.Distance)
                .NotEmpty()
                .WithMessage("Please fill out the \"Distance\" field")
                .GreaterThan(0)
                .WithMessage("The \"Distance\" will be positive number");


        }
    }
}
