using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
