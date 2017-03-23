using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TechJobs.Models
{
    class JobData
    {
        /**
         * A data store for Job objects
         */

        private static List<Job> jobs = new List<Job>();

        private static Dictionary<JobFieldType, List<JobField>> fieldData
            = new Dictionary<JobFieldType, List<JobField>>();

        private static List<JobField> allFields = new List<JobField>();

        // A static constructor to initialize our data structures
        static JobData()
        {
            fieldData.Add(JobFieldType.Employer, new List<JobField>());
            fieldData.Add(JobFieldType.Location, new List<JobField>());
            fieldData.Add(JobFieldType.CoreCompetency, new List<JobField>());
            fieldData.Add(JobFieldType.PositionType, new List<JobField>());

            JobDataImporter.LoadData();
        }


        /**
         * Returns all jobs in the data store
         */
        public static List<Job> FindAll()
        {
            return jobs;
        }


        /**
         * Returns a list of all JobFields in the data store of a given type
         */
        public static List<JobField> FindAll(JobFieldType column)
        {
            return fieldData[column];
        }


        /**
         * Return all Job objects in the data store
         * with a field containing the given term
         */
        public static List<Job> FindByValue(string value)
        {
            var results = from j in jobs
                          where j.Employer.Contains(value)
                          || j.Location.Contains(value)
                          || j.Name.ToLower().Contains(value.ToLower())
                          || j.CoreCompetency.Contains(value)
                          || j.PositionType.Contains(value)
                          select j;

            return results.ToList();
        }


        /**
         * Returns results of search the jobs data by key/value, using
         * inclusion of the search term.
         */
        public static List<Job> FindByColumnAndValue(JobFieldType column, string value)
        {
            var results = from j in jobs
                          where GetFieldByType(j, column).Contains(value)
                          select j;

            return results.ToList();
        }
        

        /**
         * Adds a JobField with provided value and type, 
         * checking for duplicates first
         */
        internal static JobField AddUnique(string fieldValue, JobFieldType field)
        {
            List<JobField> fieldList = fieldData[field];

            var results = from aField in fieldList
                          where aField.Value.Equals(fieldValue)
                          select aField;

            JobField theField;

            if (!results.Any())
            {
                theField = new JobField
                {
                    Value = fieldValue
                };

                fieldList.Add(theField);
                allFields.Add(theField);
            }
            else
            {
                theField = results.Single();
            }

            return theField;

        }


        /**
         * Returns the JobField of the given type from the Job object,
         * for all types other than JobFieldType.All. In this case, 
         * null is returned.
         */
        public static JobField GetFieldByType(Job job, JobFieldType type)
        {
            switch (type)
            {
                case JobFieldType.Employer:
                    return job.Employer;
                case JobFieldType.Location:
                    return job.Location;
                case JobFieldType.CoreCompetency:
                    return job.CoreCompetency;
                case JobFieldType.PositionType:
                    return job.PositionType;
            }

            return null;
        }


        /**
         * Returns the JobField with the given ID,
         * if it exists in the store.
         */
        public static JobField GetFieldById(int id)
        {
            var results = from field in allFields
                          where field.ID == id
                          select field;

            return results.Single();
        }


        /**
         * Returns the Job with the given ID,
         * if it exists in the store
         */
        public static Job GetJobById(int id)
        {
            var results = from j in jobs
                          where j.ID == id
                          select j;

            return results.Single();
        }

        /**
         * Adds the Job to the data store
         */
        public static void Add(Job newJob)
        {
            jobs.Add(newJob);
        }

    }
}
