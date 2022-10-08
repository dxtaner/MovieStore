using WebApi.DBOperations;

namespace WebApi.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int CustomerID { get; set; }
        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _Customer = _context.Customers.SingleOrDefault(m => m.Id == CustomerID);
            if (_Customer is null)
                throw new InvalidOperationException("Customer bulunamadı.");


            _context.Customers.Remove(_Customer);
            _context.SaveChanges();
        }
    }
}