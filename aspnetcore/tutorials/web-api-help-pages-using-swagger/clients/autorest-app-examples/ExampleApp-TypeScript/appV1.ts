import { MoviesWatchedAPI } from "./typescript/v1/src/moviesWatchedAPI";
import * as model from "./typescript/v1/src/models/index";

type MovieOrProblemDetails = model.Movie | null;

export class appV1 {

    public static async SendAPIRequests(): Promise<void> {
        var apiOptions: model.MoviesWatchedAPIOptions = {
            baseUri: "https://localhost:44380"
        };
      var api: MoviesWatchedAPI = new MoviesWatchedAPI(apiOptions);

        var movie: model.Movie = {
            name: "Finding Nemo",
            rating: 4.7,
            comment: "Found!"
        }

        try {
            // Get All
          var movies: model.Movie[] = await api.moviesWatched.getAllMovies();
          movies.forEach((movie: model.Movie) => {
              this.PrintMovieInfo(movie);
          });

          console.log("-----------");

          // Create
          var createMovieOptions: model.MoviesWatchedCreateMovieOptionalParams = {
              body: movie
          };
          movie = await api.moviesWatched.createMovie(createMovieOptions);
          this.PrintMovieInfo(movie);

          var id: number = movie.id;

          console.log("-----------");

          // Update
          movie.rating = 4.7;
          movie.comment = "Found him!";
          var updateMovieOptions: model.MoviesWatchedUpdateMovieByIdOptionalParams = {
              body: movie
          };
          await api.moviesWatched.updateMovieById(id, updateMovieOptions);

          // Get
          movie = await api.moviesWatched.getMovieById(id);
          this.PrintMovieInfo(movie);

          // Delete
          await api.moviesWatched.deleteMovieById(id);

          console.log("-----------");

          movies = await api.moviesWatched.getAllMovies();
          movies.forEach(movie => {
              this.PrintMovieInfo(movie);
          });
        } catch (error) {
            console.log(error.statusCode);
            console.log(error.response);
            console.log(error.stack);
        }
    }

  public static PrintMovieInfo(movie: model.Movie): void {
        if (movie == null) return;
        var movieInfo: string = `${movie.id} ${movie.name} ${movie.rating} ${movie.comment}`;
        console.log(movieInfo);
    }
}