using FluentValidation;

namespace WebApi.Application.BoughtMovieOperations.Commands.UpdateBoughtMovie
{
    public class UpdateBoughtMovieCommandValidator : AbstractValidator<UpdateBoughtMovieCommand>
    {
        public UpdateBoughtMovieCommandValidator()
        {
            RuleFor(x => x.BoughtMovieID).GreaterThan(0);
            RuleFor(x => x.Model.Customer).NotEmpty();
            RuleFor(x => x.Model.Movie).NotEmpty();
            RuleFor(x => x.Model.Price).NotEmpty();
            RuleFor(x => x.Model.isActive).NotEmpty();

        }
    }
}