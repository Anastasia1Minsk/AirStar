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
                .WithMessage("Please fill out the \"Model\" field")
                .Length(2, 50)
                .WithMessage("Lenght should be between 2 to 50")
                .Matches(@"^[a-zA-Z0-9 -]*$")
                .WithMessage("\"Model\" shouldn't contain special characters");
            RuleFor(x => x.Brand)
                .NotEmpty()
                .WithMessage("Please fill out the \"Brand\" field")
                .Length(2, 50)
                .WithMessage("Lenght should be between 2 to 50")
                .Matches(@"^[a-zA-Z ]*$")
                .WithMessage("\"Brand\" shouldn't contain special characters");
            RuleFor(x => x.YearOfBuild)
                .NotEmpty()
                .WithMessage("Please fill out the \"Year of build\" field")
                .GreaterThan(2000)
                .WithMessage("Aircraft is too old")
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Non-existing date");
            RuleFor(x => x.EconomyClassSeats)
                .NotEmpty()
                .WithMessage("Please fill out the \"Economy class seats\" field")
                .GreaterThan(0)
                .WithMessage("Impossible to create such aircraft");
            RuleFor(x => x.BusinessClassSeats)
                .NotEmpty()
                .WithMessage("Please fill out the \"Business class seats\" field");
            RuleFor(x => x.FirstClassSeats)
                .NotEmpty()
                .WithMessage("Please fill out the \"First class seats\" field");
            RuleFor(x => x.MaxFlightRange)
                .NotEmpty()
                .WithMessage("Please fill out the \"Maximum flight range\" field")
                .GreaterThan(0)
                .WithMessage("Impossible to create such aircraft");
            RuleFor(x => x.PictureFile)
                .NotEmpty()
                .WithMessage("Please fill out the \"Picture\" field");
        }
    }
}
