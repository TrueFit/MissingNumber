using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TrueFitMissingNumber
{
    class Series
    {
        private List<int>numbers;

        public Series(String readNumbers)
        {
            numbers = readNumbers.Split(',').Select(num => int.Parse(num)).ToList();
            numbers.Sort();
        }

        public int findMissingNumber()
        {
            int numberIndex = 0;

            return compare(numberIndex, numberIndex + 1);

        }


        private int compare(int first, int second)
        {
            if (((numbers[first]) + 1)== numbers[second])
            {
                return compare(first + 1, second + 1);
            }
            else
            {
                return ((numbers[first]) + 1);
            }
            
        }
        
    }
}
