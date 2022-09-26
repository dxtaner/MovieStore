using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{

    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> DirectedMovies { get; set; }


    }
}