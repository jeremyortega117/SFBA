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
            UserEditorRepo.PrepareUserEditorData();
            BankAccountRepo.PrepareAccountTypes();
            BankAccountRepo.PrepareAcctEditorData();
            PrepareComboBoxes();
            ClearData();
            ListViewRepoBankAccount lvrba = new ListViewRepoBankAccount(listView1);
            lvrba.AddDataToListView(listView1);
        }


        private void ClearData()
        {
            textBoxBankName.Text = "";
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
            foreach (UserEditorModel user in UserEditorRepo.users.Values) {
                comboBoxUser.Items.Add($"{user.LastName}, {user.FirstName} {user.MiddleInitial} : {user.userName}.");
            }
            comboBoxAccountType.Items.Clear();
            foreach (AccountType AccountType in BankAccountRepo.AccountTypes.Values)
            {
                comboBoxAccountType.Items.Add($"{AccountType.AcctType}");
            }
        }

        private void buttonAddBankName_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddAccountType_Click(object sender, EventArgs e)
        {
            if(comboBoxAccountType.Text != "")
            {
                List<AccountType> AccountTypes = new List<AccountType>();
                AccountType accountType = new AccountType();
                accountType.AcctType = comboBoxAccountType.Text;
                AccountTypes.Add(accountType);
                BankAccountRepo.PrepareAccountTypes();
                PrepareComboBoxes();
            }
        }

        private void buttonSubmitNewAccount_Click(object sender, EventArgs e)
        {
            if (textBoxBankName.Text != ""
                && comboBoxAccountType.Text != ""
                && textBoxAcctLastFour.Text != ""
                && comboBoxUser.Text != ""
                && textBoxBalance.Text != ""
                && comboBoxUser.Text != "")
            {
                List<BankAccountModel> BankAccounts = new List<BankAccountModel>();
                BankAccountModel BankAccount = new BankAccountModel();
                BankAccount.BankName = textBoxBankName.Text;
                BankAccount.AcctTypeKey = BankAccountRepo.RetrieveAcctTypeKeyFromName(comboBoxAccountType.Text);
                BankAccount.AcctLastFour = Convert.ToInt32(textBoxAcctLastFour.Text);
                BankAccount.Balance = Convert.ToDouble(textBoxBalance.Text);
                BankAccount.UserKey = Convert.ToInt32(UserEditorRepo.RetrieveUserKeyFromName(comboBoxUser.Text));
                BankAccount.InterestFreq = Convert.ToInt32(comboBoxInterestFreq.Text);
                BankAccount.InterestPercent = Convert.ToDouble(textBoxInterestRate.Text);
                BankAccounts.Add(BankAccount);
                BankAccountRepo.EditAccts(BankAccounts, 'A');
                RefreshData();
            }
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
