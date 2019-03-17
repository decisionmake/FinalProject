using FinalProject.DAL;
using FinalProject.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinalProject.Services
{
     public interface IFoodService
    {
        MovieVotingHistoryDbContext db();
        Task<FoodViewModel> Index(string zip);
        void TrackFood(FoodSummary food, MovieVotingHistoryDbContext db);
        void AddFood(MovieVotingHistoryDbContext db);
    }
}