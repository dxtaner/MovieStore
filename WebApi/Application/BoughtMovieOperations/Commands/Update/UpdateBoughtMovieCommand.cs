using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BoughtMovieOperations.Commands.UpdateBoughtMovie
{
    public class UpdateBoughtMovieCommand
    {
        public UpdateBoughtMovieModel Model { get; set; }
        public int BoughtMovieID { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateBoughtMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var updateBoughtMovie = _context.BoughtMovies.SingleOrDefault(x => x.BoughtMovieID == BoughtMovieID);
            if (updateBoughtMovie is null)
                throw new InvalidOperationException("Bought Movie  bulunamadı.");

            updateBoughtMovie.Customer = updateBoughtMovie.Customer != default ? Model.Customer : updateBoughtMovie.Customer;
            updateBoughtMovie.Movie = updateBoughtMovie.Movie != default ? Model.Movie : updateBoughtMovie.Movie;
            updateBoughtMovie.Price = updateBoughtMovie.Price != default ? Model.Price : updateBoughtMovie.Price;
            updateBoughtMovie.isActive = updateBoughtMovie.isActive != default ? Model.isActive : updateBoughtMovie.isActive;

            _context.BoughtMovies.Update(updateBoughtMovie);

            _context.SaveChanges();
        }
    }

    public class UpdateBoughtMovieModel
    {
        public Customer Customer { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public DateTime BoughtMovieDate { get; set; }
        public int Price { get; set; }
        public bool isActive { get; set; }
    }
}