using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.ActorID).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Model.Surname).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Model.PlayedMovies).NotEmpty();
        }
    }
}