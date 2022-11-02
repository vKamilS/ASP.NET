using KLearn.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KLearn.DataAccess
{
    public interface IBlogPostsDbContext
    {
        DbSet<Post> Posts {get; set;}

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

    }

    public partial class BlogPostsDbContext : IBlogPostsDbContext
    {

    }
}
