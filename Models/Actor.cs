using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbAPI.Models
{
    public class Actor
    {
        public int actor_id { get; set; }
        public string actor_name { get; set; }
        public string bio { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }
    }
}
