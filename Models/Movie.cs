using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbAPI.Models
{
    public class Movie
    {
        public int movie_id { get; set; }
        public string movie_name { get; set; }
        public string plot { get; set; }
        public string producer_name { get; set; }
        public string actor1_name { get; set; }
        public string actor2_name { get; set; }
        public string actor3_name { get; set; }
        public string actor4_name { get; set; }
        public DateTime dor { get; set; }
        public string poster { get; set; }
    }
}
