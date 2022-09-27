using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string Director { get; set; }
        public Director director { get; set; }
        public List<Actor> Actors { get; set; }
        public int Price { get; set; }

    }
}