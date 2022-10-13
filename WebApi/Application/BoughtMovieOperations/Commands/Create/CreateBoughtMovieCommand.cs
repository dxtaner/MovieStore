using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BoughtMovieOperations.Commands.CreateBoughtMovie
{
    public class CreateBoughtMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBoughtMovieModel Model { get; set; }
        public CreateBoughtMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _BoughtMovie = _context.BoughtMovies.SingleOrDefault(x => x.isActive == true);
            if (_BoughtMovie is not null)
                throw new InvalidOperationException("BoughtMovie zaten önceden mevcut.");

            _BoughtMovie = _mapper.Map<BoughtMovie>(Model);

            _context.BoughtMovies.Add(_BoughtMovie);
            _context.SaveChanges();
        }
    }

    public class CreateBoughtMovieModel
    {
        public Customer Customer { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public DateTime BoughtMovieDate { get; set; }
        public int Price { get; set; }
        public bool isActive { get; set; }
    }
}