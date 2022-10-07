using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerID).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Model.Surname).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Model.FavMovieGenre).NotEmpty();
            RuleFor(x => x.Model.BoughtFilms).NotEmpty();

        }
    }
}