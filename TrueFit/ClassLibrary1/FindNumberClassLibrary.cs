using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumberClassLibrary
{
    public class FindMissingNumber
    {
        public int DetermineMissingNumber(string singleString)
        {
            string[] stringNumbersArray = singleString.Split(new string[] { "," }, StringSplitOptions.None);
            int[] numbersArray = new int[stringNumbersArray.Length];
            bool[] boolArray = new bool[numbersArray.Length + 1];
            int missingNumber = 0;

            //converts string array to integer array
            for (int i = 0; i < stringNumbersArray.Length; i++)
            {
                Int32.TryParse(stringNumbersArray[i], out numbersArray[i]);
            }

            int low = numbersArray[0];

            //determines the lowest number in the array
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] < low)
                {
                    low = numbersArray[i];
                }
            }

            /*sets the spot on the boolArray equal to true corresponding to where the current 
             *numbersArray element would be located in an array if said array were in ascending numerical order*/
            for (int i = 0; i < numbersArray.Length; i++)
            {
                int diff = numbersArray[i] - low;
                boolArray[diff] = true;
            }

            /*this looks on the boolArray for the remaining false element, and then determines what the value of that missing
             *element would be by adding the index of that element to the lowest number in the array*/
            for (int i = 0; i < boolArray.Length; i++)
            {
                if (!boolArray[i])
                {
                    missingNumber = low + i;
                }
            }

            return missingNumber;
        }
    }
}
