"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const moviesWatchedAPI_1 = require("./typescript/v2/src/moviesWatchedAPI");
class appV2 {
    static SendAPIRequests() {
        return __awaiter(this, void 0, void 0, function* () {
            var apiOptions = {
                baseUri: "https://localhost:44380"
            };
            var api = new moviesWatchedAPI_1.MoviesWatchedAPI(apiOptions);
            var movie = {
                name: "Finding Nemo",
                rating: 4.7,
                comment: "Found!"
            };
            try {
                // Get All
                var movies = yield api.moviesWatched.getAllMovies();
                movies.forEach((movie) => {
                    this.PrintMovieInfo(movie);
                });
                console.log("-----------");
                // Create
                var createMovieOptions = {
                    body: movie
                };
                movie = yield api.moviesWatched.createMovie(createMovieOptions);
                this.PrintMovieInfo(movie);
                console.log("-----------");
                var id = movie.id;
                // Update
                movie.rating = 4.7;
                movie.comment = "Found him!";
                var updateMovieOptions = {
                    body: movie
                };
                yield api.moviesWatched.updateMovieById(id, updateMovieOptions);
                // Patch
                var updateMovieRatingOptions = {
                    body: 4.9
                };
                yield api.moviesWatched.updateMovieRating(id, updateMovieRatingOptions);
                // Get
                movie = yield api.moviesWatched.getMovieById(id);
                this.PrintMovieInfo(movie);
                // Delete
                yield api.moviesWatched.deleteMovieById(id);
                console.log("-----------");
                movies = yield api.moviesWatched.getAllMovies();
                movies.forEach(movie => {
                    this.PrintMovieInfo(movie);
                });
            }
            catch (error) {
                console.log(error.statusCode);
                console.log(error.response);
                console.log(error.stack);
            }
        });
    }
    static PrintMovieInfo(movie) {
        if (movie == null)
            return;
        var movieInfo = `${movie.id} ${movie.name} ${movie.rating} ${movie.comment}`;
        console.log(movieInfo);
    }
}
exports.appV2 = appV2;
//# sourceMappingURL=appV2.js.map