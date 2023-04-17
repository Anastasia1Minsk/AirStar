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
            RuleFor(x => x.DepartureDate)
                .NotEmpty()
                .WithMessage("Please fill out the \"Departure date\" field")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Non-existing date");
            RuleFor(x => x.ArrivalDate)
                .NotEmpty()
                .WithMessage("Please fill out the \"Arrival date\" field")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Non-existing date")
                .GreaterThan(d => d.DepartureDate)
                .WithMessage("Less that \"Departure date\"?");
            /*RuleForEach(x => x.Rates).SetValidator(new RateValidator());*/

            /*RuleForEach(x => x.Rates)
                .ChildRules(x =>
                {
                    x.RuleFor(q => q.Price)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("qwerty");
                });*/
        }
    }
}
