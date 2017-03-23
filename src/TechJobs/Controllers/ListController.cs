using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class ListController : Controller
    {
        // Lists options for browsing, by "column"
        public IActionResult Index()
        {
            JobFieldsViewModel jobFieldsViewModel = new JobFieldsViewModel();
            jobFieldsViewModel.Title = "View Job Fields";

            return View(jobFieldsViewModel);
        }

        // Lists the values of a given column, or all jobs if selected
        public IActionResult Values(JobFieldType column)
        {
            if (column.Equals(JobFieldType.All))
            {
                SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();
                jobsViewModel.Jobs = JobData.FindAll();
                jobsViewModel.Title =  "All Jobs";
                return View("Jobs", jobsViewModel);
            }
            else
            {
                JobFieldsViewModel jobFieldsViewModel = new JobFieldsViewModel();
                jobFieldsViewModel.Fields = JobData.FindAll(column);
                JobFieldTypeDisplay columnDisplay = new JobFieldTypeDisplay { Type = column };
                jobFieldsViewModel.Title =  "All " + columnDisplay + " Values";
                jobFieldsViewModel.Column = column;

                return View(jobFieldsViewModel);
            }
        }

        // Lists Jobs with a given field matching a given value
        public IActionResult Jobs(JobFieldType column, string value)
        {
            SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();
            jobsViewModel.Jobs = JobData.FindByColumnAndValue(column, value);
            JobFieldTypeDisplay columnDisplay = new JobFieldTypeDisplay { Type = column };
            jobsViewModel.Title = "Jobs with " + columnDisplay + ": " + value;

            return View(jobsViewModel);
        }
    }
}
