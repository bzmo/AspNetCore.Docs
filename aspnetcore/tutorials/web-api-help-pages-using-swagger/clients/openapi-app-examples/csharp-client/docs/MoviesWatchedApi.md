# Org.OpenAPITools.Api.MoviesWatchedApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateMovie**](MoviesWatchedApi.md#createmovie) | **POST** /api/v{version}/MoviesWatched | Creates a Movie.
[**DeleteMovieByID**](MoviesWatchedApi.md#deletemoviebyid) | **DELETE** /api/v{version}/MoviesWatched/{id} | Deletes a specific Movie.
[**GetAllMovies**](MoviesWatchedApi.md#getallmovies) | **GET** /api/v{version}/MoviesWatched | Gets all watched movies.
[**GetMovieByID**](MoviesWatchedApi.md#getmoviebyid) | **GET** /api/v{version}/MoviesWatched/{id} | Gets a specific movie by its ID.
[**UpdateMovieByID**](MoviesWatchedApi.md#updatemoviebyid) | **PUT** /api/v{version}/MoviesWatched/{id} | Updates an existing Movie.



## CreateMovie

> Movie CreateMovie (string version, Movie movie = null)

Creates a Movie.

Record a movie watched during COVID-19 shelter-in-place.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateMovieExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new MoviesWatchedApi(Configuration.Default);
            var version = version_example;  // string | 
            var movie = new Movie(); // Movie |  (optional) 

            try
            {
                // Creates a Movie.
                Movie result = apiInstance.CreateMovie(version, movie);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling MoviesWatchedApi.CreateMovie: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **version** | **string**|  | 
 **movie** | [**Movie**](Movie.md)|  | [optional] 

### Return type

[**Movie**](Movie.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/_*+json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The movie was created. |  -  |
| **400** | The movie data is invalid. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteMovieByID

> Movie DeleteMovieByID (long id, string version)

Deletes a specific Movie.

Removes a watched movie.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteMovieByIDExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new MoviesWatchedApi(Configuration.Default);
            var id = 789;  // long | Movie ID
            var version = version_example;  // string | 

            try
            {
                // Deletes a specific Movie.
                Movie result = apiInstance.DeleteMovieByID(id, version);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling MoviesWatchedApi.DeleteMovieByID: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **long**| Movie ID | 
 **version** | **string**|  | 

### Return type

[**Movie**](Movie.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The movie was deleted. |  -  |
| **404** | The movie was not found. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetAllMovies

> List&lt;Movie&gt; GetAllMovies (string version)

Gets all watched movies.

Fetch all movies watched during COVID-19 shelter-in-place.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetAllMoviesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new MoviesWatchedApi(Configuration.Default);
            var version = version_example;  // string | 

            try
            {
                // Gets all watched movies.
                List<Movie> result = apiInstance.GetAllMovies(version);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling MoviesWatchedApi.GetAllMovies: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **version** | **string**|  | 

### Return type

[**List&lt;Movie&gt;**](Movie.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Movies have been fetched |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetMovieByID

> Movie GetMovieByID (long id, string version)

Gets a specific movie by its ID.

Fetch a movie watched during COVID-19 shelter-in-place.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetMovieByIDExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new MoviesWatchedApi(Configuration.Default);
            var id = 789;  // long | Movie ID
            var version = version_example;  // string | 

            try
            {
                // Gets a specific movie by its ID.
                Movie result = apiInstance.GetMovieByID(id, version);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling MoviesWatchedApi.GetMovieByID: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **long**| Movie ID | 
 **version** | **string**|  | 

### Return type

[**Movie**](Movie.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The movie was found. |  -  |
| **404** | The movie was not found. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpdateMovieByID

> Movie UpdateMovieByID (long id, string version, Movie movie = null)

Updates an existing Movie.

Changes the information for a watched movie.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateMovieByIDExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new MoviesWatchedApi(Configuration.Default);
            var id = 789;  // long | Movie ID
            var version = version_example;  // string | 
            var movie = new Movie(); // Movie |  (optional) 

            try
            {
                // Updates an existing Movie.
                Movie result = apiInstance.UpdateMovieByID(id, version, movie);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling MoviesWatchedApi.UpdateMovieByID: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **long**| Movie ID | 
 **version** | **string**|  | 
 **movie** | [**Movie**](Movie.md)|  | [optional] 

### Return type

[**Movie**](Movie.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/_*+json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The movie was updated. |  -  |
| **400** | The movie data is invalid. |  -  |
| **404** | The movie was not found. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

