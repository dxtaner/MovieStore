using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreModel Model { get; set; }
        public int GenreID { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var updateGenre = _context.Genres.SingleOrDefault(x => x.GenreId == GenreID);
            if (updateGenre is null)
                throw new InvalidOperationException("Film türü bulunamadı.");

            updateGenre.GenreName = updateGenre.GenreId != default ? Model.Name : updateGenre.GenreName;
            updateGenre.IsActive = updateGenre.GenreId != default ? Model.IsActive : updateGenre.IsActive;

            _context.Genres.Update(updateGenre);
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public Boolean IsActive { get; set; }
    }
}