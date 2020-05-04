// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace WatchedMovies.Rest.v1
{
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for MoviesWatchedAPI.
    /// </summary>
    public static partial class MoviesWatchedAPIExtensions
    {
            /// <summary>
            /// Gets all watched movies.
            /// </summary>
            /// <remarks>
            /// Fetch all movies watched during COVID-19 shelter-in-place.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<Movie> GetAllMovies(this IMoviesWatchedAPI operations)
            {
                return operations.GetAllMoviesAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all watched movies.
            /// </summary>
            /// <remarks>
            /// Fetch all movies watched during COVID-19 shelter-in-place.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Movie>> GetAllMoviesAsync(this IMoviesWatchedAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAllMoviesWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a Movie.
            /// </summary>
            /// <remarks>
            /// Record a movie watched during COVID-19 shelter-in-place.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            public static Movie CreateMovie(this IMoviesWatchedAPI operations, Movie body = default(Movie))
            {
                return operations.CreateMovieAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a Movie.
            /// </summary>
            /// <remarks>
            /// Record a movie watched during COVID-19 shelter-in-place.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Movie> CreateMovieAsync(this IMoviesWatchedAPI operations, Movie body = default(Movie), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateMovieWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a specific movie by its ID.
            /// </summary>
            /// <remarks>
            /// Fetch a movie watched during COVID-19 shelter-in-place.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// Movie Id
            /// </param>
            public static Movie GetMovieById(this IMoviesWatchedAPI operations, long id)
            {
                return operations.GetMovieByIdAsync(id).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a specific movie by its ID.
            /// </summary>
            /// <remarks>
            /// Fetch a movie watched during COVID-19 shelter-in-place.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// Movie Id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Movie> GetMovieByIdAsync(this IMoviesWatchedAPI operations, long id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetMovieByIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates an existing Movie.
            /// </summary>
            /// <remarks>
            /// Changes the information for a watched movie.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// Movie ID
            /// </param>
            /// <param name='body'>
            /// </param>
            public static void UpdateMovieById(this IMoviesWatchedAPI operations, long id, Movie body = default(Movie))
            {
                operations.UpdateMovieByIdAsync(id, body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates an existing Movie.
            /// </summary>
            /// <remarks>
            /// Changes the information for a watched movie.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// Movie ID
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task UpdateMovieByIdAsync(this IMoviesWatchedAPI operations, long id, Movie body = default(Movie), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.UpdateMovieByIdWithHttpMessagesAsync(id, body, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Deletes a specific Movie.
            /// </summary>
            /// <remarks>
            /// Removes a watched movie.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// Movie ID
            /// </param>
            public static void DeleteMovieById(this IMoviesWatchedAPI operations, long id)
            {
                operations.DeleteMovieByIdAsync(id).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a specific Movie.
            /// </summary>
            /// <remarks>
            /// Removes a watched movie.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// Movie ID
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteMovieByIdAsync(this IMoviesWatchedAPI operations, long id, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteMovieByIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
