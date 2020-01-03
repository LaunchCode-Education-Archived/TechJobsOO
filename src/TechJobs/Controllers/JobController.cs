using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
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

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view
            Job returnJob = jobData.Find(id);

            //return View(jobData.Find(id));
            return View(returnJob);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
            if (ModelState.IsValid)
            {
                
                Job newJob = new Job()
                {
                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    Location = jobData.Locations.Find(newJobViewModel.Location),
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetency),
                    PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionType),

                };
                
                
                jobData.Jobs.Add(newJob);
                
                return Redirect(System.String.Format("/Job?id={0}", newJob.ID));
                
            }

            return View(newJobViewModel);
        }
    }
}
