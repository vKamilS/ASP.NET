using Core.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class BlogPostService
    {
        public IDataDbContext DbContext { get; set; }
        public BlogPostService(IDataDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<BlogPostModel[]> GetAllModels()
        {
            
            
            return await  DbContext.BlogPosts.Select(x => new BlogPostModel()
            {
                BlogPostId = x.BlogPostId,
                Title = x.Title,
                Content = x.Content,
                Author  = x.User.Name,
             
            }).ToArrayAsync();

        }

    }
}
