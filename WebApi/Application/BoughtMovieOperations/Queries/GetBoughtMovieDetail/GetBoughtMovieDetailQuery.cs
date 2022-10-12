using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BoughtMovieOperations.Queries.GetBoughtMovieDetail
{
    public class GetBoughtMovieDetailQuery
    {
        public int BoughtMovieId { get; set; }
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetBoughtMovieDetailQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public BoughtMovieDetailModel Handle()
        {

            var BoughtMovies = _movieStoreDbContext.BoughtMovies.Include(b => b.BoughtMovieID == BoughtMovieId);

            if (BoughtMovies == null)
            {
                throw new InvalidOperationException("BoughtMovie bulunamadı ! ");
            }

            BoughtMovieDetailModel model = _mapper.Map<BoughtMovieDetailModel>(BoughtMovies);

            return model;

        }

    }
    public class BoughtMovieDetailModel
    {
        public Customer Customer { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public DateTime BoughtMovieDate { get; set; }
        public int Price { get; set; }
        public bool isActive { get; set; } = true;
    }
}