using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Title { get; set; }
        public int Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string Director { get; set; }
        public List<Actor> Actors { get; set; }
        public int Price { get; set; }

    }
}