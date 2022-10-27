using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public interface IDataDbContext
    {
        DbSet<BlogPost> BlogPosts { get; set; }
        DbSet<User> Users { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
    
    public partial class DataDbContext : IDataDbContext
    {
    
    }
}
