using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using FinalProject.BLL;
using Yelp.Api.Models;
using FinalProject.Models.FoodModels;

namespace FinalProject.Controllers
{
    public class FoodController : Controller
    {
        
        // GET: Food
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(string zip)
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
            request.MaxResults = 100;
            request.OpenNow = true;
            request.Radius = 10;

            var client = new Yelp.Api.Client("4bgFll8jl2USaAQoHqIUIQ1QavZHqeYmRQwXXg_z5wUu4-nBDYdVmYwcr9ALDE-iUxMT_sGfhNOqIM_ZE0oVM9SQmmgo0YrpBLtYh5FIxOQaguiddnmU71RVxm6AXHYx");
            var results = await client.SearchBusinessesAllAsync(request);
            int[] randomNumber = BLL.RandomNumberGenerator.GetNumber(results.Businesses.Count);

            FoodViewModel business = new FoodViewModel
            {
                BusinessOne = results.Businesses[randomNumber[0]],
                BusinessTwo = results.Businesses[randomNumber[1]]
                
            };
            


            return View(business);
        }
    }
}