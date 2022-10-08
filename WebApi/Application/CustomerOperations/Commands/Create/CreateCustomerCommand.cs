using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerModel Model { get; set; }
        public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _Customer = _context.Customers.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (_Customer is not null)
                throw new InvalidOperationException("Customer zaten mevcut.");

            _Customer = _mapper.Map<Customer>(Model);

            _context.Customers.Add(_Customer);
            _context.SaveChanges();
        }
    }

    public class CreateCustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        // public string Movies { get; set; }
        public List<Genre> FavMovieGenre { get; set; }
        public List<Movie> BoughtFilms { get; set; }

    }
}