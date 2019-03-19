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
using System.Text.RegularExpressions;

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
            if (zip == null || zip.Length < 5 || Regex.IsMatch(zip, @"^[0-9]+$") == false)
            {
                ViewBag.Message = "Invalid Entry";
                return RedirectToAction("index", "home");
            }
            
            return View(await _service.Index(zip));
        }

        public ActionResult FoodSummary(FoodSummary selection)
        {
            selection.MoviePair = _service.MoviePair(_service.db());
            _service.TrackFood(selection,_service.db());
            _service.AddFood(_service.db());
            return View(selection);
            
        }
        

    }
}