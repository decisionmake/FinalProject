using FinalProject.Models.GenreSelection;
using FinalProject.Models.MoviePopularity;
using FinalProject.Models.SummaryPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Index(string movieTitle, int id, string posterPath)
        {
            var summary = new SummaryInformation
            {
                MovieTitle = movieTitle,
                id = id,
                PosterPath = posterPath
            };

            return View(summary);
        }
    }
}