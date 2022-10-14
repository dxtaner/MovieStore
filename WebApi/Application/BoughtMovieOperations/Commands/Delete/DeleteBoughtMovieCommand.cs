using WebApi.DBOperations;

namespace WebApi.Application.BoughtMovieOperations.Commands.DeleteBoughtMovie
{
    public class DeleteBoughtMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int BoughtMovieID { get; set; }
        public DeleteBoughtMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _BoughtMovie = _context.BoughtMovies.SingleOrDefault(b => b.BoughtMovieID == BoughtMovieID);
            if (_BoughtMovie is null)
                throw new InvalidOperationException("Alının film bulunamadı.");


            _context.BoughtMovies.Remove(_BoughtMovie);
            _context.SaveChanges();
        }
    }
}