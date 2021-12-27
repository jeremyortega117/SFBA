
namespace SimpleFamilyBudgetApp_v_1._0._0
{
    partial class BudgetEditor
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
            this.dataGridViewBudgets = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.listViewBudgetViewWindow = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSpent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelBudgeted = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBudgets)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBudgets
            // 
            this.dataGridViewBudgets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBudgets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBudgets.Location = new System.Drawing.Point(17, 70);
            this.dataGridViewBudgets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewBudgets.Name = "dataGridViewBudgets";
            this.dataGridViewBudgets.RowHeadersWidth = 51;
            this.dataGridViewBudgets.Size = new System.Drawing.Size(400, 434);
            this.dataGridViewBudgets.TabIndex = 4;
            this.dataGridViewBudgets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBudgets_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Update Budget";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewBudgetViewWindow
            // 
            this.listViewBudgetViewWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBudgetViewWindow.HideSelection = false;
            this.listViewBudgetViewWindow.Location = new System.Drawing.Point(444, 71);
            this.listViewBudgetViewWindow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewBudgetViewWindow.Name = "listViewBudgetViewWindow";
            this.listViewBudgetViewWindow.Size = new System.Drawing.Size(768, 440);
            this.listViewBudgetViewWindow.TabIndex = 6;
            this.listViewBudgetViewWindow.UseCompatibleStateImageBehavior = false;
            this.listViewBudgetViewWindow.SelectedIndexChanged += new System.EventHandler(this.listViewBudgetViewWindow_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(552, 22);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "Month -";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(659, 22);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "Month +";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(767, 22);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 9;
            this.button4.Text = "Year +";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(444, 22);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 28);
            this.button5.TabIndex = 10;
            this.button5.Text = "Year -";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(875, 26);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(164, 22);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(1048, 26);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(164, 22);
            this.dateTimePicker2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Spent: ";
            // 
            // labelSpent
            // 
            this.labelSpent.AutoSize = true;
            this.labelSpent.Location = new System.Drawing.Point(253, 44);
            this.labelSpent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpent.Name = "labelSpent";
            this.labelSpent.Size = new System.Drawing.Size(14, 16);
            this.labelSpent.TabIndex = 14;
            this.labelSpent.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Budgeted: ";
            // 
            // labelBudgeted
            // 
            this.labelBudgeted.AutoSize = true;
            this.labelBudgeted.Location = new System.Drawing.Point(253, 22);
            this.labelBudgeted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBudgeted.Name = "labelBudgeted";
            this.labelBudgeted.Size = new System.Drawing.Size(14, 16);
            this.labelBudgeted.TabIndex = 16;
            this.labelBudgeted.Text = "$";
            // 
            // BudgetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 517);
            this.Controls.Add(this.labelBudgeted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelSpent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listViewBudgetViewWindow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewBudgets);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1261, 1500);
            this.MinimumSize = new System.Drawing.Size(1261, 564);
            this.Name = "BudgetEditor";
            this.Text = "BudgetEditor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBudgets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewBudgets;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listViewBudgetViewWindow;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSpent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelBudgeted;
    }
}