using WebBaseBackend.Entities;

namespace WebBaseBackend.Services
{
    public interface IPostRepository
    {
        Task AddPostAsync(Post post);
        Task<Post?> GetByPostIdAsync(int id);
        Task UpdatePostAsync(Post post);

        Task DeletePostAsync(int postId);
    }
}
