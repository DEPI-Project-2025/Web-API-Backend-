using BokifyGrad.BLL.DTOs.Rooms;
using BokifyGrad.BLL.Services.Interfaces;
using BokifyGrad.DAL;
using BokifyGrad.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly AppDBContext _context;

        public RoomService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            return await _context.Rooms
                .Include(r => r.RoomType)
                .Select(r => new RoomDto
                {
                    RoomId = r.RoomId,
                    RoomNumber = r.RoomNumber,
                    RoomTypeId = r.RoomTypeId,
                    RoomTypeName = r.RoomType.Name,
                    Status = r.Status,
                    Floor = r.Floor
                }).ToListAsync();
        }

        public async Task<RoomDto> GetByIdAsync(int roomId)
        {
            var r = await _context.Rooms
                .Include(x => x.RoomType)
                .FirstOrDefaultAsync(x => x.RoomId == roomId);

            if (r == null) return null;

            return new RoomDto
            {
                RoomId = r.RoomId,
                RoomNumber = r.RoomNumber,
                RoomTypeId = r.RoomTypeId,
                RoomTypeName = r.RoomType.Name,
                Status = r.Status,
                Floor = r.Floor
            };
        }

        public async Task<int> CreateAsync(CreateRoomDto dto, string adminId)
        {
            var room = new Room
            {
                RoomNumber = dto.RoomNumber,
                RoomTypeId = dto.RoomTypeId,
                Floor = dto.Floor,
                Notes = dto.Notes,
                Status = "Available",
                AdminId = adminId,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room.RoomId;
        }

        public async Task<bool> UpdateAsync(int roomId, UpdateRoomDto dto)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null) return false;

            room.RoomNumber = dto.RoomNumber;
            room.RoomTypeId = dto.RoomTypeId;
            room.Floor = dto.Floor;
            room.Notes = dto.Notes;
            room.Status = dto.Status;
            room.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null) return false;

            room.IsDeleted = true;
            room.UpdatedAt = DateTimeOffset.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsAvailableAsync(int roomId, DateOnly from, DateOnly to)
        {
            DateTime fromDate = from.ToDateTime(TimeOnly.MinValue);
            DateTime toDate = to.ToDateTime(TimeOnly.MinValue);

            return !await _context.Bookings.AnyAsync(b =>
                b.RoomId == roomId &&
                b.Status != "Cancelled" &&
                fromDate < b.CheckOutDate &&
                toDate > b.CheckInDate
            );
        }

    }

}
