using AutoMapper;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, GetMoviesModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName)).ForMember(x => x.Director, y => y.MapFrom(z => z.Director.Name + " " + z.Director.Surname));
            CreateMap<Movie, GetMovieDetailModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName)).ForMember(x => x.Director, y => y.MapFrom(z => z.Director.Name + " " + z.Director.Surname));


        }
    }
}