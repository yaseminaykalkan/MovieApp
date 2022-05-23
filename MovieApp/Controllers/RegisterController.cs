using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities;
using MovieApp.Core.ViewModels;
using MovieApp.Services.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public RegisterController( IMapper mapper, UserManager<User> userManager)
        {
           
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel userViewModel)
        {
            
           var user= _mapper.Map<User>(userViewModel);

            var result =await  _userManager.CreateAsync(user, userViewModel.Password);

            if (result.Succeeded)
            {
                return new JsonResult(new { succ = true});
            }
            else
            {
                return new JsonResult(new { succ = false, result= result.Errors });
            }
        }
    }

    
}
