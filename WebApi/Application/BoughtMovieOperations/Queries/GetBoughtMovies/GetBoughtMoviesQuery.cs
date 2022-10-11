using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BoughtMovieOperations.Queries.GetBoughtMovies
{
    public class GetBoughtMoviesQuery
    {
        public GetBoughtMoviesModel Model { get; set; }
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetBoughtMoviesQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetBoughtMoviesModel> Handle()
        {
            var BoughtMovies = _movieStoreDbContext.BoughtMovies.OrderBy(b => b.Movie).ToList<BoughtMovie>();

            var mapModel = _mapper.Map<List<GetBoughtMoviesModel>>(BoughtMovies);

            return mapModel;

        }

    }

    public class GetBoughtMoviesModel
    {
        public Customer Customer { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public DateTime BoughtMovieDate { get; set; }
        public int Price { get; set; }
        public bool isActive { get; set; } = true;

    }
}