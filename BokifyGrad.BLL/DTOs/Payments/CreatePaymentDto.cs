using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.DTOs.Payments
{
    public class CreatePaymentDto
    {
        public int BookingId { get; set; }
        public string StripeTransactionId { get; set; }
    }

}
