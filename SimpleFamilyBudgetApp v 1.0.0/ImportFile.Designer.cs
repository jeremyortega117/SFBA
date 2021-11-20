
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
            this.SuspendLayout();
            // 
            // textBoxFileLocation
            // 
            this.textBoxFileLocation.Location = new System.Drawing.Point(135, 51);
            this.textBoxFileLocation.Name = "textBoxFileLocation";
            this.textBoxFileLocation.Size = new System.Drawing.Size(381, 20);
            this.textBoxFileLocation.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(197, 98);
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
            this.checkBoxIgnoreDups.Location = new System.Drawing.Point(376, 77);
            this.checkBoxIgnoreDups.Name = "checkBoxIgnoreDups";
            this.checkBoxIgnoreDups.Size = new System.Drawing.Size(140, 17);
            this.checkBoxIgnoreDups.TabIndex = 7;
            this.checkBoxIgnoreDups.Text = "Ignore Duplicates In File";
            this.checkBoxIgnoreDups.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreDups.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreDups_CheckedChanged);
            // 
            // ImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 144);
            this.Controls.Add(this.checkBoxIgnoreDups);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxFileLocation);
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
    }
}