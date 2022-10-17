using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        public UserService UserService { get; set; }
        public UsersController(UserService userService)
        {
            UserService = userService;
        }
    
        public async Task<IActionResult> Index()
        {
            var users = await UserService.GetAllUsers();
            return View(users);
        }
    }
}
