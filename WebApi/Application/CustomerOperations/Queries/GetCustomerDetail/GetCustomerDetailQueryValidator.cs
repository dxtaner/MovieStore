using FluentValidation;
using WebApi.Application.CustomerOperations.Queries.GetCustomerDetail;

namespace WebApi.Application.MovieOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailQueryValidator()
        {
            RuleFor(M => M.CustomerId).GreaterThan(0);
        }
    }
}