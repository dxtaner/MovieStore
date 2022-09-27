using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{

    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int GenreId { get; set; }
        public string GenreName { get; set; }


    }
}