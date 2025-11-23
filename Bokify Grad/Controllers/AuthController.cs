using BokifyGrad.BLL.Services;
using BokifyGrad.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BokifyGrad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // REGISTER ENDPOINT
        [HttpPost("register")]
        public async Task<IActionResult> Register(string fullName, string email, string password)
        {
            var user = new ApplicationUser
            {
                FullName = fullName,
                Email = email,
                UserName = email
            };

            var result = await _authService.Register(user, password);

            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(e => e.Description));

            return Ok("User registered successfully");
        }

        // LOGIN ENDPOINT
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var token = await _authService.Login(email, password);
            if (token == null)
                return Unauthorized("Invalid login");

            return Ok(new { token });
        }
    }
}
