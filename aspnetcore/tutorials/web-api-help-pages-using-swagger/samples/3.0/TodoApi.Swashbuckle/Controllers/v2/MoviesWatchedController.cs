using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWatched.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;

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
            Description = "Fetch all movies watched during COVID-19 shelter-in-place.",
            OperationId = nameof(GetAllMovies)
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Movies have been fetched", typeof(IList<Movie>))]
        public override ActionResult<IList<Movie>> GetAllMovies()
        {
            return _context.Movies.ToList().OrderByDescending(x => x.Name).ToList();
        }
        #endregion

        #region snippet_Patch
        [HttpPatch("{id:long}")]
        [SwaggerOperation(
            Summary = "Updates a rating of a specific Movie.",
            Description = "Updates movie rating.",
            OperationId = nameof(UpdateMovieRating)
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The movie rating was updated.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The movie was not found.")]
        public virtual IActionResult UpdateMovieRating(
            [FromRoute, SwaggerParameter("Movie ID", Required = true)]long id,
            [FromBody, SwaggerParameter("Movie Rating", Required = true)]double rating
        )
        {
            Movie movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Rating = rating;
            _context.Movies.Update(movie);
            _context.SaveChanges();

            return NoContent();
        }
        #endregion
    }
}