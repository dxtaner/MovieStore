using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorModel Model { get; set; }
        public int ActorID { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var updateActor = _context.Actors.SingleOrDefault(x => x.Id == ActorID);
            if (updateActor is null)
                throw new InvalidOperationException("Actor bulunamadı.");

            updateActor.Name = updateActor.Name != default ? Model.Name : updateActor.Name;
            updateActor.Surname = updateActor.Surname != default ? Model.Surname : updateActor.Surname;
            updateActor.PlayedMovies = updateActor.PlayedMovies != default ? Model.PlayedMovies : updateActor.PlayedMovies;

            _context.Actors.Update(updateActor);

            _context.SaveChanges();
        }
    }

    public class UpdateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Movie> PlayedMovies
        {
            get; set;
        }
    }
}