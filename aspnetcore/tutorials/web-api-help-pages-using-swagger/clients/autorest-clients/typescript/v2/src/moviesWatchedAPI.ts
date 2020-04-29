/*
 * Code generated by Microsoft (R) AutoRest Code Generator.
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

import * as msRest from "@azure/ms-rest-js";
import * as Models from "./models";
import * as Mappers from "./models/mappers";
import * as Parameters from "./models/parameters";
import { MoviesWatchedAPIContext } from "./moviesWatchedAPIContext";

class MoviesWatchedAPI extends MoviesWatchedAPIContext {
  /**
   * Initializes a new instance of the MoviesWatchedAPI class.
   * @param [options] The parameter options
   */
  constructor(options?: Models.MoviesWatchedAPIOptions) {
    super(options);
  }

  /**
   * Fetch all movies watched during COVID-19 shelter-in-place.
   * @summary Gets all watched movies sorted alphabetically.
   * @param [options] The optional parameters
   * @returns Promise<Models.GetAllMoviesResponse>
   */
  getAllMovies(options?: msRest.RequestOptionsBase): Promise<Models.GetAllMoviesResponse>;
  /**
   * @param callback The callback
   */
  getAllMovies(callback: msRest.ServiceCallback<Models.Movie[]>): void;
  /**
   * @param options The optional parameters
   * @param callback The callback
   */
  getAllMovies(options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.Movie[]>): void;
  getAllMovies(options?: msRest.RequestOptionsBase | msRest.ServiceCallback<Models.Movie[]>, callback?: msRest.ServiceCallback<Models.Movie[]>): Promise<Models.GetAllMoviesResponse> {
    return this.sendOperationRequest(
      {
        options
      },
      getAllMoviesOperationSpec,
      callback) as Promise<Models.GetAllMoviesResponse>;
  }

  /**
   * Record a movie watched during COVID-19 shelter-in-place.
   * @summary Creates a Movie.
   * @param [options] The optional parameters
   * @returns Promise<Models.CreateMovieResponse>
   */
  createMovie(options?: Models.MoviesWatchedAPICreateMovieOptionalParams): Promise<Models.CreateMovieResponse>;
  /**
   * @param callback The callback
   */
  createMovie(callback: msRest.ServiceCallback<any>): void;
  /**
   * @param options The optional parameters
   * @param callback The callback
   */
  createMovie(options: Models.MoviesWatchedAPICreateMovieOptionalParams, callback: msRest.ServiceCallback<any>): void;
  createMovie(options?: Models.MoviesWatchedAPICreateMovieOptionalParams | msRest.ServiceCallback<any>, callback?: msRest.ServiceCallback<any>): Promise<Models.CreateMovieResponse> {
    return this.sendOperationRequest(
      {
        options
      },
      createMovieOperationSpec,
      callback) as Promise<Models.CreateMovieResponse>;
  }

  /**
   * Updates movie rating.
   * @summary Updates a rating of a specific Movie.
   * @param id Movie ID
   * @param [options] The optional parameters
   * @returns Promise<Models.UpdateMovieRatingResponse>
   */
  updateMovieRating(id: number, options?: Models.MoviesWatchedAPIUpdateMovieRatingOptionalParams): Promise<Models.UpdateMovieRatingResponse>;
  /**
   * @param id Movie ID
   * @param callback The callback
   */
  updateMovieRating(id: number, callback: msRest.ServiceCallback<Models.ProblemDetails>): void;
  /**
   * @param id Movie ID
   * @param options The optional parameters
   * @param callback The callback
   */
  updateMovieRating(id: number, options: Models.MoviesWatchedAPIUpdateMovieRatingOptionalParams, callback: msRest.ServiceCallback<Models.ProblemDetails>): void;
  updateMovieRating(id: number, options?: Models.MoviesWatchedAPIUpdateMovieRatingOptionalParams | msRest.ServiceCallback<Models.ProblemDetails>, callback?: msRest.ServiceCallback<Models.ProblemDetails>): Promise<Models.UpdateMovieRatingResponse> {
    return this.sendOperationRequest(
      {
        id,
        options
      },
      updateMovieRatingOperationSpec,
      callback) as Promise<Models.UpdateMovieRatingResponse>;
  }

  /**
   * Fetch a movie watched during COVID-19 shelter-in-place.
   * @summary Gets a specific movie by its ID.
   * @param id Movie ID
   * @param [options] The optional parameters
   * @returns Promise<Models.GetMovieByIdResponse>
   */
  getMovieById(id: number, options?: msRest.RequestOptionsBase): Promise<Models.GetMovieByIdResponse>;
  /**
   * @param id Movie ID
   * @param callback The callback
   */
  getMovieById(id: number, callback: msRest.ServiceCallback<any>): void;
  /**
   * @param id Movie ID
   * @param options The optional parameters
   * @param callback The callback
   */
  getMovieById(id: number, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<any>): void;
  getMovieById(id: number, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<any>, callback?: msRest.ServiceCallback<any>): Promise<Models.GetMovieByIdResponse> {
    return this.sendOperationRequest(
      {
        id,
        options
      },
      getMovieByIdOperationSpec,
      callback) as Promise<Models.GetMovieByIdResponse>;
  }

  /**
   * Changes the information for a watched movie.
   * @summary Updates an existing Movie.
   * @param id Movie ID
   * @param [options] The optional parameters
   * @returns Promise<Models.UpdateMovieByIdResponse>
   */
  updateMovieById(id: number, options?: Models.MoviesWatchedAPIUpdateMovieByIdOptionalParams): Promise<Models.UpdateMovieByIdResponse>;
  /**
   * @param id Movie ID
   * @param callback The callback
   */
  updateMovieById(id: number, callback: msRest.ServiceCallback<Models.ProblemDetails>): void;
  /**
   * @param id Movie ID
   * @param options The optional parameters
   * @param callback The callback
   */
  updateMovieById(id: number, options: Models.MoviesWatchedAPIUpdateMovieByIdOptionalParams, callback: msRest.ServiceCallback<Models.ProblemDetails>): void;
  updateMovieById(id: number, options?: Models.MoviesWatchedAPIUpdateMovieByIdOptionalParams | msRest.ServiceCallback<Models.ProblemDetails>, callback?: msRest.ServiceCallback<Models.ProblemDetails>): Promise<Models.UpdateMovieByIdResponse> {
    return this.sendOperationRequest(
      {
        id,
        options
      },
      updateMovieByIdOperationSpec,
      callback) as Promise<Models.UpdateMovieByIdResponse>;
  }

  /**
   * Removes a watched movie.
   * @summary Deletes a specific Movie.
   * @param id Movie ID
   * @param [options] The optional parameters
   * @returns Promise<Models.DeleteMovieByIdResponse>
   */
  deleteMovieById(id: number, options?: msRest.RequestOptionsBase): Promise<Models.DeleteMovieByIdResponse>;
  /**
   * @param id Movie ID
   * @param callback The callback
   */
  deleteMovieById(id: number, callback: msRest.ServiceCallback<Models.ProblemDetails>): void;
  /**
   * @param id Movie ID
   * @param options The optional parameters
   * @param callback The callback
   */
  deleteMovieById(id: number, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.ProblemDetails>): void;
  deleteMovieById(id: number, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<Models.ProblemDetails>, callback?: msRest.ServiceCallback<Models.ProblemDetails>): Promise<Models.DeleteMovieByIdResponse> {
    return this.sendOperationRequest(
      {
        id,
        options
      },
      deleteMovieByIdOperationSpec,
      callback) as Promise<Models.DeleteMovieByIdResponse>;
  }
}

