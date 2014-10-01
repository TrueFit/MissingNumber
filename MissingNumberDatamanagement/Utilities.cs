using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace MissingNumberDataManagement
{
    public class Utilities
    {
        /// <summary>
        /// MissingNumber expects a path to a text file
        /// containing a list of comma separated integers.
        /// Note: blank rows are caught as invalid argument exceptions.
        /// An empty file is acceptable but will return no results.
        /// </summary>
        /// <param name="PathAndFileName"></param>
        /// <returns></returns>
        public List<Int64> MissingNumber(string PathAndFileName)
        {
            string currentLine;
            int currentRow = 0;
            List<Int64> returnValues = new List<Int64>();
            List<Int64> currentLineValues;
            List<Int64> currentLineValuesSorted;
            

            using (StreamReader missingNumberFile = new StreamReader(PathAndFileName, Encoding.ASCII))
            {
                while ((currentLine = (missingNumberFile.ReadLine())) != null)
                {
                    currentLineValues = new List<Int64>();
                    currentRow += 1;
                    string[] numbers = currentLine.Split(',');

                    Int64 numbersCount = numbers.Count(); 

                    // check that the individual numbers are integers
                    bool allDataAreIntegers = true;
                    Int64 position = 0;

                    for (int i = 0; i < numbersCount; i++)
                    {
                        position = i;
                        if (!IsInteger(numbers[i]))
                        {
                            allDataAreIntegers = false;
                            break;
                        }
                        else
                        {
                            currentLineValues.Add(int.Parse(numbers[position]));
                        }
                    }

                    if (allDataAreIntegers == false)
                    {
                        long itemPosition = position + 1;
                        throw new ArgumentException(
                            "Invalid argument at row " + currentRow + ", item " +
                            itemPosition.ToString() + 
                            ". Value:" + numbers[position]);
                    }

                    //
                    // find the missing number in the list of big integers
                    //

                    // sort the list
                    currentLineValuesSorted = new List<Int64>();
                    currentLineValuesSorted = currentLineValues.OrderBy(num => num).ToList();

                    Int64 missingNumberCount = 0;
                    Int64 sortedValuesCounter = 0;
                    Int64 previousValue=0;
                    Int64 missingNumber = 0;
                    foreach (var currentSortedValue in currentLineValuesSorted)
                    {
                        sortedValuesCounter = sortedValuesCounter + 1;

                        if (sortedValuesCounter != 1 && previousValue != currentSortedValue - 1)
                        {
                            missingNumber = previousValue + 1;
                            missingNumberCount = missingNumberCount + 1;

                            // make sure we only have one missing value to add to our list, otherwise let the caller know of the problem
                            if (missingNumberCount == 0)
                            {
                                throw new ArgumentException("No missing number found in row:" + currentRow.ToString());
                            }
                            if (missingNumberCount == 1)
                            {
                                returnValues.Add(missingNumber);
                            }
                            else if (missingNumberCount > 1)
                            {
                                throw new ArgumentException("Multiple missing numbers found in row:" + currentRow.ToString());
                            }
                        }

                        previousValue = currentSortedValue;
                    }

                }

            }


            return returnValues;
        }
        
        public bool IsInteger(string value)
        {
            Int64 tempOutput;
            var is_number = Int64.TryParse(value, out tempOutput);
            return is_number;
        }

    }
}
