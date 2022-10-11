using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BoughtMovieOperations.Commands.CreateBoughtMovie;
using WebApi.Application.BoughtMovieOperations.Commands.DeleteBoughtMovie;
using WebApi.Application.BoughtMovieOperations.Commands.UpdateBoughtMovie;
using WebApi.Application.BoughtMovieOperations.Queries.GetBoughtMovieDetail;
using WebApi.Application.BoughtMovieOperations.Queries.GetBoughtMovies;
using WebApi.Application.MovieOperations.Queries.GetBoughtMovieDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BoughtMovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public BoughtMovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBoughtMovies()
        {
            GetBoughtMoviesQuery query = new GetBoughtMoviesQuery(_context, _mapper);
            var _BoughtMovies = query.Handle();
            return Ok(_BoughtMovies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBoughtMovieDetailQuery query = new GetBoughtMovieDetailQuery(_context, _mapper);
            query.BoughtMovieId = id;

            GetBoughtMovieDetailQueryValidator validator = new GetBoughtMovieDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var _BoughtMovie = query.Handle();
            return Ok(_BoughtMovie);
        }


        [HttpPost]
        public IActionResult CreateBoughtMovie([FromBody] CreateBoughtMovieModel newBoughtMovie)
        {
            CreateBoughtMovieCommand command = new CreateBoughtMovieCommand(_context, _mapper);
            command.Model = newBoughtMovie;

            CreateBoughtMovieCommandValidator validator = new CreateBoughtMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBoughtMovie(int id, [FromBody] UpdateBoughtMovieModel _update)
        {
            UpdateBoughtMovieCommand updateBoughtMovieCommand = new UpdateBoughtMovieCommand(_context);
            updateBoughtMovieCommand.Model = _update;
            updateBoughtMovieCommand.BoughtMovieID = id;

            UpdateBoughtMovieCommandValidator validator = new UpdateBoughtMovieCommandValidator();
            validator.ValidateAndThrow(updateBoughtMovieCommand);
            updateBoughtMovieCommand.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBoughtMovie(int id)
        {
            DeleteBoughtMovieCommand query = new DeleteBoughtMovieCommand(_context);
            query.BoughtMovieID = id;

            DeleteBoughtMovieCommandValidator validator = new DeleteBoughtMovieCommandValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }
    }
}