using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DAL_Objects
{
    public class Indecision_Tracker
    {
        [Key]
        public int ID { get; set; }
        public int Attempts { get; set; }

    }
}