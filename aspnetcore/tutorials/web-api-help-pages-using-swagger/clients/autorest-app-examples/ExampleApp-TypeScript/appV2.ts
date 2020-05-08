import { MoviesWatchedAPI } from "./typescript/v2/src/moviesWatchedAPI";
import * as model from "./typescript/v2/src/models/index";

type MovieOrProblemDetails = model.Movie | null;

export class appV2 {

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
            var getAllMoviesResponse: model.MoviesWatchedGetAllMoviesResponse = await api.moviesWatched.getAllMovies();
            getAllMoviesResponse.forEach((movie: model.Movie) => {
                this.PrintMovieInfo(movie);
            });

            console.log("-----------");

            // Create
            var createMovieOptions: model.MoviesWatchedCreateMovieOptionalParams = {
                body: movie
            };
            var createMovieResponse: model.MoviesWatchedCreateMovieResponse = await api.moviesWatched.createMovie(createMovieOptions);
            this.ProcessResponse(createMovieResponse._response.parsedBody, (m: model.Movie): void => {
                movie = m;
            });

            console.log("-----------");

            var id: number = movie.id;

            // Update
            movie.rating = 4.7;
            movie.comment = "Found him!";
            var updateMovieOptions: model.MoviesWatchedUpdateMovieByIdOptionalParams = {
                body: movie
            };
            await api.moviesWatched.updateMovieById(id, updateMovieOptions);

            // Patch
            var updateMovieRatingOptions: model.MoviesWatchedUpdateMovieRatingOptionalParams = {
                body: 4.9
            };
            var updateMovieRatingResponse = await api.moviesWatched.updateMovieRating(id, updateMovieRatingOptions);
            this.ProcessResponse(updateMovieRatingResponse._response.parsedBody);

            // Get
            var getMovieByIdResponse: model.MoviesWatchedGetMovieByIdResponse = await api.moviesWatched.getMovieById(id);
            this.ProcessResponse(getMovieByIdResponse._response.parsedBody);

            // Delete
            await api.moviesWatched.deleteMovieById(id);

            console.log("-----------");

            getAllMoviesResponse = await api.moviesWatched.getAllMovies();
            getAllMoviesResponse.forEach(movie => {
                this.PrintMovieInfo(movie);
            });
        } catch(error) {
            console.log(error.statusCode);
            console.log(error.response);
            console.log(error.stack);
        }
    }

    public static PrintMovieInfo(movie: model.Movie): void {
        var movieInfo: string = `${movie.id} ${movie.name} ${movie.rating} ${movie.comment}`;
        console.log(movieInfo);
    }

    private static ProcessResponse(response: MovieOrProblemDetails, fn?: Function): void {
        if (response == null) {
            return;
        } else {
            this.PrintMovieInfo(response);
            if (fn) {
                fn(response);
            }
        }
    }
}