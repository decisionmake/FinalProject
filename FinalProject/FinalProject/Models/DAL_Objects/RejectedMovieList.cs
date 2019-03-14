using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DAL_Objects
{
    public class RejectedMovieList
    {
        [Key]
        public int ID { get; set; }
        public int Indecision_TrackerID { get; set; }
        public string MoviesSkipped { get; set; }
    }
}