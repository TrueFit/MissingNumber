using System;
using System.Windows.Forms;
using MissingNumberSecretSauce;

namespace FindTheMissingNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var finder = new MissingNumberFinder();
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = @"Open Data Input File"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = @"Save Output Data File"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            var inputData = finder.FetchInputData(openFileDialog.FileName);
            var parsedData = finder.ParseInputData(inputData);
            var resultList = finder.CalculateMissingNumbers(parsedData);
            finder.CreateDataOutput(resultList, saveFileDialog.FileName);
        }
    }
}
