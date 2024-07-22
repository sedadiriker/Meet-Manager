using Microsoft.AspNetCore.Mvc;
using Meet_Manager.Models;
using Meet_Manager.Data;
using System.Linq;

namespace Meet_Manager.src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/auth/register
        [HttpPost("register")]
public IActionResult Register([FromForm] User user, [FromForm] IFormFile profilePicture)
{
    if (_context.Users.Any(u => u.Email == user.Email))
    {
        return BadRequest("User already exists");
    }

    if (profilePicture != null && profilePicture.Length > 0)
    {
        // Dosyayı saklama işlemi
        var filePath = Path.Combine("wwwroot/uploads", profilePicture.FileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            profilePicture.CopyTo(stream);
        }
        user.ProfilePicture = filePath; // Profil resminin yolunu kaydetme
    }

    _context.Users.Add(user);
    _context.SaveChanges();

    return CreatedAtAction(nameof(Login), new { email = user.Email }, user);
}


        // POST: api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = "dummy-token"; // Gerçek bir token oluşturma işlemi burada yapılır
            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
