using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.DBOperations;
using WebApi.Entites;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
            var _movies = query.Handle();
            return Ok(_movies);
        }

        [HttpGet("{id}")]
        public Movie GetById(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.movieID = id;

            GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var _movie = query.Handle();
            return Ok(_movie);
        }


        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie newMovie)
        {
            var movie = MovieList.SingleOrDefault(m => m.Title == newMovie.Title);

            if (movie is not null)
                return BadRequest();

            MovieList.Add(newMovie);
            return Ok();

        }

        [HttpPut]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            var movie = MovieList.SingleOrDefault(m => m.Id == id);

            if (movie is null)
                return BadRequest();

            movie.GenreId = updatedMovie.GenreId != default ? updatedMovie.GenreId : movie.GenreId;
            movie.Title = updatedMovie.Title != default ? updatedMovie.Title : movie.Title;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = MovieList.SingleOrDefault(m => m.Id == id);

            if (movie is null)
                return BadRequest();

            MovieList.Remove(movie);
            return Ok();
        }
    }
}