namespace TechJobs.Models
{
    public class Job
    {
        public int ID { get; set; }
        private static int nextId = 1;

        public string Name { get; set; }
        public JobField Employer { get; set; }
        public JobField Location { get; set; }
        public JobField CoreCompetency { get; set; }
        public JobField PositionType { get; set; }

        public Job()
        {
            ID = nextId;
            nextId++;
        }

    }
}
