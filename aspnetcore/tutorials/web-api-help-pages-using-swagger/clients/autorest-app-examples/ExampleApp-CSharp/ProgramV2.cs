using System;
using System.Collections.Generic;
using System.Diagnostics;
using WatchedMovies.Rest.v2;
using WatchedMovies.Rest.v2.Models;

namespace ExampleApp
{
    class ProgramV2
    {
        public static void SendAPIRequests(string[] args)
        {
            IMoviesWatchedAPI api = new MoviesWatchedAPI();
            api.BaseUri = new Uri("https://localhost:44380");

            Movie movie = new Movie("Finding Nemo", 4.7, null, "Found!");

            try
            {
                // Get All
                Console.WriteLine("Movies now sorted!");
                IList<Movie> movies = api.GetAllMovies();
                foreach (Movie m in movies)
                {
                    PrintMovieInfo(m);
                }

                Console.WriteLine("---");

                // Create
                movie = (Movie)api.CreateMovie(movie);
                PrintMovieInfo(movie);

                Console.WriteLine("---");

                long id = movie.Id ?? 4;

                // Update
                movie.Rating = 4.7;
                movie.Comment = "Found him!";
                api.UpdateMovieById(id, movie);

                // Patch
                api.UpdateMovieRating(id, 4.9);
                Console.WriteLine("Patch Request made!");

                // Get
                movie = (Movie)api.GetMovieById(id);
                PrintMovieInfo(movie);

                // Delete
                api.DeleteMovieById(id);

                Console.WriteLine("---");

                // Get All
                movies = api.GetAllMovies();
                foreach (Movie m in movies)
                {
                    PrintMovieInfo(m);
                }
            } catch(Exception ex)
            {
                Debug.WriteLine(ex.GetType());
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        static void PrintMovieInfo(Movie movie)
        {
            string movieInfo = string.Format("{0} {1} {2} {3}", movie.Id, movie.Name, movie.Rating, movie.Comment);
            Console.WriteLine(movieInfo);
        }
    }
}
