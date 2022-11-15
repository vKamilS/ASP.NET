using Core.Services;
using KLearn.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Web;

namespace Web.Controllers
{
    
    public class UsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            IQueryable<UserDto>? usersModel = default;


            if (user == null)
            {
                usersModel = _userManager.Users.Select(x => new UserDto()
                {
                    UserName = x.UserName.Substring(0,1)+"...",
                    Email = "",
                    CreatedDate = x.Created.ToString("MM/dd/yyyy hh:mm tt"),
                    AvatarLink = x.AvatarLink,
                });
            }
            else
            {
                usersModel = _userManager.Users.Select(x => new UserDto()
                {
                    UserName = x.UserName,
                    Email = x.Email,
                    CreatedDate = x.Created.ToString("MM/dd/yyyy hh:mm tt"),
                    AvatarLink = x.AvatarLink,
                });
            }
           
           
            return View(usersModel);
        }

        [HttpGet]
        public async Task<IActionResult> SignIn()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateUserPage()
        {

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);
          
            if (user == null)
            {
                return Unauthorized();
            }
            var userDto = new CurrentUserDto
            {
                UserName = user.UserName,
                CreatedDate = user.Created,
                AvatarLink = user.AvatarLink,
            };
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            var newUser = new ApplicationUser
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Created = DateTime.Now,
                AvatarLink = userRegisterDto.AvatarLink,
                
            };
            var foundUser = await _userManager.FindByNameAsync(newUser.UserName);
            if (foundUser != null)
            {
                return NotFound("user exist");
            };

            try
            {
                var emailAdress = new MailAddress(newUser.Email);
            }
            catch
            {
                return NotFound("bad email");
            };
            
            var result = await _userManager.CreateAsync(newUser, userRegisterDto.Password);
            if (!result.Succeeded)
            {
                return NotFound();
            }

            if (_userManager.Users.Count() == 1)
            {
                var roleResult = await _userManager.AddToRoleAsync(newUser, "Administrator");
                if (!roleResult.Succeeded)
                {
                    return StatusCode(405);
                }
            }
            else
            {
                var roleResult = await _userManager.AddToRoleAsync(newUser, "Standard");
                if (!roleResult.Succeeded)
                {
                    return StatusCode(405);
                }
            };
            

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            await _userManager.ConfirmEmailAsync(newUser, token);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var foundUser = await _userManager.FindByNameAsync(userLoginDto.Login);
            if (foundUser == null)
            {
                return NotFound();
            }

            var result = await _signInManager.PasswordSignInAsync(foundUser, userLoginDto.Password, true, false);
            if (result.Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
           

            await _signInManager.SignOutAsync();
            
            return Ok();
           
        }
    }
}
