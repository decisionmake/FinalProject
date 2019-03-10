using FinalProject.Models.DAL_Objects;
using FinalProject.Models.SummaryPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.DAL.InformationTracking
{
    public class DecisionLogger
    {
        public static void EditMovieDeciosionTracker(string movieTitle, int id, string posterPath, MovieVotingHistoryDbContext db)
        {
            List<MovieHistory> movies = new List<MovieHistory>();
            movies = db.Movie.ToList();

            if (movies.Exists(d => d.MovieName == movieTitle))
            {
                MovieHistory movieToBeUpdatedInList = new MovieHistory();

                movieToBeUpdatedInList = movies.Where(d => d.MovieName == movieTitle).First(); ;
                int timesWatched = ++movieToBeUpdatedInList.NumberOfTimesChosen;

                MovieHistory movieToBeUpdatedInDatabase = db.Movie.Where(d => d.MovieName == movieTitle).First();
                movieToBeUpdatedInDatabase.NumberOfTimesChosen = timesWatched;
                db.SaveChanges();

            }
            else
            {
                MovieHistory newMovieToAdd = new MovieHistory()
                {
                    MovieName = movieTitle,
                    NumberOfTimesChosen = 1
                };

                db.Movie.Add(newMovieToAdd);
                db.SaveChanges();
            }

        }

        public static void IndicisionTracker(MovieVotingHistoryDbContext db)
        {
            var allMovies = HttpContext.Current.Request.Cookies["information"].Value;
            var storeMovie = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(allMovies);

            //var numberOfAttempts = HttpContext.Current.Request.Cookies["information"].Values.Count / 2;
            var numberOfAttempts = storeMovie.Count / 2;

            var addSession = new Indecision_Tracker()
            {
                Attempts = numberOfAttempts
            };

            db.Attempt.Add(addSession);
            db.SaveChanges();

        }

    }
}