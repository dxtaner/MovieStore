namespace WebApi.Entites
{

    public class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Movies { get; set; }
        public List<Movie> FavMovieGenre { get; set; }



    }
}