using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using AirStar.ViewModels;
using FluentValidation;
using Resources;

namespace AirStar.Validations
{
    public class AircraftValidator : AbstractValidator<AircraftViewModel>
    {
        public AircraftValidator()
        {
            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage(AircraftRes.ModelValidationEmpty)
                .Length(2, 50)
                .WithMessage(AircraftRes.ModelValidationLenght)
                .Matches(@"^[a-zA-Z0-9 -]*$")
                .WithMessage(AircraftRes.ModelValidationCharacters);
            RuleFor(x => x.Brand)
                .NotEmpty()
                .WithMessage(AircraftRes.BrandValidationEmpty)
                .Length(2, 50)
                .WithMessage(AircraftRes.BrandValidationLenght)
                .Matches(@"^[a-zA-Z ]*$")
                .WithMessage(AircraftRes.BrandValidationCharacters);
            RuleFor(x => x.YearOfBuild)
                .NotEmpty()
                .WithMessage(AircraftRes.YearOfBuildValidationEmpty)
                .GreaterThan(2000)
                .WithMessage(AircraftRes.YearOfBuiltValidationGreater)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage(AircraftRes.YearOfBuiltValidationLess);
            RuleFor(x => x.EconomyClassSeats)
                .NotEmpty()
                .WithMessage(AircraftRes.EconomyValidationEmpty)
                .GreaterThan(0)
                .WithMessage(AircraftRes.EconomyValidationGreater);
            RuleFor(x => x.BusinessClassSeats)
                .NotEmpty()
                .WithMessage(AircraftRes.BusinessValidationEmpty);
            RuleFor(x => x.FirstClassSeats)
                .NotEmpty()
                .WithMessage(AircraftRes.FirstValidationEmpty);
            RuleFor(x => x.MaxFlightRange)
                .NotEmpty()
                .WithMessage(AircraftRes.MaxFlightRangeValidationEmpty)
                .GreaterThan(0)
                .WithMessage(AircraftRes.MaxFlightRangeValidationGreater);
            RuleFor(x => x.PictureFile)
                .NotEmpty()
                .WithMessage(AircraftRes.PictureFileValidationEmpty);
        }
    }
}
