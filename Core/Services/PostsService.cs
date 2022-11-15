using Core.Models;
using KLearn.DataAccess;
using KLearn.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
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

        public async Task<PostModel[]> GetModels(int? page = null, string? search = null, ApplicationUser? user = null)
        {
            IQueryable<Post> filteredPostsDataBase = BlogPostsDbContext.Posts.OrderByDescending(x => x.Created);

            if(user != null)
            {
                filteredPostsDataBase = filteredPostsDataBase.Where(x => x.Author == user.UserName);
            }
         
            
            if (!string.IsNullOrEmpty(search))
            {
                filteredPostsDataBase = filteredPostsDataBase.Where(x => x.Content.Contains(search));
                var filteredPostsDataBase1 = filteredPostsDataBase.Where(x => x.Content.Contains(search));
            };
            
            var query = filteredPostsDataBase.Select(x => new PostModel()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Author = x.Author,
                Created = x.Created,
                CreatedAsString = x.Created.Value.ToString("MM/dd/yyyy hh:mm tt"),
                Edited = x.Edited,
                EditedAsString = x.Edited.Value.ToString("MM/dd/yyyy hh:mm tt"),
            });
            const int pageSize = 6;
            if (page != null)
                query = query.Skip(pageSize * (page.Value - 1));

            return await query.Take(pageSize).ToArrayAsync();
        }


        public async Task Save(PostModel model)
        {
            Post? entity = default;
            if (model.Id != null)
            {
                entity = await BlogPostsDbContext.Posts.FirstOrDefaultAsync(x => x.Id == model.Id);
            }

            if (entity == null)
            {
                entity = new Post();
                await BlogPostsDbContext.Posts.AddAsync(entity);
            }

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.Author = model.Author;
            entity.Created = model.Created;
            entity.Edited = model.Edited;

            var response = await BlogPostsDbContext.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            Post? entity = default;
            if (id != null)
            {
                entity = await BlogPostsDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            }

            
            if (entity != null)
            {
                BlogPostsDbContext.Posts.Remove(entity);
            }

            var response = await BlogPostsDbContext.SaveChangesAsync();
        }

        public async Task<PostModel> GetModelById(int id)
        {
            var entity = await BlogPostsDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            var model = new PostModel();
            if (entity == null)
                return model;
            model.Id = entity.Id;
            model.Title = entity.Title;
            model.Content = entity.Content; 
            model.Author = entity.Author;
            model.Created = entity.Created;
            model.Edited = entity.Edited;
            return model;
        }
    }
}
