using FluentValidation;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;

namespace WebApi.Application.MovieOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(M => M.DirectorId).GreaterThan(0);
        }
    }
}