// Operation Specifications
const serializer = new msRest.Serializer(Mappers);
const getAllMoviesOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "api/v2/MoviesWatched",
  responses: {
    200: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "Movie"
            }
          }
        }
      }
    },
    default: {}
  },
  serializer
};

const createMovieOperationSpec: msRest.OperationSpec = {
  httpMethod: "POST",
  path: "api/v2/MoviesWatched",
  requestBody: {
    parameterPath: [
      "options",
      "body"
    ],
    mapper: Mappers.Movie
  },
  responses: {
    201: {
      bodyMapper: Mappers.Movie
    },
    400: {
      bodyMapper: Mappers.ProblemDetails
    },
    default: {}
  },
  serializer
};

const updateMovieRatingOperationSpec: msRest.OperationSpec = {
  httpMethod: "PATCH",
  path: "api/v2/MoviesWatched/{id}",
  urlParameters: [
    Parameters.id
  ],
  requestBody: {
    parameterPath: [
      "options",
      "body"
    ],
    mapper: {
      serializedName: "body",
      type: {
        name: "Number"
      }
    }
  },
  responses: {
    204: {},
    404: {
      bodyMapper: Mappers.ProblemDetails
    },
    default: {}
  },
  serializer
};

const getMovieByIdOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "api/v2/MoviesWatched/{id}",
  urlParameters: [
    Parameters.id
  ],
  responses: {
    200: {
      bodyMapper: Mappers.Movie
    },
    404: {
      bodyMapper: Mappers.ProblemDetails
    },
    default: {}
  },
  serializer
};

const updateMovieByIdOperationSpec: msRest.OperationSpec = {
  httpMethod: "PUT",
  path: "api/v2/MoviesWatched/{id}",
  urlParameters: [
    Parameters.id
  ],
  requestBody: {
    parameterPath: [
      "options",
      "body"
    ],
    mapper: Mappers.Movie
  },
  responses: {
    204: {},
    400: {
      bodyMapper: Mappers.ProblemDetails
    },
    404: {
      bodyMapper: Mappers.ProblemDetails
    },
    default: {}
  },
  serializer
};

const deleteMovieByIdOperationSpec: msRest.OperationSpec = {
  httpMethod: "DELETE",
  path: "api/v2/MoviesWatched/{id}",
  urlParameters: [
    Parameters.id
  ],
  responses: {
    204: {},
    404: {
      bodyMapper: Mappers.ProblemDetails
    },
    default: {}
  },
  serializer
};

export {
  MoviesWatchedAPI,
  MoviesWatchedAPIContext,
  Models as MoviesWatchedAPIModels,
  Mappers as MoviesWatchedAPIMappers
};
