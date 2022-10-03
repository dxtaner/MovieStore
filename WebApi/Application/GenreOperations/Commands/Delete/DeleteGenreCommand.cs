using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int GenreID { get; set; }
        public DeleteGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _Genre = _context.Genres.SingleOrDefault(global => global.GenreId == GenreID);
            if (_Genre is null)
                throw new InvalidOperationException("Film türü bulunamadı.");


            _context.Genres.Remove(_Genre);
            _context.SaveChanges();
        }
    }
}