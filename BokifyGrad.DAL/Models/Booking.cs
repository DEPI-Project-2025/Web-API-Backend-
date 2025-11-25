using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.DAL.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public string UserId { get; set; }   
        public int RoomId { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public decimal TotalPrice { get; set; }  
        public string Status { get; set; }      

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation
        public ApplicationUser User { get; set; }
        public Room Room { get; set; }
        public Payment Payment { get; set; }
    }

}
