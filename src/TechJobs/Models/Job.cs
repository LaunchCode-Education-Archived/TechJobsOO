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

        public JobField GetFieldByType(string type)
        {
            if (type.Equals(JobFieldType.Employer))
            {
                return Employer;
            }
            else if (type.Equals(JobSearchType.Location))
            {
                return Location;
            }
            else if (type.Equals(JobSearchType.CoreCompetency))
            {
                return CoreCompetency;
            }
            else if (type.Equals(JobSearchType.PositionType))
            {
                return PositionType;
            }

            return null;
        }

    }
}
