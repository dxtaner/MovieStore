using Microsoft.AspNetCore.Mvc;

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
                title = "LOTR",
                genreId = 1,
                len = 320,
                publishDate = new DateTime(2000, 12, 02)
            },
          new Movie()
            {
                Id = 2,
                title = "City on a Hill (2019)",
                genreId = 2,
                len = 60,
                publishDate = new DateTime(2022, 08, 02)
            },
             new Movie()
            {
                Id = 2,
                title = "Yüzüklerin Efendisi: Kralın Dönüşü (2003)",
                genreId = 1,
                len = 201,
                publishDate = new DateTime(2003, 12, 19)
            },
            new Movie()
            {
                Id = 4,
                title = "What We Do in the Shadows (2016–)",
                genreId = 3,
                len = 50,
                publishDate = new DateTime(2016, 11, 12)
            },
            new Movie()
            {
                Id = 5,
                title = "Pinocchio (2022)",
                genreId = 5,
                len = 100,
                publishDate = new DateTime(2022, 06, 02)
            },
        };

        [HttpGet]
        public List<Movie> GetBooks()
        {
            var movieList = MovieList.OrderBy(m => m.genreId).ToList<Movie>();
            return movieList;
        }

        [HttpGet("{id}")]
        public Movie GetById(int id)
        {
            var movie = MovieList.Where(movie => movie.Id == id).SingleOrDefault();
            return movie;
        }
        
        // [HttpGet]
        // public Movie Get([FromQuery] string id)
        // {
        //     var movie = MovieList.Where(movie => movie.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return movie;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] Movie newMovie)
        {
            var movie = MovieList.SingleOrDefault(m => m.title == newMovie.title);

            if (movie is not null)
                return BadRequest();

            MovieList.Add(newMovie);
            return Ok();

        }

        [HttpPut]
        public IActionResult UpdateBook(int id,[FromBody] Movie updatedMovie)
        {
            var movie = MovieList.SingleOrDefault(m => m.Id == id);

            if (movie is null)
                return BadRequest();

            movie.genreId = updatedMovie.genreId != default ? updatedMovie.genreId : movie.genreId;
            movie.len = updatedMovie.len != default ? updatedMovie.len : movie.len;
            movie.publishDate = updatedMovie.publishDate != default ? updatedMovie.publishDate : movie.publishDate;
            movie.title = updatedMovie.title != default ? updatedMovie.title : movie.title;

            return Ok();
        }  
    }
}