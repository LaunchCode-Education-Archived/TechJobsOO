namespace TechJobs.Models
{
    public class JobFieldType
    {
        public const string Name = "Name";
        public const string Employer = "Employer";
        public const string Location = "Location";
        public const string CoreCompetency = "Skill";
        public const string PositionType = "Position Type";

        public static string[] GetAll()
        {
            return new string[] {
                Name,
                Employer,
                Location,
                CoreCompetency,
                PositionType
            };
        }

        public static JobField GetFieldByType(Job job, string type)
        {
            if (type.Equals(JobFieldType.Employer))
            {
                return job.Employer;
            }
            else if (type.Equals(JobFieldType.Location))
            {
                return job.Location;
            }
            else if (type.Equals(JobFieldType.CoreCompetency))
            {
                return job.CoreCompetency;
            }
            else if (type.Equals(JobFieldType.PositionType))
            {
                return job.PositionType;
            }

            return null;
        }
    }

    public class JobSearchType : JobFieldType
    {
        
        public const string All = "All";

        public static new string[] GetAll()
        {
            return new string[] {
                Name,
                Employer,
                Location,
                CoreCompetency,
                PositionType,
                All
            };
        }

    }
}
