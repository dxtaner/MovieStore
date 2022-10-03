using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetGenreDetailQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public GenreDetailModel Handle()
        {
            var genre = _movieStoreDbContext.Genres.SingleOrDefault(g => g.GenreId == GenreId);

            if (genre == null)
            {
                throw new InvalidOperationException("Film Türü bulunamadı ! ");
            }

            GenreDetailModel model = _mapper.Map<GenreDetailModel>(genre);

            return model;

        }

    }
    public class GenreDetailModel
    {
        public string Name { get; set; }
    }
}