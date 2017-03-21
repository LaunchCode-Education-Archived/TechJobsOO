using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class ListController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = JobSearchType.GetAll();

            JobFieldsViewModel jobFieldsViewModel = new JobFieldsViewModel();
            jobFieldsViewModel.Title = "View Job Fields";

            return View(jobFieldsViewModel);
        }

        public IActionResult Values(string column)
        {
            if (column.Equals(JobSearchType.All))
            {
                JobsViewModel jobsViewModel = new JobsViewModel();
                jobsViewModel.Jobs = JobData.FindAll();
                jobsViewModel.Title =  "All Jobs";
                return View("Jobs", jobsViewModel);
            }
            else
            {
                JobFieldsViewModel jobFieldsViewModel = new JobFieldsViewModel();
                jobFieldsViewModel.Fields = JobData.FindAll(column);
                jobFieldsViewModel.Title =  "All " + column + " Values";
                jobFieldsViewModel.Column = column;

                return View(jobFieldsViewModel);
            }
        }

        public IActionResult Jobs(string column, string value)
        {
            JobsViewModel jobsViewModel = new JobsViewModel();
            jobsViewModel.Jobs = JobData.FindByColumnAndValue(column, value);
            jobsViewModel.Title = "Jobs with " + column + ": " + value;

            return View(jobsViewModel);
        }
    }
}
