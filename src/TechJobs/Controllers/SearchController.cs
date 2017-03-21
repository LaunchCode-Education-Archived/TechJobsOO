using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using System;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = JobSearchType.GetAll();
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm = "")
        {
            List<Job> jobs;

            if (searchType.Equals(JobSearchType.All) || searchTerm.Equals(""))
            {
                jobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.columns = JobSearchType.GetAll();
            ViewBag.jobs = jobs;

            return View("Index");
        }
    }
}
