using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobFieldsViewModel : BaseViewModel
    {
        public List<JobField> Fields { get; set; }
        public JobFieldType Column { get; set; }
    }
}
