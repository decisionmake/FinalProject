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
            //List<MoviePopularityViewModel> list = new List<MoviePopularityViewModel>();
            //List<MoviePopularityViewModel> x = Session["information"] as List<MoviePopularityViewModel>;
            //if (x == null)
            //{
            //    list.Add(MovieApiCalls.GetPopularMovies());
            //    Session.Add("information", list);
            //}
            //else
            //{
            //    foreach (var item in x)
            //    {
            //        list.Add(item);
            //    };

            //    Session.Add("information", list);
            //}
            //Session.Add("information", list);
            //List<MoviePopularityViewModel> p = Session["information"] as List<MoviePopularityViewModel>;

            return View(MovieApiCalls.GetPopularMovies());
        }

        public ActionResult GenreMovieSelector(int id)
        {
            return View(MovieApiCalls.GetByGenre(id));
        }

        
    }
}