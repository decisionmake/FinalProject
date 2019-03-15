using FinalProject.BLL;
using FinalProject.Models;
using FinalProject.Models.GenreSelection;
using FinalProject.Models.MoviePopularity;
using FinalProject.Service;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using HttpCookie = System.Web.HttpCookie;

namespace FinalProject.Service
{
    public class MovieHistoryService : IMovieHistoryService
    {
        public MoviePopularityViewModel GetPopularMovies()
        {
            int page = RandomNumberGenerator.GetNumberApiPage(5);
            var client = new RestClient("https://api.themoviedb.org/3/movie/popular?api_key=d4d54b8d7ddedcc20679758413820443&language=en-US&page="
                                         + page);

            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var jsonResults = JsonConvert.DeserializeObject<MoviePopularityRoot>(response.Content);

            int[] randomNumber = RandomNumberGenerator.GetNumberMovie(jsonResults.results.Count());
            MoviePopularityViewModel movies = new MoviePopularityViewModel
            {
                MovieOne = jsonResults.results[randomNumber[0]],
                MovieTwo = jsonResults.results[randomNumber[1]]
            };
            SessionStorage.StorePopular(movies);

                return movies;

        }

        public GenreViewModel GetGenre()
        {
            var client = new RestClient("https://api.themoviedb.org/3/genre/movie/list?api_key=d4d54b8d7ddedcc20679758413820443&language=en-US");

             var request = new RestRequest(Method.GET);

            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute<GenreMovieModel>(request);

            var GenreLookup = JsonConvert.DeserializeObject<GenreRootObject>(response.Content);
            int[] randomNumber = RandomNumberGenerator.GetNumberMovie(GenreLookup.genres.Count());

            GenreViewModel selection = new GenreViewModel
            {
                GenreOne = GenreLookup.genres[randomNumber[0]],
                GenreTwo = GenreLookup.genres[randomNumber[1]]

            };

            return selection;
        }

        public GenreSelectorViewModel GetByGenre(int id)
        {

            var x = id;
            int[] y = {1,2,3,4,5};
            int z = RandomNumberGenerator.GetNumberApiPage(y.Count());
            string testUrl = $"api.themoviedb.org/3/discover/movie?api_key=d4d54b8d7ddedcc20679758413820443&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page={z}&with_genres={x}";
            var client = new RestClient($"https://" + testUrl);
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            
            var deserial = new JsonDeserializer();

            var jsonResults = JsonConvert.DeserializeObject<GenreRootObject>(response.Content);
            int[] randomNumber = RandomNumberGenerator.GetNumberMovie(jsonResults.results.Count());


            GenreSelectorViewModel GenreSelector = new GenreSelectorViewModel
            {
                GenreMovieOne = jsonResults.results[randomNumber[0]],
                GenreMovieTwo = jsonResults.results[randomNumber[1]]
            };

            SessionStorage.StoreGenre(GenreSelector);

            return GenreSelector;
        }
    }

}


