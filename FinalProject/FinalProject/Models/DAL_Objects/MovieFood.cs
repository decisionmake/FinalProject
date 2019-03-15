using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DAL_Objects
{
    public class MovieFood
    {
        [Key]
        public int ID { get; set; }
        public string MovieSelection { get; set; }
        public string FoodSelection { get; set; }

    }
}