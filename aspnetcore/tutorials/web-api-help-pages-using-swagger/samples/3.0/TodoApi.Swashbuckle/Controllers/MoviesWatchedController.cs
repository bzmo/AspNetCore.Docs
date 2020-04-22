using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MoviesWatched.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;

namespace MoviesWatched.Controllers
{
    #region snippet_TodoController
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesWatchedController : ControllerBase
    {
        private readonly MovieContext _context;
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
            OperationId = "GetAllMovies"
        )]
        [SwaggerResponse(200, "Movies have been fetched", typeof(List<Movie>))]
        public ActionResult<List<Movie>> GetAll()
        {
            return _context.Movies.ToList();
        }
        #endregion

        #region snippet_GetById
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Gets a specific movie by its ID.",
            Description = "Fetch a movie watched during COVID-19 shelter-in-place.",
            OperationId = "GetMovieByID"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "The movie was found.", typeof(Movie))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The movie was not found.")]
        public ActionResult<Movie> GetById([FromRoute, SwaggerParameter("Movie ID", Required = true)]long id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }
        #endregion
        
        #region snippet_Create        
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a Movie.",
            Description = "Record a movie watched during COVID-19 shelter-in-place.",
            OperationId = "CreateMovie"
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "The movie was created.", typeof(Movie))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The movie data is invalid.")]
        public ActionResult<Movie> Create([FromBody, SwaggerParameter("Movie info", Required = true)]Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtRoute("GetMovie", new { id = movie.Id }, movie);
        }
        #endregion

        #region snippet_Update
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing Movie.",
            Description = "Changes the information for a watched movie.",
            OperationId = "UpdateMovieByID"
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The movie was updated.", typeof(Movie))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The movie data is invalid.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The movie was not found.")]
        public IActionResult Update(
            [FromRoute, SwaggerParameter("Movie ID", Required = true)]long id,
            [FromBody, SwaggerParameter("Movie info", Required = true)]Movie movie
        )
        {
            if (movie == null || movie.Id != id)
            {
                return BadRequest();
            }

            var movieToUpdate = _context.Movies.Find(id);
            if (movieToUpdate == null)
            {
                return NotFound();
            }

            movieToUpdate.Comment = movie.Comment;
            movieToUpdate.Rating = movie.Rating;
            movieToUpdate.Name = movie.Name;

            _context.Movies.Update(movieToUpdate);
            _context.SaveChanges();

            return NoContent();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a specific Movie.",
            Description = "Removes a watched movie.",
            OperationId = "DeleteMovieByID"
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The movie was deleted.", typeof(Movie))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The movie was not found.")]
        public IActionResult Delete([FromRoute, SwaggerParameter("Movie ID", Required = true)]long id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return NoContent();
        }
        #endregion
    }
}