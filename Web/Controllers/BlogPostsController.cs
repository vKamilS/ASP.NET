using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Web.Models;

namespace Web.Controllers
{
    public class BlogPostsController : Controller
    {
        public PostsService PostsService { get; set; }
        public BlogPostsController(PostsService postsService)
        {
            PostsService = postsService;
        }
        public async Task<IActionResult> Index(int? page)
        {
            var model = await PostsService.GetModels();
            var viewModel = new PostsSearchViewModel()
            {
                Model = model,
                Page = page ?? 1
            };
            return View(viewModel);
        }

        public async Task<IActionResult> AddPostSite()
        {
            var model = new PostModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostModel model)
        {
            await PostsService.Save(model);
            return Ok();
        }
    }
}

