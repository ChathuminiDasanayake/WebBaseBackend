using Microsoft.EntityFrameworkCore;
using WebBaseBackend.Entities;

namespace WebBaseBackend.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set;}
    }
}
