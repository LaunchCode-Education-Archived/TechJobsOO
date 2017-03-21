using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            JobsViewModel jobsViewModel = new JobsViewModel();
            jobsViewModel.Columns = JobSearchType.GetAll();
            jobsViewModel.Title = "Search";
            return View(jobsViewModel);
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

            JobsViewModel jobsViewModel = new JobsViewModel();
            jobsViewModel.Columns = JobSearchType.GetAll();
            jobsViewModel.Jobs = jobs;
            jobsViewModel.Title = "Search";

            return View("Index", jobsViewModel);
        }
    }
}
