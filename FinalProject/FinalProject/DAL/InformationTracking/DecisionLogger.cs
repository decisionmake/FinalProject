using FinalProject.Models.DAL_Objects;
using FinalProject.Models.GenreSelection;
using FinalProject.Models.MoviePopularity;
using FinalProject.Models.SummaryPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.DAL.InformationTracking
{
    public class DecisionLogger
    {
        public void EditMovieDeciosionTracker(string movieTitle, int id, string posterPath, MovieVotingHistoryDbContext db)
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

        public void IndicisionTracker(MovieVotingHistoryDbContext db)
        {
            int numberOfAttempts = 0;

            if (HttpContext.Current.Session["Popular"] as List<MoviePopularityViewModel> != null)
            {
                var allMovies = HttpContext.Current.Session["Popular"] as List<MoviePopularityViewModel>;
                numberOfAttempts = allMovies.Count / 2;
                var addSession = new Indecision_Tracker()
                {
                    Attempts = numberOfAttempts
                };
                db.Attempt.Add(addSession);
                db.SaveChanges();
                var id = db.Attempt.Count();
                AddRejectedMovies(id, allMovies);
            }
            else if (HttpContext.Current.Session["Genre"] as List<GenreSelectorViewModel> != null)
            {
                var allMovies = HttpContext.Current.Session["Genre"] as List<GenreSelectorViewModel>;
                numberOfAttempts = allMovies.Count / 2;

            }

            var addSession = new Indecision_Tracker()
            {
                Attempts = numberOfAttempts
            };
            db.Attempt.Add(addSession);
            db.SaveChanges();
            var id = db.Attempt.Count();
            AddRejectedMoviesByGenre(id, allMovies);

        }

        public void AddRejectedMoviesByGenre (int id, List<GenreSelectorViewModel> movies)
        {
            foreach (var movie in movies)
            {
                var addMoives = new RejectedMovieList
                {
                    Indecision_TrackerID = id,
                    MoviesSkipped = movie.Tile
                };
            }

        }
    }
}