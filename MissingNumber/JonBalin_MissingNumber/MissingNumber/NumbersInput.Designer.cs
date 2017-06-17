namespace MissingNumber
{
    partial class NumbersInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMissingNumbers = new System.Windows.Forms.TextBox();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.fileOpener = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtMissingNumbers
            // 
            this.txtMissingNumbers.Location = new System.Drawing.Point(12, 48);
            this.txtMissingNumbers.Multiline = true;
            this.txtMissingNumbers.Name = "txtMissingNumbers";
            this.txtMissingNumbers.Size = new System.Drawing.Size(513, 158);
            this.txtMissingNumbers.TabIndex = 1;
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(12, 12);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(513, 30);
            this.btnUploadFile.TabIndex = 2;
            this.btnUploadFile.Text = "Open a Flat File";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // fileOpener
            // 
            this.fileOpener.FileName = "openFile";
            // 
            // NumbersInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 215);
            this.Controls.Add(this.btnUploadFile);
            this.Controls.Add(this.txtMissingNumbers);
            this.Name = "NumbersInput";
            this.Text = "Missing Numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMissingNumbers;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.OpenFileDialog fileOpener;
    }
}

