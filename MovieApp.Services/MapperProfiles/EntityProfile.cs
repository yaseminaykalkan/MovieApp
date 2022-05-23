using AutoMapper;
using MovieApp.Core.Entities;
using MovieApp.Core.ViewModels;

namespace MovieApp.Services.MapperProfiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(cat => cat.UserName));
               

            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(dest => dest.Movies, opt => opt.Ignore());

            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x =>  x.User.UserName));

            CreateMap<MovieViewModel, Movie>()
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}