using BokifyGrad.BLL.DTOs.Payments;
using BokifyGrad.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bokify_Grad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("{bookingId}")]
        public async Task<IActionResult> Get(int bookingId)
        {
            var payment = await _service.GetByBookingId(bookingId);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Ok(new { paymentId = id });
        }
    }

}
