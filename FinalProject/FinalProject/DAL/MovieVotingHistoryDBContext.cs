using FinalProject.Models.DAL_Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public class MovieVotingHistoryDbContext : DbContext
    {
        public MovieVotingHistoryDbContext() : base("MovieDatabase")
        {
            Database.SetInitializer(new MovieVotingHistoryDbIntializer());
        }


        public DbSet<MovieHistory> Movie { get; set; }
        public DbSet<Indecision_Tracker> Attempt { get; set; }
        public DbSet<RejectedMovieList> RejectedMovies { get; set; }
        public DbSet<MovieFood> CompareMovieToFood { get; set; }

    }
}