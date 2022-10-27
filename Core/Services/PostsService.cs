using Core.Models;
using KLearn.DataAccess;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Services
{
    public class PostsService
    {
        public IBlogPostsDbContext BlogPostsDbContext { get; set; }

        public PostsService(IBlogPostsDbContext blogPostsDbContext)
        {
            BlogPostsDbContext = blogPostsDbContext;   
        }

        public async Task<PostModel[]> GetModels(int? page = null)
        {
            var filteredPostsDataBase = BlogPostsDbContext.Posts;

            //if (string.IsNullOrEmpty(search))
            //{
            //    filteredPostsDataBase = BlogPostsDbContext.Posts.Select(x => x.Content.Contains(search)) as DbSet<Post>;
            //}
           
            
            
            var query = filteredPostsDataBase.Select(x => new PostModel()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Author = x.Author,
                Created = x.Created,
            });
            const int pageSize = 6;
            if (page != null)
                query = query.Skip(pageSize * (page.Value - 1));

            return await query.Take(pageSize).ToArrayAsync();
        }
        public async Task Save(PostModel model)
        {

            var entity = await BlogPostsDbContext.Posts.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                entity = new Post();
                await BlogPostsDbContext.Posts.AddAsync(entity);
            }

            entity.Title = model.Title;
            entity.Content = model.Content;

            await BlogPostsDbContext.SaveChangesAsync();
        }

    }
}
