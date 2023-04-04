using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class AirportValidator : AbstractValidator<AirportViewModel>
    {
        public AirportValidator()
        {
            RuleFor(x => x.Code_IATA)
                .NotEmpty()
                .WithMessage("Please fill out the \"Code IATA\" field")
                .Length(3)
                .WithMessage("Lenght should be 3 symbol")
                .Matches(@"^[A-Z]*$")
                .WithMessage("\"Code IATA\" should contain capital letters only");
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("Please fill out the \"City\" field")
                .Length(2, 50)
                .WithMessage("Lenght should be between 2 to 50")
                .Matches(@"^[a-zA-Z -']*$")
                .WithMessage("Name shouldn't contain special characters");
            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage("Please fill out the \"Country\" field");
            RuleFor(x => x.TimeZone)
                .NotEmpty()
                .WithMessage("Please fill out the \"Time zone\" field")
                .Matches(@"^[-+](1[0-2]|[0-9])$")
                .WithMessage("\"Time zone\" field value should be between -12 to +12");
        }
    }
}
