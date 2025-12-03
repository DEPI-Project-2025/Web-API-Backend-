using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.DAL.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public string Status { get; set; }        
        public int Floor { get; set; }
        public string Notes { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public string AdminId { get; set; }       
        public RoomType RoomType { get; set; }
        public ApplicationUser Admin { get; set; }
        public ICollection<RoomImage> Images { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }

}
