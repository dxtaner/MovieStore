using WebApi.DBOperations;

namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int DirectorID { get; set; }
        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _Director = _context.Directors.SingleOrDefault(m => m.Id == DirectorID);
            if (_Director is null)
                throw new InvalidOperationException("Director bulunamadı.");

            var _movie = _context.Movies.FirstOrDefault(x => x.DirectorID == DirectorID);
            if (_movie is not null)
                throw new InvalidOperationException("Director silinemez. Mevcut Filmi Var.");

            _context.Directors.Remove(_Director);
            _context.SaveChanges();
        }
    }
}