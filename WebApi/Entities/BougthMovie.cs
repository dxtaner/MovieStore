using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class BoughtMovie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoughtMovieID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public DateTime BoughtMovieDate { get; set; }
        public int Price { get; set; }
        public bool isActive { get; set; } = true;

    }
}