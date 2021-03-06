﻿using FinalProject.DAL;
using FinalProject.DAL.InformationTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Services
{
    public interface ISummaryService
    {
        MovieVotingHistoryDbContext db();
        void TrackMovie (string movieTitle, int id, string posterPath, MovieVotingHistoryDbContext db);
        void TrackIndecision (MovieVotingHistoryDbContext db);
        decimal GetAverageTimeSelected(MovieVotingHistoryDbContext db);
        int GetFrequencySkipped(MovieVotingHistoryDbContext db);
        decimal[] GetVotingAverage (MovieVotingHistoryDbContext db);
        //void TrackFood(MovieVotingHistoryDbContext db);

    }
}