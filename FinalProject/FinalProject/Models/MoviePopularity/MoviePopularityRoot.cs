using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.MoviePopularity
{
    public class MoviePopularityRoot
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<MoviePopularityResults> results { get; set; }
    }
}