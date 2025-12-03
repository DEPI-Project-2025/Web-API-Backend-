using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.DTOs.Rooms
{

    public class UpdateRoomDto : CreateRoomDto
    {
        public string Status { get; set; }
    }
}
