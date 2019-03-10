using FinalProject.DAL;
using FinalProject.DAL.InformationTracking;
using FinalProject.Models.DAL_Objects;
using FinalProject.Models.GenreSelection;
using FinalProject.Models.MoviePopularity;
using FinalProject.Models.SummaryPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FinalProject.Controllers
{
    public class SummaryController : Controller
    {
        
        private MovieVotingHistoryDbContext db = new MovieVotingHistoryDbContext();

        // GET: Summary
        public ActionResult Index(SummaryInformation summary)
        {
            
            DecisionLogger.EditMovieDeciosionTracker(summary.MovieTitle, summary.id, summary.PosterPath, db);
            DecisionLogger.IndicisionTracker(db);


            return View(summary);
        }
    }
}