using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.DTOs.Rooms
{
    public class CreateRoomDto
    {
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public int Floor { get; set; }
        public string Notes { get; set; }
    }
}
