using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        public UpdateCustomerModel Model { get; set; }
        public int CustomerID { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var updateCustomer = _context.Customers.SingleOrDefault(x => x.Id == CustomerID);
            if (updateCustomer is null)
                throw new InvalidOperationException("Customer bulunamadı.");

            updateCustomer.Name = updateCustomer.Name != default ? Model.Name : updateCustomer.Name;
            updateCustomer.Surname = updateCustomer.Surname != default ? Model.Surname : updateCustomer.Surname;
            updateCustomer.FavMovieGenre = updateCustomer.FavMovieGenre != default ? Model.FavMovieGenre : updateCustomer.FavMovieGenre;
            updateCustomer.BoughtFilms = updateCustomer.BoughtFilms != default ? Model.BoughtFilms : updateCustomer.BoughtFilms;

            _context.Customers.Update(updateCustomer);

            _context.SaveChanges();
        }
    }

    public class UpdateCustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        // public string Movies { get; set; }
        public List<Genre> FavMovieGenre { get; set; }
        public List<Movie> BoughtFilms { get; set; }
    }
}