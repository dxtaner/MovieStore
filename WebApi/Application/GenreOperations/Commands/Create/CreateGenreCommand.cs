using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreModel Model { get; set; }
        public CreateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _Genre = _context.Genres.SingleOrDefault(x => x.GenreId == Model.GenreID);
            if (_Genre is not null)
                throw new InvalidOperationException("Film türü mevcut.");

            _Genre = _mapper.Map<Genre>(Model);

            _context.Genres.Add(_Genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
        public int GenreID { get; set; }
        public Boolean IsActive { get; set; }
    }
}