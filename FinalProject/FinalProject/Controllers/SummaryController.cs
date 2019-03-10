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

            
            //List<MovieHistory> movies = new List<MovieHistory>();
            //movies = db.Movie.ToList();

            //MovieHistory newMovie = new MovieHistory()
            //{
            //    MovieName = "Test",
            //    NumberOfTimesChosen = 3
            //};


            //if (movies.Exists(d => d.MovieName == newMovie.MovieName))
            //{
            //    MovieHistory newMovie2 = new MovieHistory();

            //    newMovie2 = movies.First(d => d.MovieName == movieTitle);
            //    int timesWatched = newMovie2.NumberOfTimesChosen++;

            //    db.Movie.Where(d => d.MovieName == movieTitle).ToList().ForEach(d => d.NumberOfTimesChosen = timesWatched);
            //    db.SaveChanges();

            //}
            //else 
            //{
            //    MovieHistory newMovieToAdd = new MovieHistory()
            //    {
            //        MovieName = movieTitle,
            //        NumberOfTimesChosen = 1
            //    };

            //    db.Movie.Add(newMovieToAdd);
            //    db.SaveChanges();
            //}



            //var summary = new SummaryInformation
            //{
            //    MovieTitle = movieTitle,
            //    id = id,
            //    PosterPath = posterPath
            //};

            return View(summary);
        }
    }
}