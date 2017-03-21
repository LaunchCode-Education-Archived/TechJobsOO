using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobFieldsViewModel
    {
        public List<JobField> Fields { get; set; }
        public string Column { get; set; }
        public string[] Columns { get; set; } = JobSearchType.GetAll();
        public string Title { get; set; } = "Job Fields";
    }
}
