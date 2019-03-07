using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DAL_Objects
{
    public class MovieHistory
    {
        [Key]
        public int ID { get; set; }
        public string MovieName { get; set; }
        public int NumberOfTimesChosen { get; set; }

    }
}