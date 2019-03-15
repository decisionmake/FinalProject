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
            int[] randomNumber = BLL.RandomNumberGenerator.GetNumberMovie(results.Businesses.Count() + 1);


            FoodViewModel business = new FoodViewModel
            {
                BusinessOne = results.Businesses[randomNumber[0]],
                BusinessTwo = results.Businesses[randomNumber[1]]

            };

            return business ;
        }


    }

}



