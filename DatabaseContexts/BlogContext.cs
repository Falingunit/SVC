using Microsoft.EntityFrameworkCore;
using SVC.Models;

namespace SVC.DatabaseContexts
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options): base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
