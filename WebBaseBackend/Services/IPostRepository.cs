using WebBaseBackend.Entities;

namespace WebBaseBackend.Services
{
    public interface IPostRepository
    {
        Task AddPostAsync(Post post);
        Task<Post?> GetByPostIdAsync(int id);
    }
}
