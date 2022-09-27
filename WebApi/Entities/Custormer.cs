using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{

    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Movies { get; set; }
        public List<Movie> FavMovieGenre { get; set; }
        public List<Movie> BougthFilms { get; set; }



    }
}