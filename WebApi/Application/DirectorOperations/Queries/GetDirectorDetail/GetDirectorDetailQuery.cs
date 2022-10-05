using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetDirectorDetailQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public DirectorDetailModel Handle()
        {

            var Directors = _movieStoreDbContext.Directors.Include(x => x.Id == DirectorId);

            if (Directors == null)
            {
                throw new InvalidOperationException("Director bulunamadı ! ");
            }

            DirectorDetailModel model = _mapper.Map<DirectorDetailModel>(Directors);

            return model;

        }

    }
    public class DirectorDetailModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> DirectedMovies { get; set; }

    }
}