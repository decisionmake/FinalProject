using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yelp.Api.Models;

namespace FinalProject.Models.FoodModels
{
    public class FoodSummary //added model to take from view and push to summary view. 
    {
    
        public string Name { get; set; }
        public string Url { get; set; }
       
        public string Phone { get; set; }
       
        public string ImageUrl { get; set; }
      
        public string Location { get; set; }

        public string Category { get; set; }
        public string MoviePair { get; set; }

    }
}