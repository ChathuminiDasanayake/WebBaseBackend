using WebBaseBackend.Data;
using WebBaseBackend.Entities;

namespace WebBaseBackend.Services
{
    public class LikeService(UserDbContext context) : ILikeRepository
    {
        public async Task AddLikeAsync(Like like)
        {
            context.Likes.Add(like);
            await context.SaveChangesAsync();
        }
    }
}
