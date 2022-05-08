using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class PaymentValidator : AbstractValidator<PaymentViewModel>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.PersonName)
                .NotEmpty()
                .WithMessage("Please fill out the Person Name field")
                .Matches(@"^[A-Z]+ [A-Z]+$")
                .WithMessage("Person Name should contain 2 word (only capital letters ia possible)");
            RuleFor(x => x.CreditCardNumber)
                .NotEmpty()
                .WithMessage("Please fill out the Credit Card Number field")
                .Matches(@"\b[0-9]{16}\b")
                .WithMessage("Incorrect credit card number");
            RuleFor(x => x.CVV)
                .NotEmpty()
                .WithMessage("Please fill out the CVV/CVC field")
                .Matches(@"\b[0-9]{3}\b")
                .WithMessage("Incorrect CVV/CVC");
            RuleFor(x => x.ExpirationDateMonth)
                .NotEmpty()
                .WithMessage("Please fill out the Expiration Date Month field")
                .GreaterThan(0)
                .WithMessage("Incorrect month")
                .LessThan(13)
                .WithMessage("Incorrect month");
            RuleFor(x => x.ExpirationDateYear)
                .NotEmpty()
                .WithMessage("Please fill out the Expiration Date Year field")
                .GreaterThan(0)
                .WithMessage("Incorrect year")
                .LessThan(100)
                .WithMessage("Incorrect year");


            /*RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Please fill out the Password field")
                .Length(5, 50)
                .WithMessage("Lenght should be between 5 to 50")
                .Matches(@"(?=(.*[0-9]))(?=.*[a-z])(?=(.*[A-Z])).{5,}")
                .WithMessage("Password should contain numbers, upper case and lower case letters");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Please fill out the Password field")
                .Equal(x => x.Password)
                .WithMessage("Please fill out the Confirm password field correctly");*/
        }
    }
}
