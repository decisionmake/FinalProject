using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.BLL
{
    public class Analytics
    {
        public decimal AverageTimesSelected(MovieVotingHistoryDbContext db)
        {
            string selectedMovie = HttpContext.Current.Session["SelectedMovie"] as string;

            int selectedAmount = db.Movie.Where(d => d.MovieName == selectedMovie).Select(d => d.NumberOfTimesChosen).SingleOrDefault();
            int sumOfAllMovieChosen = db.Movie.Sum(d => d.NumberOfTimesChosen);

            decimal average = Convert.ToDecimal(selectedAmount)  / Convert.ToDecimal(sumOfAllMovieChosen);
            average = Math.Round(average, 2);

            return average;
        }


    }
}