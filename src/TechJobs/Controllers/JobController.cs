using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using TechJobs.Data;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {
        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job
        public IActionResult Index(int id)
        {
            Job theJob = jobData.Find(id);

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
                    Location = jobData.Locations.Find(newJobViewModel.LocationID),
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID),
                    PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID)
                };

                jobData.Jobs.Add(newJob);

                // Redirect to the detail page for the new job
                return Redirect(string.Format("/Job?id={0}", newJob.ID.ToString()));
            }

            return View(newJobViewModel);
        }
    }
}
