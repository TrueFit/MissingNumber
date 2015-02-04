using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TrueFitMissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Cannot execute program without an input file.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                String numberLine = null;
                StreamReader streamReader = new StreamReader(args[0]);

                if (streamReader != null)
                {
                    while ((numberLine = streamReader.ReadLine()) != null)
                    {
                        try
                        {
                            if (numberLine != "")
                            {
                                Series numberSeries = new Series(numberLine);
                                Console.WriteLine((numberSeries.findMissingNumber()).ToString());
                                Console.WriteLine(Environment.NewLine);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }


                    }
                }

            }
        }
    }
}
