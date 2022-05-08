using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class SearchValidator : AbstractValidator<SearchViewModel>
    {
        public SearchValidator()
        {
            RuleFor(x => x.DepartureAirportID)
                .NotEmpty()
                .WithMessage("Please fill out the Departure City field");
            RuleFor(x => x.ArrivalAirportID)
                .NotEmpty()
                .WithMessage("Please fill out the Arrival City field");
            RuleFor(x => x.NumberOfPassengers)
                .NotEmpty()
                .WithMessage("Please fill out the Number Of Passengers field")
                .GreaterThan(0)
                .WithMessage("How many people will flight?")
                .LessThan(11)
                .WithMessage("You can book for a maximum of 10 passengers");
            RuleFor(x => x.DepartureDate)
                .NotEmpty()
                .WithMessage("Please fill out the Departure Date field")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Non-existing date"); 
        }
    }
}
