using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class AircraftValidator : AbstractValidator<AircraftViewModel>
    {
        public AircraftValidator()
        {
            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Please fill out the Model field")
                .Length(2, 50)
                .WithMessage("Lenght should be between 2 to 50")
                .Matches(@"^[a-zA-Z0-9 -]*$")
                .WithMessage("Model shouldn't contain special characters");
            RuleFor(x => x.Brand)
                .NotEmpty()
                .WithMessage("Please fill out the Brand field")
                .Length(2, 50)
                .WithMessage("Lenght should be between 2 to 50")
                .Matches(@"^[a-zA-Z ]*$")
                .WithMessage("Brand shouldn't contain special characters");
            RuleFor(x => x.YearOfBuild)
                .NotEmpty()
                .WithMessage("Please fill out the Brand field")
                .GreaterThan(2000)
                .WithMessage("Aircraft is too old")

                ;
        }
    }
}
