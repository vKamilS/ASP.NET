using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BlogPostsController : Controller
    {
        public BlogPostService BlogPostService { get; set; }
        public BlogPostsController(BlogPostService blogPostService)
        {
            BlogPostService = blogPostService;
        }
        public async Task<IActionResult> Index()
        {
            var blogPosts = await BlogPostService.GetAllModels();
            return View(blogPosts);
        }

        public async Task<IActionResult> AddPostSite()
        {
            return View();
        }
    }
}

