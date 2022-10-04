using FluentValidation;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;

namespace WebApi.Application.MovieOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(M => M.ActorId).GreaterThan(0);
        }
    }
}