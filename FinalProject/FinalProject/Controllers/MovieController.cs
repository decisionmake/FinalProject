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
using FinalProject.Models.GenreSelection;
using FinalProject.BLL;

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
            var client = new RestClient("https://api.themoviedb.org/3/genre/movie/list?api_key=d4d54b8d7ddedcc20679758413820443&language=en-US");

            //var client = new RestClient("https://api.themoviedb.org/3/discover/movie?with_genres=27&include_video=false&include_adult=false&sort_by=popularity.desc&language=en-US&api_key=d4d54b8d7ddedcc20679758413820443");
            var request = new RestRequest(Method.GET);
           
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute<GenreMovieModel>(request);
            
            var GenreLookup = JsonConvert.DeserializeObject<RootObject>(response.Content);
            List<Genre> GenreList = GenreLookup.genres.ToList();
            Random rnd = new Random();
            int index = rnd.Next(GenreList.Count);
            int index2 = rnd.Next(GenreList.Count); 
            //maybe add loop so that index and index 2 can never be equal?
            GenreViewModel selection = new GenreViewModel
            {
                GenreOne = GenreLookup.genres[index],
                GenreTwo = GenreLookup.genres[index2]

            };
           
            return View(selection);
        }

        public ActionResult Popular()
        {
            //var client = new RestClient("https://api.themoviedb.org/3/movie/popular?page=1&language=en-US&api_key=d4d54b8d7ddedcc20679758413820443");
            //var request = new RestRequest(Method.GET);
            //request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);

            //var jsonResults = JsonConvert.DeserializeObject<MoviePopularityRoot>(response.Content);


            //int[] randomNumber = RandomNumberGenerator.GetNumber(jsonResults.results.Count());
            //MoviePopularityViewModel movies = new MoviePopularityViewModel
            //{
            //    MovieOne = jsonResults.results[randomNumber[0]],
            //    MovieTwo = jsonResults.results[randomNumber[1]]
            //};

            return View(MovieApiCalls.GetPopularMovies());
        }

    }
}