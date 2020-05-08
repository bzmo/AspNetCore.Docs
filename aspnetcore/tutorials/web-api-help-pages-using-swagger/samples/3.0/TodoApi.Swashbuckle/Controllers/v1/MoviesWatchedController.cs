using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MoviesWatched.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesWatched.Controllers.v1
{
    #region snippet_TodoController
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MoviesWatchedController : ControllerBase
    {
        protected readonly MovieContext _context;
        protected const string controllerName = "MoviesWatched";
    #endregion

        public MoviesWatchedController(MovieContext context)
        {
            _context = context;

            if (_context.Movies.Count() == 0)
            {
                Movie[] movies = new Movie[] {
                    new Movie { Name = "Kung Fu Panda", Rating = 5 },
                    new Movie { Name = "Frozen 2", Rating = 4.5, Comment = "Stuck in the Woods reminds me of High School Musical." },
                    new Movie { Name = "Toy Story 4", Rating = 5, Comment = "\"Being There For A Child Is The Most Noble Thing A Toy Can Do.\"" }
                };

                _context.Movies.AddRange(movies);
                _context.SaveChanges();
            }
        }

        #region snippet_GetAl
        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all watched movies.",
            Description = "Fetch all movies watched during COVID-19 shelter-in-place.",
            OperationId = controllerName + "_" + nameof(GetAllMovies),
            Tags = new string[] {controllerName}
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Movies have been fetched", Type = typeof(IEnumerable<Movie>))]
        public async virtual Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return await _context.Movies.ToListAsync();
        }
        #endregion

        #region snippet_GetById
        // <response code="404">The movie was not found.</response>
        [HttpGet("{id:long}")]
        [SwaggerOperation(
            Summary = "Gets a specific movie by its ID.",
            Description = "Fetch a movie watched during COVID-19 shelter-in-place.",
            OperationId = controllerName + "_" + nameof(GetMovieById),
            Tags = new string[] { controllerName }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "The movie was found.", Type = typeof(Movie))]
        public async virtual Task<ActionResult<Movie>> GetMovieById([FromRoute, SwaggerParameter("Movie Id", Required = true)] long id)
        {
            Movie movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
        #endregion

        #region snippet_Create 
        // <response code="400">The movie data is invalid.</response>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a Movie.",
            Description = "Record a movie watched during COVID-19 shelter-in-place.",
            OperationId = controllerName + "_" + nameof(CreateMovie),
            Tags = new string[] { controllerName }
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "The movie was created.", Type = typeof(Movie))]
        public async virtual Task<ActionResult<Movie>> CreateMovie(
            [FromBody, SwaggerParameter("Movie info", Required = true)] Movie movie, ApiVersion version)
        {
            try
            {
                await _context.Movies.AddAsync(movie);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id, version = version.ToString() }, movie);
        }
        #endregion

        #region snippet_Update
        // <response code="400">The movie data is invalid.</response>
        // <response code="404">The movie was not found.</response>
        [HttpPut("{id:long}")]
        [SwaggerOperation(
            Summary = "Updates an existing Movie.",
            Description = "Changes the information for a watched movie.",
            OperationId = controllerName + "_" + nameof(UpdateMovieById),
            Tags = new string[] { controllerName }
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The movie was updated.")]
        public async virtual Task<IActionResult> UpdateMovieById(
            [FromRoute, SwaggerParameter("Movie ID", Required = true)] long id,
            [FromBody, SwaggerParameter("Movie info", Required = true)] Movie movie
        )
        {
            if (movie == null || movie.Id != id)
            {
                return BadRequest();
            }

            var movieToUpdate = await _context.Movies.FindAsync(id);
            if (movieToUpdate == null)
            {
                return NotFound();
            }

            movieToUpdate.Comment = movie.Comment;
            movieToUpdate.Rating = movie.Rating;
            movieToUpdate.Name = movie.Name;

            _context.Movies.Update(movieToUpdate);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region snippet_Delete
        // <response code="404">The movie was not found.</response>
        [HttpDelete("{id:long}")]
        [SwaggerOperation(
            Summary = "Deletes a specific Movie.",
            Description = "Removes a watched movie.",
            OperationId = controllerName + "_" + nameof(DeleteMovieById),
            Tags = new string[] { controllerName }
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The movie was deleted.")]
        public async virtual Task<IActionResult> DeleteMovieById([FromRoute, SwaggerParameter("Movie ID", Required = true)] long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}