using WebBaseBackend.Entities;
using WebBaseBackend.Models;

namespace WebBaseBackend.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokensAsync(RefershTokenRequestDto request);
    }
}
