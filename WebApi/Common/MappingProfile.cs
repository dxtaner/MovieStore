using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Commands.UpdateActor;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.Application.BoughtMovieOperations.Commands.CreateBoughtMovie;
using WebApi.Application.BoughtMovieOperations.Commands.UpdateBoughtMovie;
using WebApi.Application.BoughtMovieOperations.Queries.GetBoughtMovieDetail;
using WebApi.Application.BoughtMovieOperations.Queries.GetBoughtMovies;
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
            CreateMap<Genre, GetGenreModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenreName)).ForMember(x => x.Name, y => y.MapFrom(z => z.GenreId + " " + z.GenreName));
            CreateMap<Genre, GenreDetailModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenreName)).ForMember(x => x.Name, y => y.MapFrom(z => z.GenreId + " " + z.GenreName));
            CreateMap<Genre, UpdateGenreModel>();
            CreateMap<Genre, CreateGenreModel>();
            CreateMap<Actor, GetActorsModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(x => x.Name, y => y.MapFrom(z => z.Name + " " + z.Surname + " " + z.PlayedMovies));
            CreateMap<Actor, ActorDetailModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(x => x.Name, y => y.MapFrom(z => z.Name + " " + z.Surname + " " + z.PlayedMovies));
            CreateMap<Actor, UpdateActorModel>();
            CreateMap<Actor, CreateActorModel>();
            CreateMap<Director, GetDirectorsModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(x => x.Name, y => y.MapFrom(z => z.Name + " " + z.Surname + " " + z.DirectedMovies));
            CreateMap<Director, UpdateDirectorModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(x => x.Name, y => y.MapFrom(z => z.Name + " " + z.Surname + " " + z.DirectedMovies));
            CreateMap<Director, DirectorDetailModel>();
            CreateMap<Director, CreateDirectorModel>();
            CreateMap<Customer, GetCustomersModel>().ForMember(dest => dest.BoughtFilms, opt => opt.MapFrom(src => src.BoughtFilms)).ForMember(x => x.BoughtFilms, y => y.MapFrom(z => z.Name + " " + z.Surname + "" + z.FavMovieGenre));
            CreateMap<Customer, CustomerDetailModel>().ForMember(dest => dest.BoughtFilms, opt => opt.MapFrom(src => src.BoughtFilms)).ForMember(x => x.BoughtFilms, y => y.MapFrom(z => z.Name + " " + z.Surname + " " + z.FavMovieGenre));
            CreateMap<Customer, UpdateCustomerModel>();
            CreateMap<Customer, CreateCustomerModel>();
            CreateMap<BoughtMovie, GetBoughtMoviesModel>().ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer)).ForMember(x => x.Customer, y => y.MapFrom(z => z.Movie + " " + z.Price + " " + z.BoughtMovieDate));
            CreateMap<BoughtMovie, BoughtMovieDetailModel>().ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer)).ForMember(x => x.Customer, y => y.MapFrom(z => z.Movie + " " + z.Price + " " + z.BoughtMovieDate));
            CreateMap<BoughtMovie, UpdateBoughtMovieModel>();
            CreateMap<BoughtMovie, CreateBoughtMovieModel>();




        }
    }
}