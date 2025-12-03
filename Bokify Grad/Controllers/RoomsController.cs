using BokifyGrad.BLL.DTOs.Rooms;
using BokifyGrad.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bokify_Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomDto dto)
        {
            var adminId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id = await _roomService.CreateAsync(dto, adminId);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoomDto dto)
        {
            var ok = await _roomService.UpdateAsync(id, dto);
            if (!ok) return NotFound();
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _roomService.SoftDeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpGet("{id:int}/availability")]
        public async Task<IActionResult> CheckAvailability(int id, DateOnly from, DateOnly to)
        {
            var available = await _roomService.IsAvailableAsync(id, from, to);
            return Ok(new { roomId = id, available });
        }
    }

}
