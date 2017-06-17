using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MissingNumber
{
    public partial class NumbersInput : Form
    {
        public NumbersInput()
        {
            InitializeComponent();
        }

        void btnUploadFile_Click(object sender, EventArgs e)
        {
            // Open up a dialog
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "txt files (*.txt)|*.txt";

            // Open up a stream to read from the uploaded file
            Stream stream;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = dialog.OpenFile()) != null)
                {
                    using (stream)
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                int missingNumber = findMissingNumber(line);
                                
                                // Append each result to a new line. (\n)
                                txtMissingNumbers.AppendText(missingNumber + "\n");
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Accepts a comma delimited list of numbers, splits them up and finds the missing number in them.
        /// </summary>
        /// <param name="seqNumbers">The comma delimited list of numbers.</param>
        /// <returns>The number missing from the sorted list of numbers.</returns>
        private int findMissingNumber(string seqNumbers)
        {
            // Split string of numbers using a comma delimeter
            List<int> numbers = seqNumbers.Split(',').Select(int.Parse).ToList();

            return getMissingNumber(numbers, numbers.Count);
        }

        /// <summary>
        /// Finds the number missing out of an assorted array of integers.
        /// </summary>
        /// <param name="numbers">The list of numbers to evaluate.</param>
        /// <param name="countOfNumbers">The number of items in the passed in list.</param>
        /// <returns></returns>
        private int getMissingNumber(List<int> numbers, int countOfNumbers)
        {
            // Sort the numbers so we can run through them.
            numbers.Sort();

            int previousNumber = 0;
            for(int i = 0; i < countOfNumbers; i++)
            {
                if (i > 0) // There won't be a previous number on the first pass. Wait until the second number.
                    if (Math.Abs(numbers[i] - previousNumber) > 1) // Find the number that's more than 1 away from the previous number.
                            return previousNumber + 1; // Since we had a gap of 2, return the missing number between the 2 numbers.

                previousNumber = numbers[i];
            }

            return 0; // Something went wrong. Return a base value.
        }
    }
}
