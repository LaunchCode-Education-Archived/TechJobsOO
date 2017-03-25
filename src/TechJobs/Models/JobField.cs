namespace TechJobs.Models
{
    public class JobField
    {
        private int id;
        public int ID {
            get { return id; }
            private set { id = value; }
        }
        private static int nextId = 1;

        public string Value { get; set; }

        public JobField()
        {
            ID = nextId;
            nextId++;
        }

        // Provide a basic case-insensitive search
        public bool Contains(string testValue)
        {
            return Value.ToLower().Contains(testValue.ToLower());
        }

        public override string ToString()
        {
            return Value;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            return (obj as JobField).ID == ID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ID;
        }

    }
}
