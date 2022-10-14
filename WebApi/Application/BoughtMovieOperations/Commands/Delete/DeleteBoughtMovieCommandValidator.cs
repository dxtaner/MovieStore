using FluentValidation;

namespace WebApi.Application.BoughtMovieOperations.Commands.DeleteBoughtMovie
{
    public class DeleteBoughtMovieCommandValidator : AbstractValidator<DeleteBoughtMovieCommand>
    {
        public DeleteBoughtMovieCommandValidator()
        {
            RuleFor(x => x.BoughtMovieID).GreaterThan(0);
        }
    }
}