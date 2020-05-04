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
const moviesWatchedAPI_1 = require("./typescript/v1/src/moviesWatchedAPI");
class appV1 {
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
                var getAllMoviesResponse = yield api.getAllMovies();
                getAllMoviesResponse.forEach((movie) => {
                    this.PrintMovieInfo(movie);
                });
                console.log("-----------");
                // Create
                var createMovieOptions = {
                    body: movie
                };
                var createMovieResponse = yield api.createMovie(createMovieOptions);
                this.ProcessResponse(createMovieResponse._response.parsedBody, (m) => {
                    movie = m;
                });
                var id = movie.id;
                console.log("-----------");
                // Update
                movie.rating = 4.7;
                movie.comment = "Found him!";
                var updateMovieOptions = {
                    body: movie
                };
                yield api.updateMovieById(id, updateMovieOptions);
                // Get
                var getMovieByIdResponse = yield api.getMovieById(id);
                this.ProcessResponse(getMovieByIdResponse._response.parsedBody);
                // Delete
                yield api.deleteMovieById(id);
                console.log("-----------");
                getAllMoviesResponse = yield api.getAllMovies();
                getAllMoviesResponse.forEach(movie => {
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
        var movieInfo = `${movie.id} ${movie.name} ${movie.rating} ${movie.comment}`;
        console.log(movieInfo);
    }
    static ProcessResponse(response, fn) {
        if (response == null) {
            return;
        }
        else {
            this.PrintMovieInfo(response);
            if (fn) {
                fn(response);
            }
        }
    }
}
exports.appV1 = appV1;
//# sourceMappingURL=appV1.js.map