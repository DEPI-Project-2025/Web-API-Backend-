using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.DAL.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string UserId { get; set; }       
        public int RoomId { get; set; }

        public int Rating { get; set; }          
        public string Comment { get; set; }       

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        
        public ApplicationUser User { get; set; }
        public Room Room { get; set; }
    }

}
