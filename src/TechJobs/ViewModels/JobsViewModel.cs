using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobsViewModel : BaseViewModel
    {
        public List<Job> Jobs { get; set; }
    }
}
