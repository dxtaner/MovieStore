using FluentValidation;

namespace WebApi.Application.BoughtMovieOperations.Commands.CreateBoughtMovie
{
    public class CreateBoughtMovieCommandValidator : AbstractValidator<CreateBoughtMovieCommand>
    {
        public CreateBoughtMovieCommandValidator()
        {
            RuleFor(x => x.Model.Movie).NotEmpty();
            RuleFor(x => x.Model.Customer).NotEmpty();
            RuleFor(x => x.Model.Price).NotEmpty();
            RuleFor(x => x.Model.BoughtMovieDate).NotEmpty();
        }
    }
}