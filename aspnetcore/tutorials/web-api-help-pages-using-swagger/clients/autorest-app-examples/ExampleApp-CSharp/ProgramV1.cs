using System;
using System.Collections.Generic;
using System.Diagnostics;
using WatchedMovies.Rest.v1;
using WatchedMovies.Rest.v1.Models;

namespace ExampleApp
{
    class ProgramV1
    {
        public static void SendAPIRequests(string[] args)
        {
            Uri baseUri = new Uri("https://localhost:44380");
            IMoviesWatchedAPI api = new MoviesWatchedAPI(baseUri);

            Movie movie = new Movie("Finding Nemo", 4.7, null, "Found!");

            try
            {
                // Get All
                IList<Movie> movies = api.GetAllMovies();
                foreach (Movie m in movies)
                {
                    PrintMovieInfo(m);
                }

                Console.WriteLine("---");

                // Create
                movie = api.CreateMovie(movie);
                PrintMovieInfo(movie);

                long id = movie.Id ?? 4;

                // Update
                movie.Rating = 4.7;
                movie.Comment = "Found him!";
                api.UpdateMovieById(id, movie);

                // Get
                movie = api.GetMovieById(id);
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
