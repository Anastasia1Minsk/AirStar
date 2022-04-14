using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class LogInValidator : AbstractValidator<LogInViewModel>
    {
        public LogInValidator()
        {
            RuleFor(x => x.Email).NotEmpty().
                EmailAddress().
                WithMessage("Please fill out the Email field");
            RuleFor(x => x.Password).NotEmpty().
                WithMessage("Please fill out the Password field");
        }
    }
}
