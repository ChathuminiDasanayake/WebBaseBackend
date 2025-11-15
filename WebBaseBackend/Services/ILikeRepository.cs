using WebBaseBackend.Entities;

namespace WebBaseBackend.Services
{
    public interface ILikeRepository
    {
        Task AddLikeAsync(Like like);
    }
}
