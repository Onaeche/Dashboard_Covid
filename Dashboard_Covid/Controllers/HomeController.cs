using Dapper;
using Dashboard_Covid.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard_Covid.Controllers
{
    public class HomeController : Controller
    {

        public JsonResult getoo(string fromDate, string toDate)
        {
            List<DatasetModel> classobject = new List<DatasetModel>();
            List<DatasetModel> classobject1 = new List<DatasetModel>();
            List<DatasetModel> classobject2 = new List<DatasetModel>();
            List<DatasetModel> classobject3 = new List<DatasetModel>();
            List<BarChartModel> barChartObj = new List<BarChartModel>();
            List<geoLocation> geoChartObj = new List<geoLocation>();
            List<AreaChartModel> areachartObj = new List<AreaChartModel>();
            List<PieChartModel> piechartObj = new List<PieChartModel>();
            List<GraphChartModel> chartObj3 = new List<GraphChartModel>();
            //class object
            using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CovidConnectionstring"].ToString()))
            {
                if (fromDate == null && toDate == null)
                {
                    fromDate = "2020-01-01";
                    toDate = "2021-03-03";
                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@DateFrom", fromDate);
                param.Add("@DateTo", toDate);
                var result = db.Query<DatasetModel>(sql: "pdCovid",
                   param: param, commandType: CommandType.StoredProcedure);
                classobject = result.ToList();




                classobject1 = db.Query<DatasetModel>(@"select isnull(sum(new_deaths),0) new_deaths, sum(new_cases) new_cases, continent
from CovidData_
where continent is not null
group by continent").ToList();


                classobject2 = db.Query<DatasetModel>(@"select isnull(sum(new_deaths),0) new_deaths, sum(new_cases) new_cases, continent,sum(total_cases) as total_cases
from CovidData_
where continent is not null
group by continent").ToList();

                classobject3 = db.Query<DatasetModel>(@"select sum(new_deaths) as new_deaths ,sum(new_cases) as new_cases, date from CovidData_ 
where continent is null
group by date").ToList();


                //foreac
                foreach (var item in classobject)
                {
                    barChartObj.Add(new BarChartModel()
                    {
                        y = item.continent,
                        a = item.new_deaths,
                        b = item.new_cases
                    });
                }
                foreach (var item in classobject1)
                {
                    geoChartObj.Add(new geoLocation()
                    {
                        continents = item.continent,
                        total_cases = item.new_deaths,
                        total_deaths = item.new_cases
                    });
                }
                foreach (var item in classobject2)
                {
                    areachartObj.Add(new AreaChartModel()
                    {
                        period = item.continent,
                        ipad = item.total_cases,
                        iphone = item.new_cases,
                        itouch = item.new_deaths
                    });
                }
                foreach (var item in classobject)
                {
                    piechartObj.Add(new PieChartModel()
                    {
                        label = item.continent,
                        data = item.total_cases,
                    });
                }

                foreach (var item in classobject3)
                {
                    chartObj3.Add(new GraphChartModel()
                    {
                        y = item.date,
                        a = item.new_cases,
                        b = item.new_deaths,
                    });
                }
            }

            return Json(new { data = classobject, barchart = barChartObj, geochart = geoChartObj, lineChart = chartObj3, piechart = piechartObj }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Report()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Report(string fromDate, string toDate)
        {
            List<DatasetModel> classobject = new List<DatasetModel>();
            List<ReportModel> barChartObj = new List<ReportModel>();
            using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CovidConnectionstring"].ToString()))
            {
                if ((fromDate == null && toDate == null)|| fromDate == "" && toDate == "")
                {
                    // return Content("<script language='javascript' type='text/javascript'>alert('Please select a date');</script>");
                    TempData["testmsg"] = "<script>alert('Please Select Date Range');</script>";
                    return PartialView();
                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@DateFrom", fromDate);
                param.Add("@DateTo", toDate);
                var result = db.Query<DatasetModel>(sql: "pdCovidReport",
                   param: param, commandType: CommandType.StoredProcedure);
                classobject = result.ToList();

                if (classobject.Count != 0)
                {
                    //foreac
                    foreach (var item in classobject)
                    {
                        barChartObj.Add(new ReportModel()
                        {
                            location = item.location,
                            total_cases = item.total_cases,
                            total_deaths = item.total_deaths,
                            new_deaths = item.new_deaths,
                            new_cases = item.new_cases,
                            population = item.population
                        });
                    }
                    ReportModel reportmodel = new ReportModel();
                    ReportViewer reportView = new ReportViewer();
                    reportView.LocalReport.ReportPath += @"Reports/CovidReport.rdlc";
                    ReportDataSource rdc = new ReportDataSource("DataSet1", barChartObj);
                    reportView.LocalReport.DataSources.Clear();
                    reportView.LocalReport.DataSources.Add(rdc);
                    reportView.LocalReport.Refresh();
                    reportView.SizeToReportContent = true;
                    reportView.AsyncRendering = false;
                    reportView.ZoomMode = ZoomMode.FullPage;
                    ViewBag.TB = reportView;

                    
                }

                else
                {
                    // return Content("<script language='javascript' type='text/javascript'>alert('Please select a date');</script>");
                    TempData["testmsg"] = "<script>alert('There is no Report to be generated');</script>";
                    return View();
                }
                //reportmodel.= reportView;

            }


            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}