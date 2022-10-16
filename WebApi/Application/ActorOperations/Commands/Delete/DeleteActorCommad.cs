using WebApi.DBOperations;

namespace WebApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int ActorID { get; set; }
        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _Actor = _context.Actors.SingleOrDefault(m => m.Id == ActorID);
            if (_Actor is null)
                throw new InvalidOperationException("Aktör bulunamadı.");

            var _Movie = _context.Movies.FirstOrDefault(x => x.Actors.Any(u => u.Id == ActorID));
            if (_Movie is not null)
                throw new InvalidOperationException("Aktör Silinemez!! Zaten Mevcut Filmi Var.");


            _context.Actors.Remove(_Actor);
            _context.SaveChanges();
        }
    }
}