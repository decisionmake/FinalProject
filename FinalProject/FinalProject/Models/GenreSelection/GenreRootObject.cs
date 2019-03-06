using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.GenreSelection
{
    public class GenreRootObject
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        //public List<Result> results { get; set; }
        public List<GenreMovieModel.Genre> genres { get; set; }
        public List<GenreMovieResult> results { get; set; }
    }

}