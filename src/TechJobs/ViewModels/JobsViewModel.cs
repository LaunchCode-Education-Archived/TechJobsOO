using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobsViewModel
    {
        public List<Job> Jobs { get; set; }
        public string[] Columns { get; set; } = JobSearchType.GetAll();
        public string Title { get; set; } = "Jobs";
    }
}
