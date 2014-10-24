using System;
using System.Collections.Generic;
using System.IO;

namespace MissingNumberSecretSauce
{
    public class MissingNumberFinder
    {
        public List<string> FetchInputData(string fileSpec)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(fileSpec))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }
            return result;
        }

        public List<List<int>> ParseInputData(List<string> inputData)
        {
            var result = new List<List<int>>();
            foreach (var inputString in inputData)
            {
                if (string.IsNullOrWhiteSpace(inputString))
                {
                    result.Add(new List<int>());
                }
                else
                {
                    var intStrings = inputString.Split(',');
                    var tmp = new List<int>();
                    foreach (var intString in intStrings)
                    {
                        int value;
                        if (int.TryParse(intString, out value))
                        {
                            tmp.Add(value);
                        }
                        else
                        {
                            throw new Exception(string.Format("Invalid numeric string in input data: {0}", intString));
                        }
                    }
                    result.Add(tmp);
                }
            }
            return result;
        }

        public List<int?> CalculateMissingNumbers(List<List<int>> inputLists)
        {
            var result = new List<int?>();
            foreach (var inputList in inputLists)
            {
                result.Add(inputList.Count == 0 ? null : CalculateMissingNumber(inputList));
            }
            return result;
        }

        private static int? CalculateMissingNumber(List<int> numList)
        {
            var smallest = int.MaxValue;
            var largest = int.MinValue;
            var acc = 0;
            foreach (var num in numList)
            {
                smallest = Math.Min(smallest, num);
                largest = Math.Max(largest, num);
                acc += num;
            }
            var area = ((numList.Count + 1) * (largest + smallest)) >> 1;
            var result =  area - acc;
            return result;
        }

        public void CreateDataOutput(List<int?> results, string fileSpec, bool overWrite = true)
        {
            if (!overWrite)
            {
                if (File.Exists(fileSpec))
                {
                    throw new Exception(string.Format("File {0} exists.", fileSpec));
                }
            }
            using (var writer = File.CreateText(fileSpec))
            {
                foreach (var result in results)
                {
                    if (result.HasValue)
                    {
                        writer.WriteLine(result);
                    }
                    else
                    {
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}
