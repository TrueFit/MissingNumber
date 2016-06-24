using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindNumberClassLibrary;

namespace TrueFit
{
    class Program
    {
        static void Main(string[] args)
        {
            FindMissingNumber find = new FindMissingNumber();

            System.IO.StreamReader myFile = new System.IO.StreamReader("numbers.txt");
            string myString = myFile.ReadToEnd();
            myFile.Close();

            //splits on new line, regardless of new line style
            string[] stringArray = myString.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
            int missingNumber = 0;

            /*feeds one string array element at a time into DetermineMissingNumber so we can get the output 
             *and then move onto the next string array element*/
            for (int i = 0; i < stringArray.Length; i++)
            {
                missingNumber = find.DetermineMissingNumber(stringArray[i]);
                Console.WriteLine(missingNumber);
            }
            Console.ReadLine();
        }
    }
}

/*Next steps for broadening the program: ask customer how they'd like to handle edge cases (such as multiple missing values, 
 *a file with a comma and nothing else, etc), and implement that solution. If you'd like me to expand the program to handle 
 * those cases, let me know how you'd like them handled.*/

