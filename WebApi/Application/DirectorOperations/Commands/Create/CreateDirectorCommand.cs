using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorModel Model { get; set; }
        public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _Director = _context.Directors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (_Director is not null)
                throw new InvalidOperationException("Director zaten mevcut.");

            _Director = _mapper.Map<Director>(Model);

            _context.Directors.Add(_Director);
            _context.SaveChanges();
        }
    }

    public class CreateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> DirectedMovies { get; set; }
    }
}