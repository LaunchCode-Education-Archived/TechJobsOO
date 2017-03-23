using System;
using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobFieldsViewModel
    {
        // TODO #7.2 - Extract members common to JobFieldsViewModel
        // to BaseViewModel

        // The current column
        public JobFieldType Column { get; set; }

        // All fields in the given column
        public List<JobField> Fields { get; set; }
        
        // All columns, for display
        public List<JobFieldTypeDisplay> Columns { get; set; }

        // View title
        public string Title { get; set; } = "";

        public JobFieldsViewModel()
        {
            // Populate the list of all columns

            Columns = new List<JobFieldTypeDisplay>();

            foreach (var enumVal in Enum.GetValues(typeof(JobFieldType)))
            {
                Columns.Add(new JobFieldTypeDisplay
                {
                    Type = (JobFieldType)enumVal
                });
            }


        }
    }
}
