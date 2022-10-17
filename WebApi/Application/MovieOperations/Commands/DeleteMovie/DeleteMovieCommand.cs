using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int MovieID { get; set; }
        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _movie = _context.Movies.SingleOrDefault(m => m.Id == MovieID);
            if (_movie is null)
                throw new InvalidOperationException("Film bulunamadı.");

            var _BoughtMovie = _context.BoughtMovies.FirstOrDefault(x => x.MovieID == MovieID);
            if (_BoughtMovie is not null)
                throw new InvalidOperationException("Movie silinemez. Siparişi Bulunmakta.");



            _context.Movies.Remove(_movie);
            _context.SaveChanges();
        }
    }
}