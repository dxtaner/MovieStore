using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.ActorID).GreaterThan(0);
        }
    }
}