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
            return View(MovieApiCalls.GetGenre());
        }

        public ActionResult Popular()
        {

            Session.Add("test2", "test2");
            var test = Session.Count;

            Session.Clear();
            test = Session.Count;

            return View(MovieApiCalls.GetPopularMovies());
        }

        public ActionResult GenreMovieSelector(int id)
        {
            return View(MovieApiCalls.GetByGenre(id));
        }

    }
}