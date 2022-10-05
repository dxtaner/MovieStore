using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        public GetDirectorsModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetDirectorsModel> Handle()
        {
            var Directors = _movieStoreDbContext.Directors.OrderBy(d => d.Name).ToList<Director>();

            var mapModel = _mapper.Map<List<GetDirectorsModel>>(Directors);

            return mapModel;

        }

    }

    public class GetDirectorsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> DirectedMovies { get; set; }

    }
}