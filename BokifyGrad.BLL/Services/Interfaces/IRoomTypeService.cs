using BokifyGrad.BLL.DTOs.RoomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeDto>> GetAllAsync();
        Task<RoomTypeDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateRoomTypeDto dto);
        Task<bool> UpdateAsync(UpdateRoomTypeDto dto);
        Task<bool> SoftDeleteAsync(int id);
    }

}
