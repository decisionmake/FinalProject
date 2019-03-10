using FinalProject.Models;
using FinalProject.Models.GenreSelection;
using FinalProject.Models.MoviePopularity;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Script.Serialization;
using static FinalProject.Models.GenreMovieModel;
using HttpCookie = System.Web.HttpCookie;

namespace FinalProject.BLL
{
    public class MovieApiCalls
    {

        public static MoviePopularityViewModel GetPopularMovies()
        {
            //var client = new RestClient("https://api.themoviedb.org/3/movie/popular?page=1&language=en-US&api_key=d4d54b8d7ddedcc20679758413820443");

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


            List<MoviePopularityResults> toCookie = new List<MoviePopularityResults>(); //create list to send to cookie
            toCookie.Add(movies.MovieOne); //add 2 movies
            toCookie.Add(movies.MovieTwo);
            string CookieAsString = JsonConvert.SerializeObject(toCookie); //serialize to json
            
            var cookie = HttpContext.Current.Request.Cookies.Get("information"); //pull cookie 


        
    

            if (cookie == null) //if no cookie, create, send two movies
            {
                HttpContext.Current.Response.SetCookie(new HttpCookie("information", CookieAsString));
            }
            else
            {

                var get = HttpContext.Current.Request.Cookies["information"].Value; //if cookie exists, grab it
              
            

                var result = JsonConvert.DeserializeObject<List<MoviePopularityResults>>(get); //break the cookie into objects
                foreach (var item in result)
                {
                    toCookie.Add(item); //add old movie objects to list of new movie objects
                }

                
                string sendSerialize = new JavaScriptSerializer().Serialize(toCookie); //serailze that 
                HttpContext.Current.Response.SetCookie(new HttpCookie("information", sendSerialize)); //send cookie back up


            }
                

                return movies;

        }

        public static GenreViewModel GetGenre()
        {
            var client = new RestClient("https://api.themoviedb.org/3/genre/movie/list?api_key=d4d54b8d7ddedcc20679758413820443&language=en-US");

            //var client = new RestClient("https://api.themoviedb.org/3/discover/movie?with_genres=27&include_video=false&include_adult=false&sort_by=popularity.desc&language=en-US&api_key=d4d54b8d7ddedcc20679758413820443");
            var request = new RestRequest(Method.GET);

            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute<GenreMovieModel>(request);

            var GenreLookup = JsonConvert.DeserializeObject<GenreRootObject>(response.Content);
            int[] randomNumber = RandomNumberGenerator.GetNumberMovie(GenreLookup.genres.Count());

            //List<Genre> GenreList = GenreLookup.genres.ToList();
            //Random rnd = new Random();
            //int index = rnd.Next(GenreList.Count);
            //int index2 = rnd.Next(GenreList.Count);
            //maybe add loop so that index and index 2 can never be equal?
            GenreViewModel selection = new GenreViewModel
            {
                GenreOne = GenreLookup.genres[randomNumber[0]],
                GenreTwo = GenreLookup.genres[randomNumber[1]]

            };

            return selection;
        }

        public static GenreSelectorViewModel GetByGenre(int id)
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

            //List<GenreMovieResult> NewList = jsonResults.results.ToList();
            //Random rnd = new Random();
            //int index = rnd.Next(NewList.Count);
            //int index2 = rnd.Next(NewList.Count);

            GenreSelectorViewModel GenreSelector = new GenreSelectorViewModel
            {
                GenreMovieOne = jsonResults.results[randomNumber[0]],
                GenreMovieTwo = jsonResults.results[randomNumber[1]]
            };

            return GenreSelector;
        }

         

    }
}