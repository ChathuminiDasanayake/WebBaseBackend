using WebBaseBackend.Entities;
using WebBaseBackend.Models;

namespace WebBaseBackend.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string?> LoginAsync(UserDto request);
    }
}
