using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetActorDetailQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public ActorDetailModel Handle()
        {

            var actors = _movieStoreDbContext.Actors.Include(x => x.Id == ActorId);

            if (actors == null)
            {
                throw new InvalidOperationException("Actor bulunamadı ! ");
            }

            ActorDetailModel model = _mapper.Map<ActorDetailModel>(actors);

            return model;

        }

    }
    public class ActorDetailModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> PlayedMovies { get; set; }

    }
}