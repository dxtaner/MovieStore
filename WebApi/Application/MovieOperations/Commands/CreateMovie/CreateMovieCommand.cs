using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieModel Model { get; set; }
        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _movie = _context.Movies.SingleOrDefault(x => x.Title == Model.Title);
            if (_movie is not null)
                throw new InvalidOperationException("Film mevcut.");

            _movie = _mapper.Map<Movie>(Model);

            _context.Movies.Add(_movie);
            _context.SaveChanges();
        }
    }

    public class CreateMovieModel
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreID { get; set; }
        public int DirectorID { get; set; }
        public int Price { get; set; }
    }
}