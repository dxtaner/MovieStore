using FluentValidation;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetActorDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(M => M.movieID).GreaterThan(0);
        }
    }
}