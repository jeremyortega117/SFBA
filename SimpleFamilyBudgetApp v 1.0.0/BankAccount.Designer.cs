
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
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(634, 177);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // comboBoxAccountType
            // 
            this.comboBoxAccountType.FormattingEnabled = true;
            this.comboBoxAccountType.Location = new System.Drawing.Point(219, 222);
            this.comboBoxAccountType.MaxLength = 30;
            this.comboBoxAccountType.Name = "comboBoxAccountType";
            this.comboBoxAccountType.Size = new System.Drawing.Size(190, 21);
            this.comboBoxAccountType.TabIndex = 1;
            this.comboBoxAccountType.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccountType_SelectedIndexChanged);
            this.comboBoxAccountType.TextUpdate += new System.EventHandler(this.CheckIfEnableInsertButton);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bank Name:";
            // 
            // buttonAddAccountType
            // 
            this.buttonAddAccountType.Location = new System.Drawing.Point(415, 221);
            this.buttonAddAccountType.Name = "buttonAddAccountType";
            this.buttonAddAccountType.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAccountType.TabIndex = 6;
            this.buttonAddAccountType.Text = "Add Type";
            this.buttonAddAccountType.UseVisualStyleBackColor = true;
            this.buttonAddAccountType.Click += new System.EventHandler(this.buttonAddAccountType_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Acct Last Four:";
            // 
            // textBoxAcctLastFour
            // 
            this.textBoxAcctLastFour.Location = new System.Drawing.Point(219, 249);
            this.textBoxAcctLastFour.MaxLength = 4;
            this.textBoxAcctLastFour.Name = "textBoxAcctLastFour";
            this.textBoxAcctLastFour.Size = new System.Drawing.Size(65, 20);
            this.textBoxAcctLastFour.TabIndex = 8;
            this.textBoxAcctLastFour.TextChanged += new System.EventHandler(this.textBoxAcctLastFour_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Balance:";
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.Location = new System.Drawing.Point(219, 276);
            this.textBoxBalance.MaxLength = 20;
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new System.Drawing.Size(190, 20);
            this.textBoxBalance.TabIndex = 10;
            this.textBoxBalance.TextChanged += new System.EventHandler(this.textBoxBalance_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Interest Frequency:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(145, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Interest Rate:";
            // 
            // comboBoxInterestFreq
            // 
            this.comboBoxInterestFreq.FormattingEnabled = true;
            this.comboBoxInterestFreq.Location = new System.Drawing.Point(219, 331);
            this.comboBoxInterestFreq.Name = "comboBoxInterestFreq";
            this.comboBoxInterestFreq.Size = new System.Drawing.Size(190, 21);
            this.comboBoxInterestFreq.TabIndex = 13;
            this.comboBoxInterestFreq.SelectedIndexChanged += new System.EventHandler(this.comboBoxInterestFreq_SelectedIndexChanged);
            this.comboBoxInterestFreq.TextUpdate += new System.EventHandler(this.CheckIfEnableInsertButton);
            // 
            // textBoxInterestRate
            // 
            this.textBoxInterestRate.Location = new System.Drawing.Point(219, 358);
            this.textBoxInterestRate.MaxLength = 30;
            this.textBoxInterestRate.Name = "textBoxInterestRate";
            this.textBoxInterestRate.Size = new System.Drawing.Size(65, 20);
            this.textBoxInterestRate.TabIndex = 14;
            this.textBoxInterestRate.TextChanged += new System.EventHandler(this.textBoxInterestRate_TextChanged);
            // 
            // buttonSubmitNewAccount
            // 
            this.buttonSubmitNewAccount.Location = new System.Drawing.Point(219, 389);
            this.buttonSubmitNewAccount.Name = "buttonSubmitNewAccount";
            this.buttonSubmitNewAccount.Size = new System.Drawing.Size(190, 36);
            this.buttonSubmitNewAccount.TabIndex = 15;
            this.buttonSubmitNewAccount.Text = "Add New Account";
            this.buttonSubmitNewAccount.UseVisualStyleBackColor = true;
            this.buttonSubmitNewAccount.Click += new System.EventHandler(this.buttonSubmitNewAccount_Click);
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(219, 304);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(190, 21);
            this.comboBoxUser.TabIndex = 17;
            this.comboBoxUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxUser_SelectedIndexChanged);
            this.comboBoxUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userCombo_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "User: ";
            // 
            // comboBoxBankName
            // 
            this.comboBoxBankName.FormattingEnabled = true;
            this.comboBoxBankName.Location = new System.Drawing.Point(219, 198);
            this.comboBoxBankName.MaxLength = 30;
            this.comboBoxBankName.Name = "comboBoxBankName";
            this.comboBoxBankName.Size = new System.Drawing.Size(190, 21);
            this.comboBoxBankName.TabIndex = 18;
            this.comboBoxBankName.SelectedIndexChanged += new System.EventHandler(this.comboBoxBankName_SelectedIndexChanged);
            this.comboBoxBankName.TextUpdate += new System.EventHandler(this.CheckIfEnableInsertButton);
            this.comboBoxBankName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // BankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 450);
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