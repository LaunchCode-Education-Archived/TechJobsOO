using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index(int id)
        {
            Job theJob = JobData.GetJobById(id);

            return View(theJob);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if (ModelState.IsValid)
            {
                // create new job object
                Job newJob = new Job {
                    Name = newJobViewModel.Name,
                    Location = JobData.GetFieldById(newJobViewModel.LocationID),
                    Employer = JobData.GetFieldById(newJobViewModel.EmployerID),
                    CoreCompetency = JobData.GetFieldById(newJobViewModel.CoreCompetencyID),
                    PositionType = JobData.GetFieldById(newJobViewModel.PositionTypeID)
                };

                JobData.Add(newJob);

                return Redirect(String.Format("{0}", newJob.ID));
            }

            return View(newJobViewModel);
        }
    }
}
