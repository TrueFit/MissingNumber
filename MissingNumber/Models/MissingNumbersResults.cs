using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MissingNumber.Models
{
    public class MissingNumbersResults
    {        
        public List<string> Input { get; set; }
        public List<string> Output { get; set; }

        
        public MissingNumbersResults()
        {
            Input = new List<string>();
            Output = new List<string>();
        }

        public MissingNumbersResults getMissingNumbersFromFile(HttpPostedFileBase file)
        {
            var results = new MissingNumbersResults();
            var flatFileReader = new StreamReader(file.InputStream);
            while (!flatFileReader.EndOfStream)
            {
                string line = "";
                try
                {
                    line = flatFileReader.ReadLine();
                }
                catch (Exception e)
                {
                    //Possibly log it in the future. For now, I don't care about this exception.
                }
                line = line.TrimStart(',').TrimEnd(',');

                var numbers = new List<int>();
                var missingNumbers = new List<int>();

                if (line != null && line.Length > 0)
                {
                    try
                    {
                        numbers = line.Split(',').Select(int.Parse).ToList();
                    }
                    catch (Exception e)
                    {
                        //Possibly log it in the future. For now, I don't care about this exception.
                    }

                    if (numbers.Count > 0)
                    {
                        //idea here is to create a range from the minimum number of the list up until the maximum, then compare with the list we were given and get the number missing
                        //I'm sure there are slightly more efficient algorithms, but even with 1,000,000 records it doesn't even take a second, so I consider readability more important.
                        int differenceBetweenMinAndMax = numbers.Max() - numbers.Min();
                        var range = Enumerable.Range(numbers.Min(), differenceBetweenMinAndMax);
                        missingNumbers = range.Except(numbers).ToList();

                        results.Input.Add(string.Join(",", numbers.Select(n => n.ToString()).ToArray())); //converts list of ints to a comma separated string
                        results.Output.Add(string.Join(",", missingNumbers.Select(n => n.ToString()).ToArray())); //converts list of ints to a comma separated string
                    }
                }
            }
            return results;
        }
    }
}