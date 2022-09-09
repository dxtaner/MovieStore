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
        };

        [HttpGet]
        public List<Movie> GetBooks()
        {
            var movieList = MovieList.OrderBy(m => m.genreId).ToList<Movie>();
            return movieList;
        }
    }
}