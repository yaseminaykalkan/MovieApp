using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities;
using MovieApp.Core.ViewModels;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        public LoginController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, true);

            if (result.Succeeded)
            {
                return new JsonResult(true);
            }

            return new JsonResult(false);
        }
    }
}
