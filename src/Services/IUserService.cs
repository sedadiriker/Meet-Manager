using System.Threading.Tasks;
using Meet_Manager.Models;

namespace Meet_Manager.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string email, string password);
    }
}
