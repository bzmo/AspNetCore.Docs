using System;
using System.Collections.Generic;
using System.Diagnostics;
using WatchedMovies.Rest;
using WatchedMovies.Rest.Models;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IMoviesWatchedAPI api = new MoviesWatchedAPI();
            api.BaseUri = new Uri("https://localhost:44380");
            string apiVersion = "1.0";

            Movie movie = new Movie("Finding Nemo", 4.7, null, "Found!");

            try
            {
                // Get All
                IList<Movie> movies = api.GetAllMovies(apiVersion);
                foreach (Movie m in movies)
                {
                    PrintMovieInfo(m);
                }

                Console.WriteLine("---");

                // Create
                movie = (Movie)api.CreateMovie(apiVersion, movie);
                PrintMovieInfo(movie);

                long id = movie.Id ?? 4;

                // Update
                movie.Rating = 4.7;
                movie.Comment = "Found him!";
                api.UpdateMovieByID(id, apiVersion, movie);

                // Get
                movie = (Movie)api.GetMovieByID(id, apiVersion);
                PrintMovieInfo(movie);

                // Delete
                api.DeleteMovieByID(id, apiVersion);

                Console.WriteLine("---");

                // Get All
                movies = api.GetAllMovies(apiVersion);
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
