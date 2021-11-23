using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public partial class BankAccount : Form
    {

        public BankAccount()
        {
            InitializeComponent();
            RefreshData();
           
        }

        private void RefreshData()
        {
            RepoUserEditor.PrepareUserEditorData();
            RepoBankAccount.PrepareAccountTypes();
            RepoBankAccount.PrepareAcctEditorData();
            PrepareComboBoxes();
            ClearData();
            ListViewRepoBankAccount lvrba = new ListViewRepoBankAccount(listView1);
            lvrba.AddDataToListView(listView1);
        }


        private void ClearData()
        {
            comboBoxBankName.Text = "";
            comboBoxAccountType.Text = "";
            textBoxAcctLastFour.Text = "";
            textBoxBalance.Text = "";
            comboBoxUser.Text = "";
            comboBoxInterestFreq.Text = "0";
            textBoxInterestRate.Text = "0";
        }

        private void PrepareComboBoxes()
        {
            comboBoxUser.Items.Clear();
            foreach (ModelUserEditor user in RepoUserEditor.users.Values) {
                comboBoxUser.Items.Add($"{user.LastName}, {user.FirstName} {user.MiddleInitial} : {user.userName}.");
            }
            comboBoxAccountType.Items.Clear();
            foreach (ModelAccountType AccountType in RepoBankAccount.AccountTypes.Values)
            {
                comboBoxAccountType.Items.Add($"{AccountType.AcctType}");
            }
            comboBoxBankName.Items.Clear();
            HashSet<string> BankNames = new HashSet<string>();
            foreach (ModelBankAccount Accounts in RepoBankAccount.Accounts.Values)
            {
                string BankName = Accounts.BankName;
                if (!BankNames.Contains(BankName))
                {
                    comboBoxBankName.Items.Add($"{BankName}");
                    BankNames.Add(BankName);
                }
            }
        }

        private void buttonAddBankName_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddAccountType_Click(object sender, EventArgs e)
        {
            if(comboBoxAccountType.Text.Trim() != "")
            {
                List<ModelAccountType> AccountTypes = new List<ModelAccountType>();
                ModelAccountType accountType = new ModelAccountType();
                accountType.AcctType = comboBoxAccountType.Text;
                AccountTypes.Add(accountType);
                RepoBankAccount.EditAccountType(AccountTypes, 'A');
                RepoBankAccount.PrepareAccountTypes();
                PrepareComboBoxes();
            }
        }

        private void buttonSubmitNewAccount_Click(object sender, EventArgs e)
        {
            if (comboBoxBankName.Text != ""
                && comboBoxAccountType.Text != ""
                && textBoxAcctLastFour.Text != ""
                && comboBoxUser.Text != ""
                && textBoxBalance.Text != ""
                && comboBoxUser.Text != "")
            {
                listView1.Clear();
                List<ModelBankAccount> BankAccounts = new List<ModelBankAccount>();
                ModelBankAccount BankAccount = new ModelBankAccount();
                BankAccount.BankName = comboBoxBankName.Text;
                BankAccount.AcctTypeKey = RepoBankAccount.RetrieveAcctTypeKeyFromName(comboBoxAccountType.Text);
                BankAccount.AcctLastFour = textBoxAcctLastFour.Text;
                BankAccount.Balance = Convert.ToDouble(textBoxBalance.Text);
                BankAccount.UserKey = Convert.ToInt32(RepoUserEditor.RetrieveUserKeyFromName(comboBoxUser.Text));
                BankAccount.InterestFreq = Convert.ToInt32(comboBoxInterestFreq.Text);
                BankAccount.InterestPercent = Convert.ToDouble(textBoxInterestRate.Text);
                BankAccounts.Add(BankAccount);
                RepoBankAccount.EditAccts(BankAccounts, 'A');
                RefreshData();
            }
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxBankName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddBankName_Click_1(object sender, EventArgs e)
        {

        }
    }
}
