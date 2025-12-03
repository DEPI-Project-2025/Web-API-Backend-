using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.DAL.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string Name { get; set; }          
        public string Description { get; set; }    
        public decimal BasePrice { get; set; }     

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        
        public ICollection<Room> Rooms { get; set; }
    }

}
