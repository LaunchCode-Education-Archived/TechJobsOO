using System.ComponentModel.DataAnnotations;

namespace TechJobs.Models
{
    public enum JobFieldType
    {
        // Enum representing the JobField properties of a Job
        // that can be viewed and searched. 
        //
        // The DisplayName attributes are for provided for 
        // potential use in a view.

        Employer,
        Location,

        [Display(Name = "Skill")]
        CoreCompetency,

        [Display(Name = "Position Type")]
        PositionType,

        All
    }
}
