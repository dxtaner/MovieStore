using FluentValidation;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(M => M.movieID).GreaterThan(0);
        }
    }
}