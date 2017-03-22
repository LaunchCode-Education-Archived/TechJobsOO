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
            jobsViewModel.Title = "Search";
            return View(jobsViewModel);
        }

        public IActionResult Results(JobsViewModel jobsViewModel)
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
