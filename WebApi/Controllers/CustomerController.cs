using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.Application.CustomerOperations.Commands.UpdateCustomer;
using WebApi.Application.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.Application.CustomerOperations.Queries.GetCustomers;
using WebApi.Application.MovieOperations.Queries.GetCustomerDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
            var _Customers = query.Handle();
            return Ok(_Customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_context, _mapper);
            query.CustomerId = id;

            GetCustomerDetailQueryValidator validator = new GetCustomerDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var _Customer = query.Handle();
            return Ok(_Customer);
        }


        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = newCustomer;

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerModel _update)
        {
            UpdateCustomerCommand updateCustomerCommand = new UpdateCustomerCommand(_context);
            updateCustomerCommand.Model = _update;
            updateCustomerCommand.CustomerID = id;

            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            validator.ValidateAndThrow(updateCustomerCommand);
            updateCustomerCommand.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand query = new DeleteCustomerCommand(_context);
            query.CustomerID = id;

            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }
    }
}