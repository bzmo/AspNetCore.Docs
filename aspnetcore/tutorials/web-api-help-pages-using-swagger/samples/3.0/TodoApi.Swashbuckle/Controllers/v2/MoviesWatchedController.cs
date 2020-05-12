using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWatched.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWatched.Controllers.v2
{
    #region snippet_TodoController
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MoviesWatchedController : v1.MoviesWatchedController
    {
    #endregion

        public MoviesWatchedController(MovieContext context) : base(context)
        {
        }

        #region snippet_GetAl
        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all watched movies sorted alphabetically.",
            Description = "Fetch all movies watched during COVID-19 shelter-in-place."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Movies have been fetched", Type = typeof(IEnumerable<Movie>))]
        public async override Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            IList<Movie> movies = await _context.Movies.ToListAsync();

            return movies.OrderByDescending(x => x.Name).ToList();
        }
        #endregion

        #region snippet_Patch
        // <response code="404">The movie was not found.</response>
        [HttpPatch("{id:long}")]
        [SwaggerOperation(
            Summary = "Updates a rating of a specific Movie.",
            Description = "Updates movie rating."
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The movie rating was updated.")]
        public async virtual Task<IActionResult> UpdateMovieRating(
            [FromRoute, SwaggerParameter("Movie Id", Required = true)]long id,
            [FromBody, SwaggerParameter("Movie Rating", Required = true)]double rating
        )
        {
            Movie movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Rating = rating;
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}