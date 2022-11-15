using Core.Models;
using Core.Services;
using KLearn.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;
using Web.Models;

namespace Web.Controllers
{
    public class BlogPostsController : Controller
    {
        public PostsService PostsService { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;
        public BlogPostsController(PostsService postsService, UserManager<ApplicationUser> userManager)
        {
            PostsService = postsService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int? page, string? search)
        {
            var model = await PostsService.GetModels(page, search);

            foreach (var post in model)
            {
                post.Content = post.Content.Replace("\n", "<br/>");
            }

            var viewModel = new PostsSearchViewModel()
            {
                Model = model,
                Page = page ?? 1,
                Search = search ?? ""
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Administrator,Standard")]
        public async Task<IActionResult> AddPostSite()
        {
            var model = new PostModel();
            return View(model);
        }

        [Authorize(Roles = "Administrator,Standard")]
        [HttpGet]
        public async Task<IActionResult> MyPostsSite(int? page, string? search)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = await PostsService.GetModels(page, search, user);

            foreach (var post in model)
            {
                post.Content = post.Content.Replace("\n", "<br/>");
            }

            var viewModel = new PostsSearchViewModel()
            {
                Model = model,
                Page = page ?? 1,
                Search = search ?? ""
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Administrator,Standard")]
        [HttpPost]
        public async Task<IActionResult> SavePost([FromBody] PostModel model)
        {
            if (model.Created == null)
            {
                model.Created = DateTime.Now;
            }
            
            model.Edited = DateTime.Now;
            await PostsService.Save(model);
            return Ok();
        }

        [Authorize(Roles = "Administrator,Standard")]
        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
            await PostsService.DeletePost(id);
            return Ok();
            
        }


        //[Route("BlogPosts/EditPostSite/{id:int}")]
        public async Task<IActionResult> EditPostSite(int id)
        {
            PostModel model = await PostsService.GetModelById(id);

            return View(model);
        }
    }
}

