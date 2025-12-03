using BokifyGrad.BLL.DTOs.RoomTypes;
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
    public class RoomTypeService : IRoomTypeService
    {
        private readonly AppDBContext _context;

        public RoomTypeService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomTypeDto>> GetAllAsync()
        {
            return await _context.RoomTypes
                .Select(t => new RoomTypeDto
                {
                    RoomTypeId = t.RoomTypeId,
                    Name = t.Name,
                    Description = t.Description,
                    BasePrice = t.BasePrice
                }).ToListAsync();
        }

        public async Task<RoomTypeDto> GetByIdAsync(int id)
        {
            var type = await _context.RoomTypes.FindAsync(id);
            if (type == null) return null;

            return new RoomTypeDto
            {
                RoomTypeId = type.RoomTypeId,
                Name = type.Name,
                Description = type.Description,
                BasePrice = type.BasePrice
            };
        }

        public async Task<int> CreateAsync(CreateRoomTypeDto dto)
        {
            var type = new RoomType
            {
                Name = dto.Name,
                Description = dto.Description,
                BasePrice = dto.BasePrice,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _context.RoomTypes.Add(type);
            await _context.SaveChangesAsync();
            return type.RoomTypeId;
        }

        public async Task<bool> UpdateAsync(UpdateRoomTypeDto dto)
        {
            var type = await _context.RoomTypes.FindAsync(dto.RoomTypeId);
            if (type == null) return false;

            type.Name = dto.Name;
            type.Description = dto.Description;
            type.BasePrice = dto.BasePrice;
            type.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var type = await _context.RoomTypes.FindAsync(id);
            if (type == null) return false;

            type.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
