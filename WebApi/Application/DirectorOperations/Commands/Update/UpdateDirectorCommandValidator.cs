using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(x => x.DirectorID).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Model.Surname).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Model.DirectedMovies).NotEmpty();
        }
    }
}