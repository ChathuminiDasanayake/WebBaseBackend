using Microsoft.EntityFrameworkCore;
using WebBaseBackend.Data;
using WebBaseBackend.Entities;

namespace WebBaseBackend.Services
{
    public class PostService(UserDbContext context) : IPostRepository
    {
        public async Task AddPostAsync(Post post)
        {
            context.Posts.Add(post);
            await context.SaveChangesAsync();
        }

        public Task DeletePostAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Post?> GetByPostIdAsync(int id)
        {
             return await context.Posts
            .Include(p => p.Comments)
            .Include(p => p.Likes)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdatePostAsync(Post post)
        {
            context.Posts.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
