using BokifyGrad.BLL.DTOs.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto> GetByIdAsync(int roomId);
        Task<int> CreateAsync(CreateRoomDto dto, string adminId);
        Task<bool> UpdateAsync(int roomId, UpdateRoomDto dto);
        Task<bool> SoftDeleteAsync(int roomId);
        Task<bool> IsAvailableAsync(int roomId, DateOnly from, DateOnly to);
    }

}
