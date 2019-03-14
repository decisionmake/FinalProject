using FinalProject.Models.GenreSelection;
using FinalProject.Models.MoviePopularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.BLL
{
    public class SessionStorage
    {
        public static void StorePopular(MoviePopularityViewModel movies)
        {

            List<MoviePopularityViewModel> list = new List<MoviePopularityViewModel>();
            List<MoviePopularityViewModel> x = HttpContext.Current.Session["Popular"] as List<MoviePopularityViewModel>;
            if (x == null)
            {
                list.Add(movies);
                HttpContext.Current.Session.Add("Popular", list);
            }
            else
            {
                foreach (var item in x)
                {
                    list.Add(item);
                };
                list.Add(movies);
                HttpContext.Current.Session.Add("Popular", list);
            }
            HttpContext.Current.Session.Add("Popular", list);
            List<MoviePopularityViewModel> p = HttpContext.Current.Session["Popular"] as List<MoviePopularityViewModel>;
        }

        public static void StoreGenre (GenreSelectorViewModel movies)
        {
            List<GenreSelectorViewModel> list = new List<GenreSelectorViewModel>();
            List<GenreSelectorViewModel> x = HttpContext.Current.Session["Genre"] as List<GenreSelectorViewModel>;
            if (x == null)
            {
                list.Add(movies);
                HttpContext.Current.Session.Add("Genre", list);
            }
            else
            {
                foreach (var item in x)
                {
                    list.Add(item);
                };
                list.Add(movies);
                HttpContext.Current.Session.Add("Genre", list);
            }
            HttpContext.Current.Session.Add("Genre", list);
            List<GenreSelectorViewModel> p = HttpContext.Current.Session["Genre"] as List<GenreSelectorViewModel>;

        }

    }
}