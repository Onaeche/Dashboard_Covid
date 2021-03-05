using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_Covid.Models
{
    public class geoLocation
    {
        public string continents { get; set; }
        public double total_cases { get; set; }
        public double total_deaths { get; set; }
    }
}