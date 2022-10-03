using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenreQuery
    {
        public GetGenreModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetGenreQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetGenreModel> Handle()
        {
            var genres = _movieStoreDbContext.Genres.Where(g => g.IsActive == true).ToList<Genre>();

            var mapModel = _mapper.Map<List<GetGenreModel>>(genres);

            return mapModel;

        }


    }

    public class GetGenreModel
    {
        public string Name { get; set; }

    }
}