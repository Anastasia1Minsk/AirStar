using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class RegistrationValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Please fill out the Email field")
                .EmailAddress()
                .WithMessage("Please fill out the Email field correctly");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Please fill out the Password field")
                .Length(5,50)
                .WithMessage("Lenght should be between 5 to 50 symbols")
                .Matches(@"(?=(.*[0-9]))(?=.*[a-z])(?=(.*[A-Z])).{5,}")
                .WithMessage("Password should contain numbers, upper case and lower case letters");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Please fill out the Confirm Password field")
                .Equal(x => x.Password)
                .WithMessage("Please fill out the Confirm password field correctly");
        }
    }
}
