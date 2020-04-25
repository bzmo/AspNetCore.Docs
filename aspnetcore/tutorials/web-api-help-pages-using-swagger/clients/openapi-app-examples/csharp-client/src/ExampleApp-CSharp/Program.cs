using System;
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration.Default.BasePath = "https://localhost:44380";
            IMoviesWatchedApi apiInstance = new MoviesWatchedApi(Configuration.Default);
            string apiVersion = "1.0";  // string | 

            Movie movie = new Movie(0, "Finding Nemo", 4.7, "Found!");

            try
            {
                // Get All
                IList<Movie> movies = apiInstance.GetAllMovies(apiVersion);
                foreach (Movie m in movies)
                {
                    PrintMovieInfo(m);
                }
                
                Console.WriteLine("---");

                // Create
                movie = apiInstance.CreateMovie(apiVersion, movie);
                PrintMovieInfo(movie);

                long id = movie.Id;

                // Update
                movie.Rating = 4.7;
                movie.Comment = "Found him!";
                apiInstance.UpdateMovieByID(id, apiVersion, movie);

                // Get
                movie = apiInstance.GetMovieByID(id, apiVersion);
                PrintMovieInfo(movie);

                // Delete
                apiInstance.DeleteMovieByID(id, apiVersion);

                Console.WriteLine("---");

                // Get All
                movies = apiInstance.GetAllMovies(apiVersion);
                foreach (Movie m in movies)
                {
                    PrintMovieInfo(m);
                }  
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling MoviesWatchedApi.CreateMovie: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }

        static void PrintMovieInfo(Movie movie)
        {
            string movieInfo = string.Format("{0} {1} {2} {3}", movie.Id, movie.Name, movie.Rating, movie.Comment);
            Console.WriteLine(movieInfo);
        }
    }
}