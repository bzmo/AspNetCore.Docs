using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using WatchedMovies.Rest.v2;
using WatchedMovies.Rest.v2.Models;

namespace ExampleApp
{
    class ProgramV2
    {
        public static void SendAPIRequests(string[] args)
        {
            Uri baseUri = new Uri("https://localhost:44380");
            MoviesWatchedAPI api = new MoviesWatchedAPI(baseUri);

            Movie movie = new Movie("Finding Nemo", 4.7, null, "Found!");

            try
            {
                // Get All
                Console.WriteLine("Movies now sorted!");
                IList<Movie> movies = api.MoviesWatched.GetAllMovies();
                foreach (Movie m in movies)
                {
                    PrintMovieInfo(m);
                }

                Console.WriteLine("---");

                // Create
                movie = api.MoviesWatched.CreateMovie(movie);
                PrintMovieInfo(movie);

                Console.WriteLine("---");

                long id = movie.Id ?? 4;

                // Update
                movie.Rating = 4.7;
                movie.Comment = "Found him!";
                api.MoviesWatched.UpdateMovieById(id, movie);

                // Patch
                api.MoviesWatched.UpdateMovieRating(id, 4.9);
                Console.WriteLine("Patch Request made!");

                // Get
                movie = api.MoviesWatched.GetMovieById(id);
                PrintMovieInfo(movie);

                // Delete
                api.MoviesWatched.DeleteMovieById(id);

                Console.WriteLine("---");

                // Get All
                movies = api.MoviesWatched.GetAllMovies();
                foreach (Movie m in movies)
                {
                    PrintMovieInfo(m);
                }
            }
            catch (HttpOperationException ex)
            {
                Debug.WriteLine(ex.GetType());
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private static void PrintMovieInfo(Movie movie)
        {
            string movieInfo = string.Format("{0} {1} {2} {3}", movie.Id, movie.Name, movie.Rating, movie.Comment);
            Console.WriteLine(movieInfo);
        }
    }
}
