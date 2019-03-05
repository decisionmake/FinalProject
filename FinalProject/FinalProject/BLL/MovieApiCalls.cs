using FinalProject.Models.MoviePopularity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.BLL
{
    public class MovieApiCalls
    {

        public static MoviePopularityViewModel GetPopularMovies()
        {
            var client = new RestClient("https://api.themoviedb.org/3/movie/popular?page=1&language=en-US&api_key=d4d54b8d7ddedcc20679758413820443");
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var jsonResults = JsonConvert.DeserializeObject<MoviePopularityRoot>(response.Content);

            int[] randomNumber = RandomNumberGenerator.GetNumber(jsonResults.results.Count());
            MoviePopularityViewModel movies = new MoviePopularityViewModel
            {
                MovieOne = jsonResults.results[randomNumber[0]],
                MovieTwo = jsonResults.results[randomNumber[1]]
            };

            return movies;

        }


    }
}