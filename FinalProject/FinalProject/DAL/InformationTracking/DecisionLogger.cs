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
            HttpContext.Current.Session["SelectedMovie"] = movieTitle;

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
            List<string> allMovies = HttpContext.Current.Session["Info"] as List<string>;
            numberOfAttempts = allMovies.Count / 2;
            var addSession = new Indecision_Tracker()
            
            {
                Attempts = numberOfAttempts
            };

            db.Attempt.Add(addSession);
            db.SaveChanges();
            int id = db.Attempt.Count();
            HttpContext.Current.Session["SessionId"] = id.ToString();

            allMovies.Count();
            if (allMovies[allMovies.Count() -1 ] == HttpContext.Current.Session["SelectedMovie"] as string)
            {
                allMovies.Remove(allMovies[allMovies.Count() - 1]);
            }
            else if (allMovies[allMovies.Count() - 2] == HttpContext.Current.Session["SelectedMovie"] as string)
            {
                allMovies.Remove(allMovies[allMovies.Count() - 2]);
            }
                

            AddRejectedMoviesByGenre(allMovies, db);


        }

        public void AddRejectedMoviesByGenre (List<string> movies, MovieVotingHistoryDbContext db)
        {
            string movieID = HttpContext.Current.Session["SessionId"] as string;
            int.TryParse(movieID, out int id);

            foreach (var movie in movies)
            {
                var addMoive = new RejectedMovieList
                {
                    Indecision_TrackerID = id,
                    MoviesSkipped = movie
                };
                db.RejectedMovies.Add(addMoive);
                //db.SaveChanges();
            };

        }
        public void AddFood(MovieVotingHistoryDbContext db)
        {

        }
        public void AddMovieFood(MovieVotingHistoryDbContext db)
        {

            List<string> list = HttpContext.Current.Session["moviefood"] as List<string>;
            var addList = new MovieFood();
            {
                addList.MovieSelection = list.FirstOrDefault();
                addList.FoodSelection = list.LastOrDefault();
            }
            db.CompareMovieToFood.Add(addList);
            db.SaveChanges();


        }
    }
}