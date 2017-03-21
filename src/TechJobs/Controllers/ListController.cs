using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class ListController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = JobSearchType.GetAll();
            return View();
        }

        public IActionResult Values(string column)
        {
            if (column.Equals(JobSearchType.All))
            {
                List<Job> jobs = JobData.FindAll();
                ViewBag.title =  "All Jobs";
                ViewBag.jobs = jobs;
                return View("Jobs");
            }
            else
            {
                List<JobField> items = JobData.FindAll(column);
                ViewBag.title =  "All " + column + " Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View();
            }
        }

        public IActionResult Jobs(string column, string value)
        {
            List<Job> jobs = JobData.FindByColumnAndValue(column, value);
            ViewBag.title = "Jobs with " + column + ": " + value;
            ViewBag.jobs = jobs;

            return View();
        }
    }
}
