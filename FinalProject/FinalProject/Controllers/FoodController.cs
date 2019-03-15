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
using FinalProject.Services;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService _service;

        public FoodController(IFoodService service)
        {
            _service = service;
        }

        // GET: Food
        [HttpPost]
        public async Task<ActionResult> Index(string zip)
        {


             var x = await _service.Index(zip);
            
            return View(x);
        }

        public ActionResult FoodSummary(FoodSummary selection)
        {
            

            return View(selection);


        }
        

    }
}