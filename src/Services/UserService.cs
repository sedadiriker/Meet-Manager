using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Meet_Manager.Models;
using Meet_Manager.Data;

namespace Meet_Manager.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
