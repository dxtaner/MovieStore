using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{

    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public Boolean IsActive { get; set; }


    }
}