using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Model.Title).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Price).GreaterThan(0);
            RuleFor(x => x.Model.DirectorID).GreaterThan(0);
            RuleFor(x => x.Model.GenreID).GreaterThan(0);
            RuleFor(x => x.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}