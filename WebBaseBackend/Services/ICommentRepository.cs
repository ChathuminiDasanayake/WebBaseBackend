using WebBaseBackend.Entities;

namespace WebBaseBackend.Services
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
    }
}
