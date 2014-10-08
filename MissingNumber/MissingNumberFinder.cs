using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumber
{
    public static class MissingNumberFinder
    {
        /// <summary>
        /// Finds a single number missing from a sequential series
        /// </summary>
        /// <param name="line">Comma-delimited set of sequential numbers with one number missing</param>
        /// <returns>The number missing from the series</returns>
        public static string FindMissingNumber(string line)
        {
            string missingNumber = String.Empty;

            line = line.Replace(" ", String.Empty);

            if (LineValid(line))
            {
                var inputValues = GetOrderedIntegersFromLine(line);

                int rangeStart = inputValues.First();
                int rangeEnd = inputValues.Last();

                var missingNumbers = GetExpectedValues(rangeStart, rangeEnd).Except(inputValues);

                if (missingNumbers.Count() == 1)
                {
                    missingNumber = missingNumbers.First().ToString();
                }
            }

            return missingNumber;
        }

        /// <summary>
        /// Makes sure a line consists of comma-delimited integers with no empty values
        /// </summary>
        /// <param name="line">Line to be validated</param>
        /// <returns>TRUE if line can be processed</returns>
        private static bool LineValid(string line)
        {
            if (String.IsNullOrEmpty(line))
            {
                return false;
            }

            var charArray = line.ToArray();
            char lastValue = ',';

            foreach (char value in charArray)
            {
                if (lastValue == ',' && value == ',')
                {
                    return false;
                }

                if (!(Char.IsDigit(value) || value == ','))
                {
                    return false;
                }

                lastValue = value;
            } 

            return true;
        }

        /// <summary>
        /// Converts a string of comma-delimited integers into an ordered collection of integers
        /// </summary>
        /// <param name="line">A string of comma-delimited integers</param>
        /// <returns>An ordered collection of integers</returns>
        private static IEnumerable<int> GetOrderedIntegersFromLine(string line)
        {
            var stringArray = line.Split(new char[] { ',' });
            return stringArray.Select(v => Int32.Parse(v)).OrderBy(v => v);
        }

        /// <summary>
        /// Builds a collection of the numbers between two given values
        /// </summary>
        /// <param name="rangeStart">Smallest number in the range</param>
        /// <param name="rangeEnd">Largest number in the range</param>
        /// <returns>Collection of numbers between two given values</returns>
        private static IEnumerable<int> GetExpectedValues(int rangeStart, int rangeEnd)
        {
            int rangeLength = rangeEnd - rangeStart;
            return Enumerable.Range(rangeStart, rangeLength);
        }
    }
}
