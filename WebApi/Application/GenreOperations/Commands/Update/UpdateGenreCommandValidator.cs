using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.GenreID).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(4).NotEmpty();
        }
    }
}