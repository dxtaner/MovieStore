using FluentValidation;
using WebApi.Application.BoughtMovieOperations.Queries.GetBoughtMovieDetail;

namespace WebApi.Application.MovieOperations.Queries.GetBoughtMovieDetail
{
    public class GetBoughtMovieDetailQueryValidator : AbstractValidator<GetBoughtMovieDetailQuery>
    {
        public GetBoughtMovieDetailQueryValidator()
        {
            RuleFor(M => M.BoughtMovieId).GreaterThan(0);
        }
    }
}