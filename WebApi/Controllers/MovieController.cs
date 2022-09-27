using Microsoft.AspNetCore.Mvc;
using WebApi.Entites;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> MovieList = new List<Movie>(){

         new Movie()
            {
                Id = 1,
                Title = "LOTR",
            },
          new Movie()
            {
                Id = 2,
                Title = "City on a Hill (2019)",
            },
             new Movie()
            {
                Id = 2,
                Title = "Yüzüklerin Efendisi: Kralın Dönüşü (2003)",
            },
            new Movie()
            {
                Id = 4,
                Title = "What We Do in the Shadows (2016–)",
            },
            new Movie()
            {
                Id = 5,
                Title = "Pinocchio (2022)",
            },
        };

        [HttpGet]
        public List<Movie> GetMovies()
        {
            var movieList = MovieList.OrderBy(m => m.GenreId).ToList<Movie>();
            return movieList;
        }

        [HttpGet("{id}")]
        public Movie GetById(int id)
        {
            var movie = MovieList.Where(movie => movie.Id == id).SingleOrDefault();
            return movie;
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