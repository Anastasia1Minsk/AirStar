using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Please fill out the Name field")
                .Length(2, 50)
                .WithMessage("Lenght should be between 2 to 50")
                .Matches(@"^[a-zA-Z -]*$")
                .WithMessage("Name shouldn't contain special characters");
        }
    }
}
