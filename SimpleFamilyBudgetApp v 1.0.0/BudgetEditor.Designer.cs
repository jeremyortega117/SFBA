
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
            this.dataGridViewBudgets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewBudgets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBudgets.Location = new System.Drawing.Point(13, 57);
            this.dataGridViewBudgets.Name = "dataGridViewBudgets";
            this.dataGridViewBudgets.Size = new System.Drawing.Size(300, 353);
            this.dataGridViewBudgets.TabIndex = 4;
            this.dataGridViewBudgets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBudgets_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Update Budget";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewBudgetViewWindow
            // 
            this.listViewBudgetViewWindow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewBudgetViewWindow.HideSelection = false;
            this.listViewBudgetViewWindow.Location = new System.Drawing.Point(333, 58);
            this.listViewBudgetViewWindow.Name = "listViewBudgetViewWindow";
            this.listViewBudgetViewWindow.Size = new System.Drawing.Size(577, 358);
            this.listViewBudgetViewWindow.TabIndex = 6;
            this.listViewBudgetViewWindow.UseCompatibleStateImageBehavior = false;
            this.listViewBudgetViewWindow.SelectedIndexChanged += new System.EventHandler(this.listViewBudgetViewWindow_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(414, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Month -";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(494, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Month +";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(575, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Year +";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(333, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "Year -";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(656, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(786, 21);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(124, 20);
            this.dateTimePicker2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Spent: ";
            // 
            // labelSpent
            // 
            this.labelSpent.AutoSize = true;
            this.labelSpent.Location = new System.Drawing.Point(190, 36);
            this.labelSpent.Name = "labelSpent";
            this.labelSpent.Size = new System.Drawing.Size(13, 13);
            this.labelSpent.TabIndex = 14;
            this.labelSpent.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Budgeted: ";
            // 
            // labelBudgeted
            // 
            this.labelBudgeted.AutoSize = true;
            this.labelBudgeted.Location = new System.Drawing.Point(190, 18);
            this.labelBudgeted.Name = "labelBudgeted";
            this.labelBudgeted.Size = new System.Drawing.Size(13, 13);
            this.labelBudgeted.TabIndex = 16;
            this.labelBudgeted.Text = "$";
            // 
            // BudgetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 428);
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
            this.MaximumSize = new System.Drawing.Size(950, 467);
            this.MinimumSize = new System.Drawing.Size(950, 467);
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