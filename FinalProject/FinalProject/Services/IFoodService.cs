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
        Task<FoodViewModel> Index(string zip);

    }
}