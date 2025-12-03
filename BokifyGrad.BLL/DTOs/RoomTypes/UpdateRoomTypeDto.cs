using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.DTOs.RoomTypes
{
    public class UpdateRoomTypeDto : CreateRoomTypeDto
    {
        public int RoomTypeId { get; set; }
    }
}
