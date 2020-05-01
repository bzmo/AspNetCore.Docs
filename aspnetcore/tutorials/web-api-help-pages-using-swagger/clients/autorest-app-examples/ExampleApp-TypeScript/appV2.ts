import { MoviesWatchedAPI } from "./typescript/v2/src/moviesWatchedAPI";
import {
    Movie, MoviesWatchedAPIOptions, GetAllMoviesResponse, CreateMovieResponse, MoviesWatchedAPICreateMovieOptionalParams,
    MoviesWatchedAPIUpdateMovieByIdOptionalParams, GetMovieByIdResponse, MoviesWatchedAPIUpdateMovieRatingOptionalParams
} from "./typescript/v2/src/models/index";

export class appV2 {
    public static async SendAPIRequests(): Promise<void> {
        var apiOptions: MoviesWatchedAPIOptions = {
            baseUri: "https://localhost:44380"
        };
        var api: MoviesWatchedAPI = new MoviesWatchedAPI(apiOptions);

        var movie: Movie = {
            name: "Finding Nemo",
            rating: 4.7,
            comment: "Found!"
        }

        // Get All
        var getAllMoviesResponse: GetAllMoviesResponse = await api.getAllMovies();
        getAllMoviesResponse.forEach(movie => {
            this.PrintMovieInfo(movie);
        });

        console.log("-----------");

        // Create
        var createMovieOptions: MoviesWatchedAPICreateMovieOptionalParams = {
            body: movie
        };
        var createMovieResponse: CreateMovieResponse = await api.createMovie(createMovieOptions);
        movie = createMovieResponse._response.parsedBody;
        this.PrintMovieInfo(movie);

        console.log("-----------");

        var id: number = movie.id;

        // Update
        movie.rating = 4.7;
        movie.comment = "Found him!";
        var updateMovieOptions: MoviesWatchedAPIUpdateMovieByIdOptionalParams = {
            body: movie
        };
        await api.updateMovieById(id, updateMovieOptions);

        // Patch
        var updateMovieRatingOptions: MoviesWatchedAPIUpdateMovieRatingOptionalParams = {
            body: 4.9
        };
        await api.updateMovieRating(id, updateMovieRatingOptions);

        // Get
        var getMovieByIdResponse: GetMovieByIdResponse = await api.getMovieById(id);
        movie = getMovieByIdResponse._response.parsedBody;
        this.PrintMovieInfo(movie);

        // Delete
        await api.deleteMovieById(id);

        console.log("-----------");

        getAllMoviesResponse = await api.getAllMovies();
        getAllMoviesResponse.forEach(movie => {
            this.PrintMovieInfo(movie);
        });
    }

    public static PrintMovieInfo(movie: Movie): void {
        var movieInfo: string = `${movie.id} ${movie.name} ${movie.rating} ${movie.comment}`;
        console.log(movieInfo);
    }
}