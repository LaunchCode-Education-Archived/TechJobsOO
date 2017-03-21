using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TechJobs.Models
{
    class JobData
    {
        private static List<Job> jobs = new List<Job>();

        private static Dictionary<string, List<JobField>> fieldData
            = new Dictionary<string, List<JobField>>();

        static JobData()
        {
            fieldData.Add(JobFieldType.Employer, new List<JobField>());
            fieldData.Add(JobFieldType.Location, new List<JobField>());
            fieldData.Add(JobFieldType.CoreCompetency, new List<JobField>());
            fieldData.Add(JobFieldType.PositionType, new List<JobField>());
        }

        private static bool IsDataLoaded = false;

        public static List<Job> FindAll()
        {
            LoadData();
            return jobs;
        }

        /*
         * Returns a list of all values contained in a given column,
         * without duplicates. 
         */
        public static List<JobField> FindAll(string column)
        {
            LoadData();
            return fieldData[column];
        }

        /**
         * Search all columns for the given term
         */
        public static List<Job> FindByValue(string value)
        {
            // load data, if not already loaded
            LoadData();

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
         *
         * For example, searching for employer "Enterprise" will include results
         * with "Enterprise Holdings, Inc".
         */
        public static List<Job> FindByColumnAndValue(string column, string value)
        {
            // load data, if not already loaded
            LoadData();

            var results = from j in jobs
                          where JobFieldType.GetFieldByType(j, column).Contains(value)
                          select j;

            return results.ToList();
        }

        /*
         * Load and parse data from job_data.csv
         */
        private static void LoadData()
        {

            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = File.OpenText("Models/job_data.csv"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] rowArrray = CSVRowToStringArray(line);
                    if (rowArrray.Length > 0)
                    {
                        rows.Add(rowArrray);
                    }
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            // Parse each row array into a Job object
            // Assumes CSV column ordering: 
            //      name,employer,location,position type,core competency
            foreach (string[] row in rows)
            {
                JobField employer = AddUnique(row[1], fieldData[JobFieldType.Employer]);
                JobField location = AddUnique(row[2], fieldData[JobFieldType.Location]);
                JobField positionType = AddUnique(row[3], fieldData[JobFieldType.PositionType]);
                JobField coreCompetency = AddUnique(row[4], fieldData[JobFieldType.CoreCompetency]);

                Job newJob = new Job {
                    Name = row[0],
                    Employer = employer,
                    Location = location,
                    PositionType = positionType,
                    CoreCompetency = coreCompetency
                };
                jobs.Add(newJob);
            }

            IsDataLoaded = true;
        }

        private static JobField AddUnique(string fieldValue, List<JobField> fieldList)
        {
            var results = from field in fieldList
                          where field.Value.Equals(fieldValue)
                          select field;

            JobField theField;

            if (!results.Any())
            {
                theField = new JobField
                {
                    Value = fieldValue
                };

                fieldList.Add(theField);
            }
            else
            {
                theField = results.Single();
            }

            return theField;

        }

        /*
         * Parse a single line of a CSV file into a string array
         */
        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }
    }
}
