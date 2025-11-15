using Microsoft.Extensions.Hosting;
using WebBaseBackend.Data;
using WebBaseBackend.Entities;

namespace WebBaseBackend.Services
{
    public class CommentService(UserDbContext context) : ICommentRepository
    {
        public async Task AddCommentAsync(Comment comment)
        {
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
        }
    }
}
