using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{

    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> PlayedMovies { get; set; }


    }
}