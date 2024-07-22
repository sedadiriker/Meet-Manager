using Microsoft.AspNetCore.Mvc;
using Meet_Manager.Models;
using System.Collections.Generic;

namespace Meet_Manager.src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // POST: api/auth/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            // Kullanıcı kaydı oluşturma kodu
            return CreatedAtAction(nameof(Login), new { email = user.Email }, user);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            // Kullanıcı girişi yapma kodu
            var token = "dummy-token"; // Örnek veri
            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
