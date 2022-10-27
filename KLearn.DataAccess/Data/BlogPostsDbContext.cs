using Microsoft.EntityFrameworkCore;

namespace KLearn.DataAccess
{
    public partial class BlogPostsDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public BlogPostsDbContext(DbContextOptions<BlogPostsDbContext> options) : base(options)
        {

        }
        
    }
}