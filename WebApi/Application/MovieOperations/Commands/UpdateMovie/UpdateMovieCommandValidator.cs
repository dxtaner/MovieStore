using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.MovieID).GreaterThan(0);
            RuleFor(x => x.Model.Title).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Model.GenreID).GreaterThan(0);
            RuleFor(x => x.Model.Price).GreaterThan(0);
            RuleFor(x => x.Model.PublisDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.DirectorID).GreaterThan(0);
        }
    }
}