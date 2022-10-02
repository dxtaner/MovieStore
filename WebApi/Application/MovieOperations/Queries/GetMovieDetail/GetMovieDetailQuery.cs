using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int movieID { get; set; }
        public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetMovieDetailModel Handle()
        {
            var _movie = _context.Movies.Include(m => m.Genre).Include(g => g.Director).SingleOrDefault(x => x.Id == movieID);
            if (_movie is null)
                throw new InvalidOperationException("Film bulunamadı!!!.");

            GetMovieDetailModel _model = _mapper.Map<GetMovieDetailModel>(_movie);
            return _model;
        }
    }

    public class GetMovieDetailModel
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Price { get; set; }
    }
}