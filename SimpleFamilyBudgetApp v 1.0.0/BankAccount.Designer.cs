
namespace SimpleFamilyBudgetApp_v_1._0._0
{
    partial class BankAccount
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
            this.comboBoxAccountType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddAccountType = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAcctLastFour = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBalance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxInterestFreq = new System.Windows.Forms.ComboBox();
            this.textBoxInterestRate = new System.Windows.Forms.TextBox();
            this.buttonSubmitNewAccount = new System.Windows.Forms.Button();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxBankName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(845, 217);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // comboBoxAccountType
            // 
            this.comboBoxAccountType.FormattingEnabled = true;
            this.comboBoxAccountType.Location = new System.Drawing.Point(292, 273);
            this.comboBoxAccountType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxAccountType.MaxLength = 30;
            this.comboBoxAccountType.Name = "comboBoxAccountType";
            this.comboBoxAccountType.Size = new System.Drawing.Size(252, 24);
            this.comboBoxAccountType.TabIndex = 1;
            this.comboBoxAccountType.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccountType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 278);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bank Name:";
            // 
            // buttonAddAccountType
            // 
            this.buttonAddAccountType.Location = new System.Drawing.Point(553, 272);
            this.buttonAddAccountType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddAccountType.Name = "buttonAddAccountType";
            this.buttonAddAccountType.Size = new System.Drawing.Size(100, 28);
            this.buttonAddAccountType.TabIndex = 6;
            this.buttonAddAccountType.Text = "Add Type";
            this.buttonAddAccountType.UseVisualStyleBackColor = true;
            this.buttonAddAccountType.Click += new System.EventHandler(this.buttonAddAccountType_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Acct Last Four:";
            // 
            // textBoxAcctLastFour
            // 
            this.textBoxAcctLastFour.Location = new System.Drawing.Point(292, 306);
            this.textBoxAcctLastFour.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAcctLastFour.MaxLength = 4;
            this.textBoxAcctLastFour.Name = "textBoxAcctLastFour";
            this.textBoxAcctLastFour.Size = new System.Drawing.Size(85, 22);
            this.textBoxAcctLastFour.TabIndex = 8;
            this.textBoxAcctLastFour.TextChanged += new System.EventHandler(this.textBoxAcctLastFour_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 345);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Balance:";
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.Location = new System.Drawing.Point(292, 340);
            this.textBoxBalance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBalance.MaxLength = 20;
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new System.Drawing.Size(252, 22);
            this.textBoxBalance.TabIndex = 10;
            this.textBoxBalance.TextChanged += new System.EventHandler(this.textBoxBalance_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 412);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Interest Frequency:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 446);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Interest Rate:";
            // 
            // comboBoxInterestFreq
            // 
            this.comboBoxInterestFreq.FormattingEnabled = true;
            this.comboBoxInterestFreq.Location = new System.Drawing.Point(292, 407);
            this.comboBoxInterestFreq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxInterestFreq.Name = "comboBoxInterestFreq";
            this.comboBoxInterestFreq.Size = new System.Drawing.Size(252, 24);
            this.comboBoxInterestFreq.TabIndex = 13;
            // 
            // textBoxInterestRate
            // 
            this.textBoxInterestRate.Location = new System.Drawing.Point(292, 441);
            this.textBoxInterestRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxInterestRate.MaxLength = 30;
            this.textBoxInterestRate.Name = "textBoxInterestRate";
            this.textBoxInterestRate.Size = new System.Drawing.Size(85, 22);
            this.textBoxInterestRate.TabIndex = 14;
            // 
            // buttonSubmitNewAccount
            // 
            this.buttonSubmitNewAccount.Location = new System.Drawing.Point(292, 479);
            this.buttonSubmitNewAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSubmitNewAccount.Name = "buttonSubmitNewAccount";
            this.buttonSubmitNewAccount.Size = new System.Drawing.Size(253, 44);
            this.buttonSubmitNewAccount.TabIndex = 15;
            this.buttonSubmitNewAccount.Text = "Add New Account";
            this.buttonSubmitNewAccount.UseVisualStyleBackColor = true;
            this.buttonSubmitNewAccount.Click += new System.EventHandler(this.buttonSubmitNewAccount_Click);
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(292, 374);
            this.comboBoxUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(252, 24);
            this.comboBoxUser.TabIndex = 17;
            this.comboBoxUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxUser_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 378);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "User: ";
            // 
            // comboBoxBankName
            // 
            this.comboBoxBankName.FormattingEnabled = true;
            this.comboBoxBankName.Location = new System.Drawing.Point(292, 244);
            this.comboBoxBankName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxBankName.MaxLength = 30;
            this.comboBoxBankName.Name = "comboBoxBankName";
            this.comboBoxBankName.Size = new System.Drawing.Size(252, 24);
            this.comboBoxBankName.TabIndex = 18;
            this.comboBoxBankName.SelectedIndexChanged += new System.EventHandler(this.comboBoxBankName_SelectedIndexChanged);
            // 
            // BankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 554);
            this.Controls.Add(this.comboBoxBankName);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonSubmitNewAccount);
            this.Controls.Add(this.textBoxInterestRate);
            this.Controls.Add(this.comboBoxInterestFreq);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAcctLastFour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAddAccountType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAccountType);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BankAccount";
            this.Text = "Bank Account Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBoxAccountType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddAccountType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAcctLastFour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxInterestFreq;
        private System.Windows.Forms.TextBox textBoxInterestRate;
        private System.Windows.Forms.Button buttonSubmitNewAccount;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxBankName;
    }
}