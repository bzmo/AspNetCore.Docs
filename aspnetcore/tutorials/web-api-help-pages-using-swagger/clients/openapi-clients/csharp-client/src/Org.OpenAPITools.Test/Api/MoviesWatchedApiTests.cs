/* 
 * Movies Watched API
 *
 * A simple example of ASP.NET Core Web API for movies watched during COVID-19 shelter-in-place.
 *
 * The version of the OpenAPI document: v1
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test
{
    /// <summary>
    ///  Class for testing MoviesWatchedApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class MoviesWatchedApiTests
    {
        private MoviesWatchedApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new MoviesWatchedApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of MoviesWatchedApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' MoviesWatchedApi
            //Assert.IsInstanceOf(typeof(MoviesWatchedApi), instance);
        }

        
        /// <summary>
        /// Test CreateMovie
        /// </summary>
        [Test]
        public void CreateMovieTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string version = null;
            //Movie movie = null;
            //var response = instance.CreateMovie(version, movie);
            //Assert.IsInstanceOf(typeof(Movie), response, "response is Movie");
        }
        
        /// <summary>
        /// Test DeleteMovieByID
        /// </summary>
        [Test]
        public void DeleteMovieByIDTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long id = null;
            //string version = null;
            //var response = instance.DeleteMovieByID(id, version);
            //Assert.IsInstanceOf(typeof(Movie), response, "response is Movie");
        }
        
        /// <summary>
        /// Test GetAllMovies
        /// </summary>
        [Test]
        public void GetAllMoviesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string version = null;
            //var response = instance.GetAllMovies(version);
            //Assert.IsInstanceOf(typeof(List<Movie>), response, "response is List<Movie>");
        }
        
        /// <summary>
        /// Test GetMovieByID
        /// </summary>
        [Test]
        public void GetMovieByIDTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long id = null;
            //string version = null;
            //var response = instance.GetMovieByID(id, version);
            //Assert.IsInstanceOf(typeof(Movie), response, "response is Movie");
        }
        
        /// <summary>
        /// Test UpdateMovieByID
        /// </summary>
        [Test]
        public void UpdateMovieByIDTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long id = null;
            //string version = null;
            //Movie movie = null;
            //var response = instance.UpdateMovieByID(id, version, movie);
            //Assert.IsInstanceOf(typeof(Movie), response, "response is Movie");
        }
        
    }

}