using FinalProject.DAL;
using FinalProject.DAL.InformationTracking;
using FinalProject.Models.DAL_Objects;
using FinalProject.Models.GenreSelection;
using FinalProject.Models.MoviePopularity;
using FinalProject.Models.SummaryPage;
using FinalProject.Services;
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

        //private MovieVotingHistoryDbContext db = new MovieVotingHistoryDbContext();

        private readonly ISummaryService _service;

        public SummaryController(ISummaryService service)
        {
            _service = service;
        }

        // GET: Summary
        public ActionResult Index(SummaryInformation summary)
        {
            _service.TrackMovie(summary.MovieTitle, summary.id, summary.PosterPath, _service.db());
            _service.TrackIndecision(_service.db());

            return View(summary);
        }
    }
}