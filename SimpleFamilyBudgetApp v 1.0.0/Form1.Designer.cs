﻿
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelLeftFilterBar = new System.Windows.Forms.Panel();
            this.panelleftFilterCloseOpen = new System.Windows.Forms.Panel();
            this.buttonLeftFilterHide = new System.Windows.Forms.Button();
            this.panelMainDisplayFullBackground = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelleftMainBottom = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelLeftMainTop = new System.Windows.Forms.Panel();
            this.panelRIghtMainBottom = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panelRightMainTop = new System.Windows.Forms.Panel();
            this.listViewOne = new System.Windows.Forms.ListView();
            this.listViewTwo = new System.Windows.Forms.ListView();
            this.panelTopAccountSummary.SuspendLayout();
            this.panelleftFilterCloseOpen.SuspendLayout();
            this.panelMainDisplayFullBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelleftMainBottom.SuspendLayout();
            this.panelRIghtMainBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopAccountSummary
            // 
            this.panelTopAccountSummary.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTopAccountSummary.Controls.Add(this.toolStrip1);
            this.panelTopAccountSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopAccountSummary.Location = new System.Drawing.Point(0, 0);
            this.panelTopAccountSummary.Name = "panelTopAccountSummary";
            this.panelTopAccountSummary.Size = new System.Drawing.Size(1904, 160);
            this.panelTopAccountSummary.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1904, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panelLeftFilterBar
            // 
            this.panelLeftFilterBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelLeftFilterBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftFilterBar.Location = new System.Drawing.Point(0, 160);
            this.panelLeftFilterBar.Name = "panelLeftFilterBar";
            this.panelLeftFilterBar.Size = new System.Drawing.Size(343, 881);
            this.panelLeftFilterBar.TabIndex = 1;
            // 
            // panelleftFilterCloseOpen
            // 
            this.panelleftFilterCloseOpen.Controls.Add(this.buttonLeftFilterHide);
            this.panelleftFilterCloseOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelleftFilterCloseOpen.Location = new System.Drawing.Point(343, 160);
            this.panelleftFilterCloseOpen.Name = "panelleftFilterCloseOpen";
            this.panelleftFilterCloseOpen.Size = new System.Drawing.Size(40, 881);
            this.panelleftFilterCloseOpen.TabIndex = 2;
            // 
            // buttonLeftFilterHide
            // 
            this.buttonLeftFilterHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLeftFilterHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLeftFilterHide.Location = new System.Drawing.Point(0, 0);
            this.buttonLeftFilterHide.Name = "buttonLeftFilterHide";
            this.buttonLeftFilterHide.Size = new System.Drawing.Size(40, 881);
            this.buttonLeftFilterHide.TabIndex = 0;
            this.buttonLeftFilterHide.Text = "<";
            this.buttonLeftFilterHide.UseVisualStyleBackColor = true;
            this.buttonLeftFilterHide.Click += new System.EventHandler(this.buttonLeftFilterHide_Click);
            // 
            // panelMainDisplayFullBackground
            // 
            this.panelMainDisplayFullBackground.Controls.Add(this.splitContainer1);
            this.panelMainDisplayFullBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainDisplayFullBackground.Location = new System.Drawing.Point(383, 160);
            this.panelMainDisplayFullBackground.Name = "panelMainDisplayFullBackground";
            this.panelMainDisplayFullBackground.Size = new System.Drawing.Size(1521, 881);
            this.panelMainDisplayFullBackground.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelleftMainBottom);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            this.splitContainer1.Panel1.Controls.Add(this.panelLeftMainTop);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelRIghtMainBottom);
            this.splitContainer1.Panel2.Controls.Add(this.splitter2);
            this.splitContainer1.Panel2.Controls.Add(this.panelRightMainTop);
            this.splitContainer1.Size = new System.Drawing.Size(1521, 881);
            this.splitContainer1.SplitterDistance = 746;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelleftMainBottom
            // 
            this.panelleftMainBottom.Controls.Add(this.listViewOne);
            this.panelleftMainBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelleftMainBottom.Location = new System.Drawing.Point(0, 498);
            this.panelleftMainBottom.Name = "panelleftMainBottom";
            this.panelleftMainBottom.Size = new System.Drawing.Size(742, 379);
            this.panelleftMainBottom.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 488);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(742, 10);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panelLeftMainTop
            // 
            this.panelLeftMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftMainTop.Location = new System.Drawing.Point(0, 0);
            this.panelLeftMainTop.Name = "panelLeftMainTop";
            this.panelLeftMainTop.Size = new System.Drawing.Size(742, 488);
            this.panelLeftMainTop.TabIndex = 0;
            // 
            // panelRIghtMainBottom
            // 
            this.panelRIghtMainBottom.Controls.Add(this.listViewTwo);
            this.panelRIghtMainBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRIghtMainBottom.Location = new System.Drawing.Point(0, 498);
            this.panelRIghtMainBottom.Name = "panelRIghtMainBottom";
            this.panelRIghtMainBottom.Size = new System.Drawing.Size(767, 379);
            this.panelRIghtMainBottom.TabIndex = 2;
            // 
            // splitter2
            // 
            this.splitter2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 488);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(767, 10);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panelRightMainTop
            // 
            this.panelRightMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightMainTop.Location = new System.Drawing.Point(0, 0);
            this.panelRightMainTop.Name = "panelRightMainTop";
            this.panelRightMainTop.Size = new System.Drawing.Size(767, 488);
            this.panelRightMainTop.TabIndex = 0;
            // 
            // listViewOne
            // 
            this.listViewOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOne.HideSelection = false;
            this.listViewOne.Location = new System.Drawing.Point(0, 0);
            this.listViewOne.Name = "listViewOne";
            this.listViewOne.Size = new System.Drawing.Size(742, 379);
            this.listViewOne.TabIndex = 0;
            this.listViewOne.UseCompatibleStateImageBehavior = false;
            // 
            // listViewTwo
            // 
            this.listViewTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTwo.HideSelection = false;
            this.listViewTwo.Location = new System.Drawing.Point(0, 0);
            this.listViewTwo.Name = "listViewTwo";
            this.listViewTwo.Size = new System.Drawing.Size(767, 379);
            this.listViewTwo.TabIndex = 0;
            this.listViewTwo.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panelMainDisplayFullBackground);
            this.Controls.Add(this.panelleftFilterCloseOpen);
            this.Controls.Add(this.panelLeftFilterBar);
            this.Controls.Add(this.panelTopAccountSummary);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelTopAccountSummary.ResumeLayout(false);
            this.panelTopAccountSummary.PerformLayout();
            this.panelleftFilterCloseOpen.ResumeLayout(false);
            this.panelMainDisplayFullBackground.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelleftMainBottom.ResumeLayout(false);
            this.panelRIghtMainBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTopAccountSummary;
        private System.Windows.Forms.Panel panelLeftFilterBar;
        private System.Windows.Forms.Panel panelleftFilterCloseOpen;
        private System.Windows.Forms.Button buttonLeftFilterHide;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panelMainDisplayFullBackground;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelleftMainBottom;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelLeftMainTop;
        private System.Windows.Forms.Panel panelRIghtMainBottom;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panelRightMainTop;
        private System.Windows.Forms.ListView listViewOne;
        private System.Windows.Forms.ListView listViewTwo;
    }
}

