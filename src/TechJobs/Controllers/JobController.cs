using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {
        // The detail display for a given Job
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

                // Redirect to the detail page for the new job
                return Redirect(string.Format("/Job?id={0}", newJob.ID.ToString()));
            }

            return View(newJobViewModel);
        }
    }
}
