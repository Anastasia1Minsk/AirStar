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
                Length(5,50).
                WithMessage("Please fill out the Password field");
            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .Equal(x => x.Password)
                .Length(5, 50)
                .WithMessage("Please fill out the Confirm password field");
        }
    }
}
