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
            RuleFor(x => x.Email).NotEmpty().
                EmailAddress().
                WithMessage("Please fill out the Email field");
            RuleFor(x => x.Password).NotEmpty().
                Length(5,50)
                .Matches(@"(?= (.*[0 - 9]))(?=.*[a - z])(?= (.*[A - Z])).{ 5,}")
                .WithMessage("Please fill out the Password field. Password should contain numbers, upper case and lower case letters");
            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("Please fill out the Confirm password field");
        }
    }
}
