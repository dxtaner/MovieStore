using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Queries.GetCustomers
{
    public class GetCustomersQuery
    {
        public GetCustomersModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetCustomersQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public List<GetCustomersModel> Handle()
        {
            var Customers = _movieStoreDbContext.Customers.OrderBy(d => d.Name).ToList<Customer>();

            var mapModel = _mapper.Map<List<GetCustomersModel>>(Customers);

            return mapModel;

        }

    }

    public class GetCustomersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        // public string Movies { get; set; }
        public List<Genre> FavMovieGenre { get; set; }
        public List<Movie> BoughtFilms { get; set; }

    }
}