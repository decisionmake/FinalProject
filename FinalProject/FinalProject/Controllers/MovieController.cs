using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using RestSharp.Serialization.Json;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using static FinalProject.Models.GenreMovieModel;
using FinalProject.Models.MoviePopularity;

namespace FinalProject.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Genre()
        {
            var client = new RestClient("https://api.themoviedb.org/3/search/movie?include_adult=false&page=1&query=anchorman%202&language=en-US&api_key=d4d54b8d7ddedcc20679758413820443");

            //var client = new RestClient("https://api.themoviedb.org/3/discover/movie?with_genres=27&include_video=false&include_adult=false&sort_by=popularity.desc&language=en-US&api_key=d4d54b8d7ddedcc20679758413820443");
            var request = new RestRequest(Method.GET);
           
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute<GenreMovieModel>(request);
            var movie = new GenreMovieModel();
            var deserial = new JsonDeserializer();
            //var x = deserial.Deserialize<GenreMovieModel>(response);
            var customerDto = JsonConvert.DeserializeObject<RootObject>(response.Content);
            

            return View(response);
        }

        public ActionResult Popular()
        {
            var client = new RestClient("https://api.themoviedb.org/3/movie/popular?page=1&language=en-US&api_key=d4d54b8d7ddedcc20679758413820443");
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var jsonResults = JsonConvert.DeserializeObject<MoviePopularityRoot>(response.Content);

            MoviePopularityViewModel movies = new MoviePopularityViewModel
            {
                MovieOne = jsonResults.results[0],
                MovieTwo = jsonResults.results[1]
            };

            return View(movies);
        }

    }
}