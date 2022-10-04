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


            _context.Actors.Remove(_Actor);
            _context.SaveChanges();
        }
    }
}