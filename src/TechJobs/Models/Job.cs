namespace TechJobs.Models
{
    public class Job
    {

        private int id;
        public int ID {
            get { return id; }
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

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return (obj as Job).ID == ID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ID;
        }

    }
}
