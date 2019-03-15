using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.BLL;
using FinalProject.DAL;
using FinalProject.DAL.InformationTracking;

namespace FinalProject.Services
{
    public class SummaryService : ISummaryService
    {
        public decimal GetAverageTimeSelected(MovieVotingHistoryDbContext db)
        {
            var getAverageSelected = new Analytics();
            return getAverageSelected.AverageTimesSelected(db);
        }

        public MovieVotingHistoryDbContext db()
        {
            MovieVotingHistoryDbContext db = new MovieVotingHistoryDbContext();

            return db;
        }

        public void TrackIndecision(MovieVotingHistoryDbContext db)
        {
            DecisionLogger decisionLogger = new DecisionLogger();
            decisionLogger.IndicisionTracker(db);

        }

        public void TrackMovie(string movieTitle, int id, string posterPath, MovieVotingHistoryDbContext db)
        {
            DecisionLogger decisionLogger = new DecisionLogger();
            decisionLogger.EditMovieDeciosionTracker(movieTitle, id, posterPath, db);

        }
    }
}