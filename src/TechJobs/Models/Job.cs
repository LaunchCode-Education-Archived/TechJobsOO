namespace TechJobs.Models
{
    public class Job
    {
        public int JobID { get; set; }

        public string Name { get; set; }
        public JobField Employer { get; set; }
        public JobField Location { get; set; }
        public JobField CoreCompetency { get; set; }
        public JobField PositionType { get; set; }

    }
}
