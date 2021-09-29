
namespace SimpleFamilyBudgetApp_v_1._0._0
{
    partial class Form1
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
            this.panelTopAccountSummary = new System.Windows.Forms.Panel();
            this.panelLeftFilterBar = new System.Windows.Forms.Panel();
            this.panelleftFilterCloseOpen = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelTopAccountSummary
            // 
            this.panelTopAccountSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopAccountSummary.Location = new System.Drawing.Point(0, 0);
            this.panelTopAccountSummary.Name = "panelTopAccountSummary";
            this.panelTopAccountSummary.Size = new System.Drawing.Size(1602, 95);
            this.panelTopAccountSummary.TabIndex = 0;
            // 
            // panelLeftFilterBar
            // 
            this.panelLeftFilterBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftFilterBar.Location = new System.Drawing.Point(0, 95);
            this.panelLeftFilterBar.Name = "panelLeftFilterBar";
            this.panelLeftFilterBar.Size = new System.Drawing.Size(343, 836);
            this.panelLeftFilterBar.TabIndex = 1;
            // 
            // panelleftFilterCloseOpen
            // 
            this.panelleftFilterCloseOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelleftFilterCloseOpen.Location = new System.Drawing.Point(343, 95);
            this.panelleftFilterCloseOpen.Name = "panelleftFilterCloseOpen";
            this.panelleftFilterCloseOpen.Size = new System.Drawing.Size(40, 836);
            this.panelleftFilterCloseOpen.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 931);
            this.Controls.Add(this.panelleftFilterCloseOpen);
            this.Controls.Add(this.panelLeftFilterBar);
            this.Controls.Add(this.panelTopAccountSummary);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTopAccountSummary;
        private System.Windows.Forms.Panel panelLeftFilterBar;
        private System.Windows.Forms.Panel panelleftFilterCloseOpen;
    }
}

