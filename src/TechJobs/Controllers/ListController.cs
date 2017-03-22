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
            JobFieldsViewModel jobFieldsViewModel = new JobFieldsViewModel();
            jobFieldsViewModel.Title = "View Job Fields";

            return View(jobFieldsViewModel);
        }

        public IActionResult Values(JobFieldType column)
        {
            if (column.Equals(JobFieldType.All))
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
                JobFieldTypeDisplay columnDisplay = new JobFieldTypeDisplay { Type = column };
                jobFieldsViewModel.Title =  "All " + columnDisplay.ToString() + " Values";
                jobFieldsViewModel.Column = column;

                return View(jobFieldsViewModel);
            }
        }

        public IActionResult Jobs(JobFieldType column, string value)
        {
            JobsViewModel jobsViewModel = new JobsViewModel();
            jobsViewModel.Jobs = JobData.FindByColumnAndValue(column, value);
            JobFieldTypeDisplay columnDisplay = new JobFieldTypeDisplay { Type = column };
            jobsViewModel.Title = "Jobs with " + columnDisplay.ToString() + ": " + value;

            return View(jobsViewModel);
        }
    }
}
