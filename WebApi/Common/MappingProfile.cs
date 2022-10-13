using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Commands.UpdateActor;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Commands.UpdateCustomer;
using WebApi.Application.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.Application.CustomerOperations.Queries.GetCustomers;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
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
            CreateMap<Genre, GetGenreModel>();
            CreateMap<Genre, GenreDetailModel>();
            CreateMap<Genre, UpdateGenreModel>();
            CreateMap<Genre, CreateGenreModel>();
            CreateMap<Actor, GetActorsModel>();
            CreateMap<Actor, ActorDetailModel>();
            CreateMap<Actor, UpdateActorModel>();
            CreateMap<Actor, CreateActorModel>();
            CreateMap<Director, GetDirectorsModel>();
            CreateMap<Director, DirectorDetailModel>();
            CreateMap<Director, UpdateDirectorModel>();
            CreateMap<Director, CreateDirectorModel>();
            CreateMap<Customer, GetCustomersModel>().ForMember(dest => dest.BoughtFilms, opt => opt.MapFrom(src => src.BoughtFilms));
            CreateMap<Customer, CustomerDetailModel>();
            CreateMap<Customer, UpdateCustomerModel>();
            CreateMap<Customer, CreateCustomerModel>();





        }
    }
}