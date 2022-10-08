using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public GetCustomerDetailQuery(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public CustomerDetailModel Handle()
        {

            var Customers = _movieStoreDbContext.Customers.Include(x => x.Id == CustomerId);

            if (Customers == null)
            {
                throw new InvalidOperationException("Customer bulunamadı ! ");
            }

            CustomerDetailModel model = _mapper.Map<CustomerDetailModel>(Customers);

            return model;

        }

    }
    public class CustomerDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        // public string Movies { get; set; }
        public List<Genre> FavMovieGenre { get; set; }
        public List<Movie> BoughtFilms { get; set; }

    }
}