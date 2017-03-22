using System;
using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class BaseViewModel
    {
		public List<JobFieldTypeDisplay> Columns { get; set; } 
        public string Title { get; set; } = "";

        public BaseViewModel()
        {
            Columns = new List<JobFieldTypeDisplay>();

            foreach (var enumVal in Enum.GetValues(typeof(JobFieldType)))
            {
                Columns.Add(new JobFieldTypeDisplay {
                    Type = (JobFieldType) enumVal
                });
            }

            
        }
    }
}
