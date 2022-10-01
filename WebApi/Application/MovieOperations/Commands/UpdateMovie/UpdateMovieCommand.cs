using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public UpdateMovieModel Model { get; set; }
        public int MovieID { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var updateMovie = _context.Movies.SingleOrDefault(x => x.Id == MovieID);
            if (updateMovie is null)
                throw new InvalidOperationException("Film bulunamadı.");

            updateMovie.GenreID = updateMovie.GenreID != default ? Model.GenreID : updateMovie.GenreID;
            updateMovie.Price = updateMovie.Price != default ? Model.Price : updateMovie.Price;
            updateMovie.PublisDate = updateMovie.PublisDate != default ? Model.PublisDate : updateMovie.PublisDate;
            updateMovie.Title = updateMovie.Title != default ? Model.Title : updateMovie.Title;
            updateMovie.DirectorID = updateMovie.DirectorID != default ? Model.DirectorID : updateMovie.DirectorID;

            _context.Movies.Update(updateMovie);

            _context.SaveChanges();
        }
    }

    public class UpdateMovieModel
    {
        public string Title { get; set; }
        public DateTime PublisDate { get; set; }
        public int GenreID { get; set; }
        public int DirectorID { get; set; }
        public int Price { get; set; }
    }
}