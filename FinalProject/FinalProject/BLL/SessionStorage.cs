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


            List<string> list = new List<string>();
            List<string> x = HttpContext.Current.Session["Info"] as List<string>;
            if (x == null)
            {
                list.Add(movies.MovieOne.title);
                list.Add(movies.MovieTwo.title);
                HttpContext.Current.Session.Add("Info", list);
            }
            else
            {
                foreach (var item in x)
                {
                    list.Add(item);
                };
                list.Add(movies.MovieOne.title);
                list.Add(movies.MovieTwo.title);

                HttpContext.Current.Session.Add("Info", list);
            }
            HttpContext.Current.Session.Add("Info", list);
            List<string> p = HttpContext.Current.Session["Info"] as List<string>;
        }

        public static void StoreGenre(GenreSelectorViewModel movies)
        {
            List<string> list = new List<string>();
            List<string> x = HttpContext.Current.Session["Info"] as List<string>;
            if (x == null)
            {
                list.Add(movies.GenreMovieOne.title);
                list.Add(movies.GenreMovieTwo.title);

                HttpContext.Current.Session.Add("Info", list);
            }
            else
            {
                foreach (var item in x)
                {
                    list.Add(item);
                };
                list.Add(movies.GenreMovieOne.title);
                list.Add(movies.GenreMovieTwo.title);

                HttpContext.Current.Session.Add("Info", list);
            }
            HttpContext.Current.Session.Add("Info", list);
            List<string> p = HttpContext.Current.Session["Info"] as List<string>;

        }

    }


}
    