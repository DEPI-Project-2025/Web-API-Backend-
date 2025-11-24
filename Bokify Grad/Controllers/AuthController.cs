using BokifyGrad.BLL.DTOs.Account;
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
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            var token = await _authService.GenerateResetPasswordToken(model.Email);

            if (token == null)
                return BadRequest("User not found");

            return Ok(new { ResetToken = token });
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var result = await _authService.ResetPassword(model.Email, model.Token, model.NewPassword);

            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(e => e.Description));

            return Ok("Password reset successfully");
        }


    }
}
