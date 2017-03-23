using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        // Display the search form
        public IActionResult Index()
        {
            SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();
            jobsViewModel.Title = "Search";
            return View(jobsViewModel);
        }

        // Process search submission and display search results
        public IActionResult Results(SearchJobsViewModel jobsViewModel)
        {

            if (jobsViewModel.Column.Equals(JobFieldType.All) || jobsViewModel.Value.Equals(""))
            {
                jobsViewModel.Jobs = JobData.FindByValue(jobsViewModel.Value);
            }
            else
            {
                jobsViewModel.Jobs = JobData.FindByColumnAndValue(jobsViewModel.Column, jobsViewModel.Value);
            }
            
            jobsViewModel.Title = "Search";

            return View("Index", jobsViewModel);
        }
    }
}
