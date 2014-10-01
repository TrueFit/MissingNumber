using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissingNumberPresentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            PathAndFileName.Text = @"C:\git\MissingNumber\MissingNumberList.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MissingNumberDataManagement.Utilities utilities = new MissingNumberDataManagement.Utilities();

                List<Int64> missingNumbers = utilities.MissingNumber(PathAndFileName.Text);

                string missingNumbersList = "";
                for (int i = 0; i < missingNumbers.Count; i++)
                {
                    if (i != 0)
                    {
                        missingNumbersList = missingNumbersList + Environment.NewLine + Environment.NewLine;
                    }

                    missingNumbersList = missingNumbersList + missingNumbers[i];
                }

                MessageBox.Show(missingNumbersList, "Missing:");
            }
            catch (Exception ex)
            {
                string errorToShow = "Error in utilities.MissingNumber." + Environment.NewLine + Environment.NewLine;
                errorToShow = errorToShow + ex.Message + Environment.NewLine;

                if (ex.InnerException != null)
                {
                    errorToShow = errorToShow + Environment.NewLine;
                    errorToShow = errorToShow + ex.InnerException;
                }


                MessageBox.Show(errorToShow, "Error: Please contact customer support.");
            }
        }
    }
}
