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

        public async Task<BlogPostModel[]> GetModels( int? page=null)
        {
            var query = DbContext.BlogPosts.Select(x => new BlogPostModel()
            {
                BlogPostId = x.BlogPostId,
                Title = x.Title,
                Content = x.Content,
                Author = x.User.Name,

            });
            const int pageSize = 6;

            if (page != null)
                query = query.Skip(pageSize * (page.Value-1));

            return await query.Take(pageSize).ToArrayAsync();

        }

        public async Task Save(BlogPostModel model)
        {
            
            var entity = await DbContext.BlogPosts.FirstOrDefaultAsync(x => x.BlogPostId == model.BlogPostId);

            if(entity == null)
            {
                entity = new DataAccess.Models.BlogPost();
                await DbContext.BlogPosts.AddAsync(entity);
            }

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.UserId = 2;

            await DbContext.SaveChangesAsync();
        }

    }
}
