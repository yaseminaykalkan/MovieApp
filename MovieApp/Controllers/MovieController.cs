using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.ViewModels;
using MovieApp.Services.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IRepository<Movie, int> _movieRepo;
        private readonly UserManager<User> _userManager;
        //private readonly IRepository<User, int> _userRepo;
        private readonly IMapper _mapper;
        public MovieController(IRepository<Movie, int> movieRepo, IMapper mapper, UserManager<User> userManager)
        {
            _movieRepo = movieRepo;
            //_userRepo = userRepo;
            _mapper = mapper;
            _userManager = userManager; 
        }

        [HttpGet]
        public IEnumerable<MovieViewModel> Get(string userName)
        {
            var data = _movieRepo.Get(x => x.User.UserName == userName && x.IsActive)
           .Include(x => x.User)
           .OrderByDescending(x => x.Name)
           .ToList()
           .Select(x => _mapper.Map<MovieViewModel>(x))
           .ToList();

            return data;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(MovieViewModel movieViewModel)
        {
            var data = _mapper.Map<Movie>(movieViewModel);

            var user = await  _userManager.FindByNameAsync(movieViewModel.UserName);

            data.User = user;

            var id = 0;

            var movie = _movieRepo.Get(x => x.MovieId == data.MovieId && x.User == data.User && x.IsActive).FirstOrDefault();

            if (movie == null)
            {
                 id = _movieRepo.Insert(data);
            }
            
            return new JsonResult(id);
        }

        [HttpGet, Route("RemoveFavorite")]
        public IActionResult RemoveFavorite(int movieId)
        {
            var movie= _movieRepo.GetById(movieId);

            var id = 0;
            if (movie != null)
            {
                 id = _movieRepo.Delete(movie);

                return new JsonResult(true);
            }
           
            return new JsonResult(false);
        }
    }
}
