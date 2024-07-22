using System.Threading.Tasks;
using Meet_Manager.Models;

namespace Meet_Manager.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
