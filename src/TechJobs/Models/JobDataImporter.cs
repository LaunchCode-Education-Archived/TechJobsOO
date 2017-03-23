using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TechJobs.Models
{
    public class JobDataImporter
    {
        private static bool IsDataLoaded = false;

        /**
         * Load and parse data from job_data.csv
         */
        internal static void LoadData()
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

            /**
             * Parse each row array into a Job object.
             * Assumes CSV column ordering: 
             *      name,employer,location,position type,core competency
             */
            foreach (string[] row in rows)
            {
                JobField employer = JobData.AddUnique(row[1], JobFieldType.Employer);
                JobField location = JobData.AddUnique(row[2], JobFieldType.Location);
                JobField positionType = JobData.AddUnique(row[3], JobFieldType.PositionType);
                JobField coreCompetency = JobData.AddUnique(row[4], JobFieldType.CoreCompetency);

                Job newJob = new Job
                {
                    Name = row[0],
                    Employer = employer,
                    Location = location,
                    PositionType = positionType,
                    CoreCompetency = coreCompetency
                };
                JobData.Add(newJob);
            }

            IsDataLoaded = true;
        }


        /**
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
