
namespace SimpleFamilyBudgetApp_v_1._0._0
{
    partial class BillEditor
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
            this.listViewExistingBills = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.checkBoxSunday = new System.Windows.Forms.CheckBox();
            this.checkBoxSaturday = new System.Windows.Forms.CheckBox();
            this.checkBoxFriday = new System.Windows.Forms.CheckBox();
            this.checkBoxThursday = new System.Windows.Forms.CheckBox();
            this.checkBoxWednesday = new System.Windows.Forms.CheckBox();
            this.checkBoxTuesday = new System.Windows.Forms.CheckBox();
            this.checkBoxMonday = new System.Windows.Forms.CheckBox();
            this.radioButtonYearly = new System.Windows.Forms.RadioButton();
            this.radioButtonMonthly = new System.Windows.Forms.RadioButton();
            this.radioButtonWeekly = new System.Windows.Forms.RadioButton();
            this.radioButtonDaily = new System.Windows.Forms.RadioButton();
            this.dateTimePickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerToDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxBillType = new System.Windows.Forms.ComboBox();
            this.buttonInsertNewBill = new System.Windows.Forms.Button();
            this.comboBoxAccount = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.textBoxPayOffTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxDescription = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonNewDescription = new System.Windows.Forms.RadioButton();
            this.radioButtonUseExistingDescription = new System.Windows.Forms.RadioButton();
            this.textBoxPercent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTotalIntPaid = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelNextIntPercAmt = new System.Windows.Forms.Label();
            this.labellabelNextPrincPayAmt = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.radioButtonDailyInt = new System.Windows.Forms.RadioButton();
            this.radioButtonMonthlyInt = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.TotalPlusInterest = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewExistingBills
            // 
            this.listViewExistingBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewExistingBills.HideSelection = false;
            this.listViewExistingBills.Location = new System.Drawing.Point(0, 0);
            this.listViewExistingBills.Name = "listViewExistingBills";
            this.listViewExistingBills.Size = new System.Drawing.Size(601, 324);
            this.listViewExistingBills.TabIndex = 0;
            this.listViewExistingBills.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 545);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Description";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxDescription.Location = new System.Drawing.Point(393, 541);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(160, 20);
            this.textBoxDescription.TabIndex = 26;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            // 
            // checkBoxSunday
            // 
            this.checkBoxSunday.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxSunday.AutoSize = true;
            this.checkBoxSunday.Location = new System.Drawing.Point(416, 447);
            this.checkBoxSunday.Name = "checkBoxSunday";
            this.checkBoxSunday.Size = new System.Drawing.Size(62, 17);
            this.checkBoxSunday.TabIndex = 25;
            this.checkBoxSunday.Text = "Sunday";
            this.checkBoxSunday.UseVisualStyleBackColor = true;
            this.checkBoxSunday.CheckedChanged += new System.EventHandler(this.checkBoxSunday_CheckedChanged);
            // 
            // checkBoxSaturday
            // 
            this.checkBoxSaturday.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxSaturday.AutoSize = true;
            this.checkBoxSaturday.Location = new System.Drawing.Point(335, 470);
            this.checkBoxSaturday.Name = "checkBoxSaturday";
            this.checkBoxSaturday.Size = new System.Drawing.Size(68, 17);
            this.checkBoxSaturday.TabIndex = 24;
            this.checkBoxSaturday.Text = "Saturday";
            this.checkBoxSaturday.UseVisualStyleBackColor = true;
            this.checkBoxSaturday.CheckedChanged += new System.EventHandler(this.checkBoxSaturday_CheckedChanged);
            // 
            // checkBoxFriday
            // 
            this.checkBoxFriday.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxFriday.AutoSize = true;
            this.checkBoxFriday.Location = new System.Drawing.Point(335, 447);
            this.checkBoxFriday.Name = "checkBoxFriday";
            this.checkBoxFriday.Size = new System.Drawing.Size(54, 17);
            this.checkBoxFriday.TabIndex = 23;
            this.checkBoxFriday.Text = "Friday";
            this.checkBoxFriday.UseVisualStyleBackColor = true;
            this.checkBoxFriday.CheckedChanged += new System.EventHandler(this.checkBoxFriday_CheckedChanged);
            // 
            // checkBoxThursday
            // 
            this.checkBoxThursday.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxThursday.AutoSize = true;
            this.checkBoxThursday.Location = new System.Drawing.Point(228, 470);
            this.checkBoxThursday.Name = "checkBoxThursday";
            this.checkBoxThursday.Size = new System.Drawing.Size(70, 17);
            this.checkBoxThursday.TabIndex = 22;
            this.checkBoxThursday.Text = "Thursday";
            this.checkBoxThursday.UseVisualStyleBackColor = true;
            this.checkBoxThursday.CheckedChanged += new System.EventHandler(this.checkBoxThursday_CheckedChanged);
            // 
            // checkBoxWednesday
            // 
            this.checkBoxWednesday.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxWednesday.AutoSize = true;
            this.checkBoxWednesday.Location = new System.Drawing.Point(228, 447);
            this.checkBoxWednesday.Name = "checkBoxWednesday";
            this.checkBoxWednesday.Size = new System.Drawing.Size(83, 17);
            this.checkBoxWednesday.TabIndex = 21;
            this.checkBoxWednesday.Text = "Wednesday";
            this.checkBoxWednesday.UseVisualStyleBackColor = true;
            this.checkBoxWednesday.CheckedChanged += new System.EventHandler(this.checkBoxWednesday_CheckedChanged);
            // 
            // checkBoxTuesday
            // 
            this.checkBoxTuesday.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxTuesday.AutoSize = true;
            this.checkBoxTuesday.Location = new System.Drawing.Point(128, 470);
            this.checkBoxTuesday.Name = "checkBoxTuesday";
            this.checkBoxTuesday.Size = new System.Drawing.Size(67, 17);
            this.checkBoxTuesday.TabIndex = 20;
            this.checkBoxTuesday.Text = "Tuesday";
            this.checkBoxTuesday.UseVisualStyleBackColor = true;
            this.checkBoxTuesday.CheckedChanged += new System.EventHandler(this.checkBoxTuesday_CheckedChanged);
            // 
            // checkBoxMonday
            // 
            this.checkBoxMonday.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxMonday.AutoSize = true;
            this.checkBoxMonday.Location = new System.Drawing.Point(128, 447);
            this.checkBoxMonday.Name = "checkBoxMonday";
            this.checkBoxMonday.Size = new System.Drawing.Size(64, 17);
            this.checkBoxMonday.TabIndex = 19;
            this.checkBoxMonday.Text = "Monday";
            this.checkBoxMonday.UseVisualStyleBackColor = true;
            this.checkBoxMonday.CheckedChanged += new System.EventHandler(this.checkBoxMonday_CheckedChanged);
            // 
            // radioButtonYearly
            // 
            this.radioButtonYearly.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonYearly.AutoSize = true;
            this.radioButtonYearly.Location = new System.Drawing.Point(376, 412);
            this.radioButtonYearly.Name = "radioButtonYearly";
            this.radioButtonYearly.Size = new System.Drawing.Size(54, 17);
            this.radioButtonYearly.TabIndex = 18;
            this.radioButtonYearly.TabStop = true;
            this.radioButtonYearly.Text = "Yearly";
            this.radioButtonYearly.UseVisualStyleBackColor = true;
            this.radioButtonYearly.CheckedChanged += new System.EventHandler(this.radioButtonYearly_CheckedChanged);
            // 
            // radioButtonMonthly
            // 
            this.radioButtonMonthly.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonMonthly.AutoSize = true;
            this.radioButtonMonthly.Location = new System.Drawing.Point(308, 412);
            this.radioButtonMonthly.Name = "radioButtonMonthly";
            this.radioButtonMonthly.Size = new System.Drawing.Size(62, 17);
            this.radioButtonMonthly.TabIndex = 17;
            this.radioButtonMonthly.TabStop = true;
            this.radioButtonMonthly.Text = "Monthly";
            this.radioButtonMonthly.UseVisualStyleBackColor = true;
            this.radioButtonMonthly.CheckedChanged += new System.EventHandler(this.radioButtonMonthly_CheckedChanged);
            // 
            // radioButtonWeekly
            // 
            this.radioButtonWeekly.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonWeekly.AutoSize = true;
            this.radioButtonWeekly.Location = new System.Drawing.Point(241, 412);
            this.radioButtonWeekly.Name = "radioButtonWeekly";
            this.radioButtonWeekly.Size = new System.Drawing.Size(61, 17);
            this.radioButtonWeekly.TabIndex = 16;
            this.radioButtonWeekly.TabStop = true;
            this.radioButtonWeekly.Text = "Weekly";
            this.radioButtonWeekly.UseVisualStyleBackColor = true;
            this.radioButtonWeekly.CheckedChanged += new System.EventHandler(this.radioButtonWeekly_CheckedChanged);
            // 
            // radioButtonDaily
            // 
            this.radioButtonDaily.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonDaily.AutoSize = true;
            this.radioButtonDaily.Location = new System.Drawing.Point(187, 412);
            this.radioButtonDaily.Name = "radioButtonDaily";
            this.radioButtonDaily.Size = new System.Drawing.Size(48, 17);
            this.radioButtonDaily.TabIndex = 15;
            this.radioButtonDaily.TabStop = true;
            this.radioButtonDaily.Text = "Daily";
            this.radioButtonDaily.UseVisualStyleBackColor = true;
            this.radioButtonDaily.CheckedChanged += new System.EventHandler(this.radioButtonDaily_CheckedChanged);
            // 
            // dateTimePickerFromDate
            // 
            this.dateTimePickerFromDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateTimePickerFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFromDate.Location = new System.Drawing.Point(176, 502);
            this.dateTimePickerFromDate.Name = "dateTimePickerFromDate";
            this.dateTimePickerFromDate.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerFromDate.TabIndex = 29;
            this.dateTimePickerFromDate.ValueChanged += new System.EventHandler(this.dateTimePickerFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Bill Start Date";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Bill End Date";
            // 
            // dateTimePickerToDate
            // 
            this.dateTimePickerToDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dateTimePickerToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerToDate.Location = new System.Drawing.Point(393, 504);
            this.dateTimePickerToDate.Name = "dateTimePickerToDate";
            this.dateTimePickerToDate.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerToDate.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Bill Type";
            // 
            // comboBoxBillType
            // 
            this.comboBoxBillType.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxBillType.FormattingEnabled = true;
            this.comboBoxBillType.Location = new System.Drawing.Point(107, 336);
            this.comboBoxBillType.Name = "comboBoxBillType";
            this.comboBoxBillType.Size = new System.Drawing.Size(168, 21);
            this.comboBoxBillType.TabIndex = 34;
            this.comboBoxBillType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonInsertNewBill
            // 
            this.buttonInsertNewBill.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonInsertNewBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsertNewBill.Location = new System.Drawing.Point(127, 706);
            this.buttonInsertNewBill.Name = "buttonInsertNewBill";
            this.buttonInsertNewBill.Size = new System.Drawing.Size(330, 43);
            this.buttonInsertNewBill.TabIndex = 37;
            this.buttonInsertNewBill.Text = "Insert Bill";
            this.buttonInsertNewBill.UseVisualStyleBackColor = true;
            this.buttonInsertNewBill.Click += new System.EventHandler(this.buttonInsertNewBill_Click);
            // 
            // comboBoxAccount
            // 
            this.comboBoxAccount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxAccount.FormattingEnabled = true;
            this.comboBoxAccount.Location = new System.Drawing.Point(393, 336);
            this.comboBoxAccount.Name = "comboBoxAccount";
            this.comboBoxAccount.Size = new System.Drawing.Size(160, 21);
            this.comboBoxAccount.TabIndex = 38;
            this.comboBoxAccount.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Account";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxAmount.Location = new System.Drawing.Point(148, 371);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(127, 20);
            this.textBoxAmount.TabIndex = 36;
            this.textBoxAmount.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxPayOffTotal
            // 
            this.textBoxPayOffTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxPayOffTotal.Location = new System.Drawing.Point(393, 371);
            this.textBoxPayOffTotal.Name = "textBoxPayOffTotal";
            this.textBoxPayOffTotal.Size = new System.Drawing.Size(160, 20);
            this.textBoxPayOffTotal.TabIndex = 40;
            this.textBoxPayOffTotal.TextChanged += new System.EventHandler(this.textBoxPayOffTotal_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Reoccuring Payments";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Total Payment Cost";
            // 
            // comboBoxDescription
            // 
            this.comboBoxDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxDescription.FormattingEnabled = true;
            this.comboBoxDescription.Location = new System.Drawing.Point(107, 541);
            this.comboBoxDescription.Name = "comboBoxDescription";
            this.comboBoxDescription.Size = new System.Drawing.Size(168, 21);
            this.comboBoxDescription.TabIndex = 43;
            this.comboBoxDescription.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 544);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "New Descr.";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.radioButtonNewDescription);
            this.panel1.Controls.Add(this.radioButtonUseExistingDescription);
            this.panel1.Location = new System.Drawing.Point(102, 568);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 69);
            this.panel1.TabIndex = 46;
            // 
            // radioButtonNewDescription
            // 
            this.radioButtonNewDescription.AutoSize = true;
            this.radioButtonNewDescription.Location = new System.Drawing.Point(291, 3);
            this.radioButtonNewDescription.Name = "radioButtonNewDescription";
            this.radioButtonNewDescription.Size = new System.Drawing.Size(103, 17);
            this.radioButtonNewDescription.TabIndex = 1;
            this.radioButtonNewDescription.TabStop = true;
            this.radioButtonNewDescription.Text = "New Description";
            this.radioButtonNewDescription.UseVisualStyleBackColor = true;
            this.radioButtonNewDescription.CheckedChanged += new System.EventHandler(this.radioButtonNewDescription_CheckedChanged);
            // 
            // radioButtonUseExistingDescription
            // 
            this.radioButtonUseExistingDescription.AutoSize = true;
            this.radioButtonUseExistingDescription.Location = new System.Drawing.Point(5, 3);
            this.radioButtonUseExistingDescription.Name = "radioButtonUseExistingDescription";
            this.radioButtonUseExistingDescription.Size = new System.Drawing.Size(156, 17);
            this.radioButtonUseExistingDescription.TabIndex = 0;
            this.radioButtonUseExistingDescription.TabStop = true;
            this.radioButtonUseExistingDescription.Text = "Choose Existing Description";
            this.radioButtonUseExistingDescription.UseVisualStyleBackColor = true;
            this.radioButtonUseExistingDescription.CheckedChanged += new System.EventHandler(this.radioButtonUseExistingDescription_CheckedChanged);
            // 
            // textBoxPercent
            // 
            this.textBoxPercent.Location = new System.Drawing.Point(89, 3);
            this.textBoxPercent.Name = "textBoxPercent";
            this.textBoxPercent.Size = new System.Drawing.Size(48, 20);
            this.textBoxPercent.TabIndex = 47;
            this.textBoxPercent.TextChanged += new System.EventHandler(this.textBoxPercent_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Interest rate: %";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.TotalPlusInterest);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.labelTotalIntPaid);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.labelNextIntPercAmt);
            this.panel2.Controls.Add(this.labellabelNextPrincPayAmt);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.radioButtonDailyInt);
            this.panel2.Controls.Add(this.radioButtonMonthlyInt);
            this.panel2.Controls.Add(this.textBoxPercent);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(13, 612);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 88);
            this.panel2.TabIndex = 49;
            // 
            // labelTotalIntPaid
            // 
            this.labelTotalIntPaid.AutoSize = true;
            this.labelTotalIntPaid.Location = new System.Drawing.Point(499, 32);
            this.labelTotalIntPaid.Name = "labelTotalIntPaid";
            this.labelTotalIntPaid.Size = new System.Drawing.Size(13, 13);
            this.labelTotalIntPaid.TabIndex = 58;
            this.labelTotalIntPaid.Text = "$";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(400, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "Total Intrest Paid: ";
            // 
            // labelNextIntPercAmt
            // 
            this.labelNextIntPercAmt.AutoSize = true;
            this.labelNextIntPercAmt.Location = new System.Drawing.Point(499, 8);
            this.labelNextIntPercAmt.Name = "labelNextIntPercAmt";
            this.labelNextIntPercAmt.Size = new System.Drawing.Size(13, 13);
            this.labelNextIntPercAmt.TabIndex = 56;
            this.labelNextIntPercAmt.Text = "$";
            // 
            // labellabelNextPrincPayAmt
            // 
            this.labellabelNextPrincPayAmt.AutoSize = true;
            this.labellabelNextPrincPayAmt.Location = new System.Drawing.Point(361, 6);
            this.labellabelNextPrincPayAmt.Name = "labellabelNextPrincPayAmt";
            this.labellabelNextPrincPayAmt.Size = new System.Drawing.Size(13, 13);
            this.labellabelNextPrincPayAmt.TabIndex = 55;
            this.labellabelNextPrincPayAmt.Text = "$";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(448, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 54;
            this.label11.Text = "Next Int.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(296, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "Next Princ.";
            // 
            // radioButtonDailyInt
            // 
            this.radioButtonDailyInt.AutoSize = true;
            this.radioButtonDailyInt.Location = new System.Drawing.Point(223, 4);
            this.radioButtonDailyInt.Name = "radioButtonDailyInt";
            this.radioButtonDailyInt.Size = new System.Drawing.Size(48, 17);
            this.radioButtonDailyInt.TabIndex = 50;
            this.radioButtonDailyInt.TabStop = true;
            this.radioButtonDailyInt.Text = "Daily";
            this.radioButtonDailyInt.UseVisualStyleBackColor = true;
            this.radioButtonDailyInt.CheckedChanged += new System.EventHandler(this.radioButtonDailyInt_CheckedChanged);
            // 
            // radioButtonMonthlyInt
            // 
            this.radioButtonMonthlyInt.AutoSize = true;
            this.radioButtonMonthlyInt.Location = new System.Drawing.Point(156, 4);
            this.radioButtonMonthlyInt.Name = "radioButtonMonthlyInt";
            this.radioButtonMonthlyInt.Size = new System.Drawing.Size(62, 17);
            this.radioButtonMonthlyInt.TabIndex = 49;
            this.radioButtonMonthlyInt.TabStop = true;
            this.radioButtonMonthlyInt.Text = "Monthly";
            this.radioButtonMonthlyInt.UseVisualStyleBackColor = true;
            this.radioButtonMonthlyInt.CheckedChanged += new System.EventHandler(this.radioButtonMonthlyInt_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(456, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Total: ";
            // 
            // TotalPlusInterest
            // 
            this.TotalPlusInterest.AutoSize = true;
            this.TotalPlusInterest.Location = new System.Drawing.Point(499, 58);
            this.TotalPlusInterest.Name = "TotalPlusInterest";
            this.TotalPlusInterest.Size = new System.Drawing.Size(13, 13);
            this.TotalPlusInterest.TabIndex = 60;
            this.TotalPlusInterest.Text = "$";
            // 
            // BillEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPayOffTotal);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxAccount);
            this.Controls.Add(this.buttonInsertNewBill);
            this.Controls.Add(this.comboBoxBillType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerFromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.checkBoxSunday);
            this.Controls.Add(this.checkBoxSaturday);
            this.Controls.Add(this.checkBoxFriday);
            this.Controls.Add(this.checkBoxThursday);
            this.Controls.Add(this.checkBoxWednesday);
            this.Controls.Add(this.checkBoxTuesday);
            this.Controls.Add(this.checkBoxMonday);
            this.Controls.Add(this.radioButtonYearly);
            this.Controls.Add(this.radioButtonMonthly);
            this.Controls.Add(this.radioButtonWeekly);
            this.Controls.Add(this.radioButtonDaily);
            this.Controls.Add(this.listViewExistingBills);
            this.MaximumSize = new System.Drawing.Size(617, 800);
            this.MinimumSize = new System.Drawing.Size(617, 550);
            this.Name = "BillEditor";
            this.Text = "BillEditor";
            this.Load += new System.EventHandler(this.BillEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewExistingBills;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.CheckBox checkBoxSunday;
        private System.Windows.Forms.CheckBox checkBoxSaturday;
        private System.Windows.Forms.CheckBox checkBoxFriday;
        private System.Windows.Forms.CheckBox checkBoxThursday;
        private System.Windows.Forms.CheckBox checkBoxWednesday;
        private System.Windows.Forms.CheckBox checkBoxTuesday;
        private System.Windows.Forms.CheckBox checkBoxMonday;
        private System.Windows.Forms.RadioButton radioButtonYearly;
        private System.Windows.Forms.RadioButton radioButtonMonthly;
        private System.Windows.Forms.RadioButton radioButtonWeekly;
        private System.Windows.Forms.RadioButton radioButtonDaily;
        private System.Windows.Forms.DateTimePicker dateTimePickerFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxBillType;
        private System.Windows.Forms.Button buttonInsertNewBill;
        private System.Windows.Forms.ComboBox comboBoxAccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.TextBox textBoxPayOffTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonNewDescription;
        private System.Windows.Forms.RadioButton radioButtonUseExistingDescription;
        private System.Windows.Forms.TextBox textBoxPercent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonDailyInt;
        private System.Windows.Forms.RadioButton radioButtonMonthlyInt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelNextIntPercAmt;
        private System.Windows.Forms.Label labellabelNextPrincPayAmt;
        private System.Windows.Forms.Label labelTotalIntPaid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label TotalPlusInterest;
        private System.Windows.Forms.Label label13;
    }
}