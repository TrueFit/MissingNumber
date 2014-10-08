using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (ArgumentsValid(args))
                {
                    PrintMissingNumbers(args[0], args[1]);
                }
                else
                {
                    Console.WriteLine("Make sure your arguments include an input file and an output file.");
                    Console.WriteLine("==================================================================");
                    Console.WriteLine("Example: C:\\>missingnumber C:\\input.txt C:\\output.txt");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Push any key to continue");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Makes sure that the correct number of arguments exist and they are not equal.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>TRUE if there are two arguments</returns>
        private static bool ArgumentsValid(string[] args)
        {
            if (args.Length != 2 || args[0] == args[1])
                return false;

            return true;
        }

        /// <summary>
        /// Writes the "missing number" from each line of the input file to the output file.
        /// </summary>
        /// <param name="inputFile">Flat file containing lines of comma-delimited integer values</param>
        /// <param name="outputFile">File that will contain a list of missing numbers</param>
        private static void PrintMissingNumbers(string inputFile, string outputFile)
        {
            FileProcessor fileProcessor = new FileProcessor(inputFile, outputFile);
            fileProcessor.ProcessFile(MissingNumberFinder.FindMissingNumber);
        }
    }
}
