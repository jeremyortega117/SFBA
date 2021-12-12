
namespace SimpleFamilyBudgetApp_v_1._0._0
{
    partial class ImportFile
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
            this.textBoxFileLocation = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.checkBoxIgnoreDups = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFileLocation
            // 
            this.textBoxFileLocation.Enabled = false;
            this.textBoxFileLocation.Location = new System.Drawing.Point(178, 61);
            this.textBoxFileLocation.Name = "textBoxFileLocation";
            this.textBoxFileLocation.Size = new System.Drawing.Size(381, 20);
            this.textBoxFileLocation.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(240, 108);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(162, 34);
            this.buttonImport.TabIndex = 6;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // checkBoxIgnoreDups
            // 
            this.checkBoxIgnoreDups.AutoSize = true;
            this.checkBoxIgnoreDups.Location = new System.Drawing.Point(419, 87);
            this.checkBoxIgnoreDups.Name = "checkBoxIgnoreDups";
            this.checkBoxIgnoreDups.Size = new System.Drawing.Size(140, 17);
            this.checkBoxIgnoreDups.TabIndex = 7;
            this.checkBoxIgnoreDups.Text = "Ignore Duplicates In File";
            this.checkBoxIgnoreDups.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreDups.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreDups_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "File Header :  Date | Description | Original Description | Category | Amount | St" +
    "atus ";
            // 
            // ImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 154);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxIgnoreDups);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxFileLocation);
            this.MaximumSize = new System.Drawing.Size(651, 193);
            this.MinimumSize = new System.Drawing.Size(651, 193);
            this.Name = "ImportFile";
            this.Text = "Import File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFileLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.CheckBox checkBoxIgnoreDups;
        private System.Windows.Forms.Label label1;
    }
}