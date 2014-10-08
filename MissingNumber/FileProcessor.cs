using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MissingNumber
{
    public class FileProcessor
    {
        private readonly string _inputFile;
        private readonly string _outputFile;

        public delegate string ProcessLine(string line);

        public FileProcessor(string inputFile, string outputFile)
        {
            _inputFile = inputFile;
            _outputFile = outputFile;
        }

        /// <summary>
        /// Goes through the input file line-by-line and puts the results of the given function to the output file.
        /// </summary>
        /// <param name="processLine">A function that runs on a string and returns its results as a string</param>
        public void ProcessFile(ProcessLine processLine)
        {
            using (StreamWriter writer = new StreamWriter(_outputFile))
            {
                foreach (string line in File.ReadLines(_inputFile))
                {
                    string missingNumber = processLine(line);

                    if (!String.IsNullOrEmpty(missingNumber))
                    {
                        writer.WriteLine(missingNumber);
                    }
                }
            }
        }
    }
}
