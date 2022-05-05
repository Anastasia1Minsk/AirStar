using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class PassengerValidator : AbstractValidator<Passenger>
    {
        public PassengerValidator()
        {
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Please fill out the Last Name field")
                .Length(2, 50)
                .WithMessage("Lenght should be between 2 to 50")
                .Matches(@"^[a-zA-Z-]*$")
                .WithMessage("Last Name shouldn't contain special characters");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Please fill out the First Name field")
                .Length(2, 50)
                .WithMessage("Lenght should be between 2 to 50")
                .Matches(@"^[a-zA-Z-]*$")
                .WithMessage("First Name shouldn't contain special characters");
            RuleFor(x => x.MiddleName)
                .Length(2, 50)
                .WithMessage("Lenght should be between 2 to 50")
                .Matches(@"^[a-zA-Z-]*$")
                .WithMessage("Middle Name shouldn't contain special characters");

        }
    }
}
