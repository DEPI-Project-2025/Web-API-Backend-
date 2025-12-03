using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.DAL.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }

        public decimal Amount { get; set; }      
        public DateTimeOffset PaymentDate { get; set; }
        public string StripeTransactionId { get; set; }
        public string Status { get; set; }       

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

       
        public Booking Booking { get; set; }
    }

}
