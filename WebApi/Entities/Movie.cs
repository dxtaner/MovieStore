using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int DirectorID { get; set; }
        public Director Director { get; set; }
        public List<Actor> Actors { get; set; }
        public int Price { get; set; }

    }
}