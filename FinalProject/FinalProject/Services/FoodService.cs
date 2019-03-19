using FinalProject.BLL;
using FinalProject.DAL;
using FinalProject.DAL.InformationTracking;
using FinalProject.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FinalProject.Services
{
    public class FoodService : IFoodService
    {

        public MovieVotingHistoryDbContext db()
        {
            MovieVotingHistoryDbContext db = new MovieVotingHistoryDbContext();

            return db;
        }

        public async Task<FoodViewModel> Index(string zip)
        {
            //var client = new RestClient("https://api.yelp.com/v3/businesses/search?term=Clayton+Bicycle+Center&location=5411+Clayton+Rd%2c+Clayton%2c+CA+94517%2c+US");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Authorization", "Bearer 4bgFll8jl2USaAQoHqIUIQ1QavZHqeYmRQwXXg_z5wUu4-nBDYdVmYwcr9ALDE-iUxMT_sGfhNOqIM_ZE0oVM9SQmmgo0YrpBLtYh5FIxOQaguiddnmU71RVxm6AXHYx ");
            //var response = client.Execute(request);
            //Console.Write(response.Content);

            var request = new Yelp.Api.Models.SearchRequest();
            request.Categories = "Restaurants";
            request.Location = $"{zip}";
            request.MaxResults = 40;
            request.OpenNow = true;



            var client = new Yelp.Api.Client("4bgFll8jl2USaAQoHqIUIQ1QavZHqeYmRQwXXg_z5wUu4-nBDYdVmYwcr9ALDE-iUxMT_sGfhNOqIM_ZE0oVM9SQmmgo0YrpBLtYh5FIxOQaguiddnmU71RVxm6AXHYx");
            Yelp.Api.Models.SearchResponse results = await client.SearchBusinessesAllAsync(request);
            int[] randomNumber = BLL.RandomNumberGenerator.GetNumberMovie(results.Businesses.Count()+1);
            do
            {





                FoodViewModel business = new FoodViewModel
                {
                    BusinessOne = results.Businesses[randomNumber[0]],
                    BusinessTwo = results.Businesses[randomNumber[1]]

                };

                return business;
                    } while (randomNumber[0] != 0 && randomNumber[1] != 0);
        }
        public void TrackFood(FoodSummary food, MovieVotingHistoryDbContext db)
        {
            DecisionLogger decisionLogger = new DecisionLogger();
           

                List<string> list = new List<string>();
                List<string> moviefood = HttpContext.Current.Session["moviefood"] as List<string>;
                if (moviefood == null)
                {

                    list.Add(food.Name);
                HttpContext.Current.Session.Add("moviefood", list);
                }
                else
                {
                    foreach (var item in moviefood)
                    {
                        list.Add(item);
                    }

                    list.Add(food.Name);
                    HttpContext.Current.Session.Add("moviefood", list);

                }
            

        }

        public void AddFood(MovieVotingHistoryDbContext db)
        {
          
            DecisionLogger decisionLogger = new DecisionLogger();
            decisionLogger.AddMovieFood(db);

        }

        public List<string> MoviePair(MovieVotingHistoryDbContext db)
        {
            Analytics pair = new Analytics();
           return pair.MovieFoodTracker(db);
        }
    }

}



