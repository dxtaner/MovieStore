using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        public GetActorsModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetActorsModel> Handle()
        {
            var Actors = _movieStoreDbContext.Actors.OrderBy(d => d.Name).ToList<Actor>();

            var mapModel = _mapper.Map<List<GetActorsModel>>(Actors);

            return mapModel;

        }

    }

    public class GetActorsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> PlayedMovies { get; set; }

    }
}