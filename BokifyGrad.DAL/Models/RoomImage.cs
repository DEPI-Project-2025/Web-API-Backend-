using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.DAL.Models
{
    public class RoomImage
    {
        public int RoomImageId { get; set; }
        public int RoomId { get; set; }
        public string Url { get; set; }          
        public string AltText { get; set; }       
        public bool IsPrimary { get; set; }
        public string Status { get; set; }       

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public Room Room { get; set; }
    }

}
