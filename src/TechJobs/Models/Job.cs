namespace TechJobs.Models
{
    public class Job
    {

        private int id;
        public int ID {
            get { return ID; }
            private set { id = value; }
        }

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
