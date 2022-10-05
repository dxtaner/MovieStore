using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public UpdateDirectorModel Model { get; set; }
        public int DirectorID { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var updateDirector = _context.Directors.SingleOrDefault(x => x.Id == DirectorID);
            if (updateDirector is null)
                throw new InvalidOperationException("Director bulunamadı.");

            updateDirector.Name = updateDirector.Name != default ? Model.Name : updateDirector.Name;
            updateDirector.Surname = updateDirector.Surname != default ? Model.Surname : updateDirector.Surname;
            updateDirector.DirectedMovies = updateDirector.DirectedMovies != default ? Model.DirectedMovies : updateDirector.DirectedMovies;

            _context.Directors.Update(updateDirector);

            _context.SaveChanges();
        }
    }

    public class UpdateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Movie> DirectedMovies
        {
            get; set;
        }
    }
}