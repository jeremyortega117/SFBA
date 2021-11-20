
namespace SimpleFamilyBudgetApp_v_1._0._0
{
    partial class TransactionEditor
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.comboBoxTransType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddTransType = new System.Windows.Forms.Button();
            this.labelAcctHolder = new System.Windows.Forms.Label();
            this.comboBoxAcct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.dateTimePickerTransDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonImportFile = new System.Windows.Forms.Button();
            this.checkBoxIncome = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 229);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // comboBoxTransType
            // 
            this.comboBoxTransType.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxTransType.FormattingEnabled = true;
            this.comboBoxTransType.Location = new System.Drawing.Point(287, 258);
            this.comboBoxTransType.Name = "comboBoxTransType";
            this.comboBoxTransType.Size = new System.Drawing.Size(194, 21);
            this.comboBoxTransType.TabIndex = 1;
            this.comboBoxTransType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Expense Type:";
            // 
            // buttonAddTransType
            // 
            this.buttonAddTransType.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAddTransType.Location = new System.Drawing.Point(487, 257);
            this.buttonAddTransType.Name = "buttonAddTransType";
            this.buttonAddTransType.Size = new System.Drawing.Size(120, 23);
            this.buttonAddTransType.TabIndex = 3;
            this.buttonAddTransType.Text = "Add Expense Type";
            this.buttonAddTransType.UseVisualStyleBackColor = true;
            this.buttonAddTransType.Click += new System.EventHandler(this.buttonAddTransType_Click);
            // 
            // labelAcctHolder
            // 
            this.labelAcctHolder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelAcctHolder.AutoSize = true;
            this.labelAcctHolder.Location = new System.Drawing.Point(214, 288);
            this.labelAcctHolder.Name = "labelAcctHolder";
            this.labelAcctHolder.Size = new System.Drawing.Size(67, 13);
            this.labelAcctHolder.TabIndex = 4;
            this.labelAcctHolder.Text = "On Account:";
            // 
            // comboBoxAcct
            // 
            this.comboBoxAcct.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxAcct.FormattingEnabled = true;
            this.comboBoxAcct.Location = new System.Drawing.Point(287, 285);
            this.comboBoxAcct.Name = "comboBoxAcct";
            this.comboBoxAcct.Size = new System.Drawing.Size(194, 21);
            this.comboBoxAcct.TabIndex = 5;
            this.comboBoxAcct.SelectedIndexChanged += new System.EventHandler(this.comboBoxUser_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Amount:";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxAmount.Location = new System.Drawing.Point(287, 312);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmount.TabIndex = 7;
            this.textBoxAmount.TextChanged += new System.EventHandler(this.textBoxAmount_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxDescription.Location = new System.Drawing.Point(287, 338);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(194, 20);
            this.textBoxDescription.TabIndex = 9;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            // 
            // dateTimePickerTransDate
            // 
            this.dateTimePickerTransDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateTimePickerTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTransDate.Location = new System.Drawing.Point(287, 364);
            this.dateTimePickerTransDate.Name = "dateTimePickerTransDate";
            this.dateTimePickerTransDate.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerTransDate.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Purchase Date:";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(287, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 47);
            this.button1.TabIndex = 12;
            this.button1.Text = "Submit Expense";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonImportFile
            // 
            this.buttonImportFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonImportFile.Location = new System.Drawing.Point(487, 283);
            this.buttonImportFile.Name = "buttonImportFile";
            this.buttonImportFile.Size = new System.Drawing.Size(120, 23);
            this.buttonImportFile.TabIndex = 13;
            this.buttonImportFile.Text = "Import File";
            this.buttonImportFile.UseVisualStyleBackColor = true;
            this.buttonImportFile.Click += new System.EventHandler(this.buttonImportFile_Click);
            // 
            // checkBoxIncome
            // 
            this.checkBoxIncome.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxIncome.AutoSize = true;
            this.checkBoxIncome.Location = new System.Drawing.Point(613, 260);
            this.checkBoxIncome.Name = "checkBoxIncome";
            this.checkBoxIncome.Size = new System.Drawing.Size(61, 17);
            this.checkBoxIncome.TabIndex = 14;
            this.checkBoxIncome.Text = "Income";
            this.checkBoxIncome.UseVisualStyleBackColor = true;
            // 
            // TransactionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.checkBoxIncome);
            this.Controls.Add(this.buttonImportFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerTransDate);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxAcct);
            this.Controls.Add(this.labelAcctHolder);
            this.Controls.Add(this.buttonAddTransType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTransType);
            this.Controls.Add(this.listView1);
            this.MaximumSize = new System.Drawing.Size(816, 1000);
            this.MinimumSize = new System.Drawing.Size(816, 500);
            this.Name = "TransactionEditor";
            this.Text = "TransactionEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBoxTransType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddTransType;
        private System.Windows.Forms.Label labelAcctHolder;
        private System.Windows.Forms.ComboBox comboBoxAcct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerTransDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonImportFile;
        private System.Windows.Forms.CheckBox checkBoxIncome;
    }
}