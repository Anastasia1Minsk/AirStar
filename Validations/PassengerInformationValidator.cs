using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using AirStar.ViewModels;
using FluentValidation;

namespace AirStar.Validations
{
    public class PassengerInformationValidator : AbstractValidator<PassengerInformationViewModel>
    {
        public PassengerInformationValidator()
        {
            RuleFor(x => x.Reservation).SetValidator(new ReservationValidator());
        }
    }
}
