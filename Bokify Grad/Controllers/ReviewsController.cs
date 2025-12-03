using BokifyGrad.BLL.DTOs.Reviews;
using BokifyGrad.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bokify_Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewsController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetForRoom(int roomId)
            => Ok(await _service.GetForRoom(roomId));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id = await _service.CreateAsync(userId, dto);
            return Ok(new { reviewId = id });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ok = await _service.DeleteAsync(id, userId);
            if (!ok) return BadRequest();
            return Ok("Review deleted");
        }
    }

}
