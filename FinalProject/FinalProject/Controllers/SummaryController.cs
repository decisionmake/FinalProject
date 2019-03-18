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
            summary.AverageSelected = _service.GetAverageTimeSelected(_service.db());
            summary.SkippedAmount = _service.GetFrequencySkipped(_service.db());
            summary.AttemptsToDecide = _service.GetVotingAverage(_service.db())[0];
            summary.AverageAttemptsToDecide = _service.GetVotingAverage(_service.db())[1];
            if (summary.AttemptsToDecide > summary.AverageAttemptsToDecide)
            {
                summary.AttemptsMessage = $"It took you {summary.AttemptsToDecide} attempts to decide, on average it takes {summary.AverageAttemptsToDecide}." +
                    $"You may be a little indecisive.";
            }
            else if (summary.AttemptsToDecide < summary.AverageAttemptsToDecide)
            {
                summary.AttemptsMessage = $"It took you {summary.AttemptsToDecide} attempts to decide, on average it takes {summary.AverageAttemptsToDecide}." +
                     $"You're better than most, great job!";
            }

            return View(summary);
        }
    }
}