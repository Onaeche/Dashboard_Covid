using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_Covid.Models
{
    public class AreaChartModel
    {
        public string period { get; set; }
        public double iphone { get; set; }
        public double ipad { get; set; }
        public double itouch { get; set; }
    }

    public class PieChartModel
    {
        public string label { get; set; }
        public double data { get; set; }
    }
    public class DuonutChartModel
    {
        public string label { get; set; }
        public double data { get; set; }
    }
    public class GraphChartModel
    {
        public DateTime? y { get; set; }
        public double a { get; set; }
        public double b { get; set; }
    }

    public class ReportModel
    {
        public string location { get; set; }
        public double total_cases { get; set; }
        public double new_cases { get; set; }
        public double total_deaths { get; set; }
        public double new_deaths { get; set; }
        public double population { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}