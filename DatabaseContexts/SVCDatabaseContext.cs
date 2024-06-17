using Microsoft.EntityFrameworkCore;
using SVC.Models;

namespace SVC.DatabaseContexts
{
    public class SVCDatabaseContext : DbContext
    {
        public SVCDatabaseContext(DbContextOptions<SVCDatabaseContext> options): base(options)
        {
        }

        public DbSet<HealthEducationPost> BlogPosts { get; set; }
    }
}
