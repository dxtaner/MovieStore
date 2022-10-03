using AutoMapper;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetMoviesModel> Handle()
        {
            var _movieList = _context.Movies.Include(m => m.Genre).Include(g => g.Director).OrderBy(d => d.Id).ToList<Movie>();

            List<GetMoviesModel> mv = _mapper.Map<List<GetMoviesModel>>(_movieList);
            return mv;
        }
    }
    public class GetMoviesModel
    {
        public string Title { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Price { get; set; }
        public List<Actor> Actors { get; set; }
    }
}