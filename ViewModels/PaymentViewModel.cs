using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.ViewModels
{
    public class PaymentViewModel
    {
        public int ReservationId { get; set; }
        public string PersonName { get; set; }
        public string CreditCardNumber { get; set; }
        public string CVV { get; set; }
        public int ExpirationDateMonth { get; set; }
        public int ExpirationDateYear { get; set; }
        public decimal TotalCost { get; set; }
    }
}
