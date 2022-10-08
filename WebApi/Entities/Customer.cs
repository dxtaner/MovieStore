using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{

    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        // public string Movies { get; set; }
        public List<Genre> FavMovieGenre { get; set; }
        public List<Movie> BoughtFilms { get; set; }


    }
}