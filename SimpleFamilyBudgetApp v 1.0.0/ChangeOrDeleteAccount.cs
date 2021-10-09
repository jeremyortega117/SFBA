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
    public partial class ChangeOrDeleteAccount : Form
    {
        internal static List<string> Accounts;
        public ChangeOrDeleteAccount()
        {
            InitializeComponent();
            FillCheckBoxWithAccounts();
            FillUserComboBoxWithAvaiulableUsers();
        }

        private void FillUserComboBoxWithAvaiulableUsers()
        {
            foreach (var user in RepoUserEditor.users.Values)
            {
                string userval = $"{user.LastName}, {user.FirstName} {user.MiddleInitial} : {user.userName}.";
                comboBox1.Items.Add(userval);
            }
        }

        private void FillCheckBoxWithAccounts()
        {
            foreach (var account in RepoBankAccount.Accounts.Values)
            {
                var acctType = RepoBankAccount.AccountTypes[account.AcctTypeKey];
                checkedListBox1.Items.Add($"{account.BankName}, {account.AcctLastFour}, {acctType.AcctType}", CheckState.Checked);
            }
        }

        /// <summary>
        /// Select User to move accounts to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Move Account to another user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            List<ModelBankAccount> BankAccounts = new List<ModelBankAccount>();
            foreach (var checkedIndex in checkedListBox1.CheckedItems)
            {
                ModelBankAccount account = RepoBankAccount.Accounts[RepoTransaction.GetAcctKeyFromSelected(checkedIndex.ToString())];
                account.UserKey = RepoUserEditor.RetrieveUserKeyFromName(comboBox1.Text);
                BankAccounts.Add(account);
            }
            RepoBankAccount.EditAccts(BankAccounts, 'U');
            FillCheckBoxWithAccounts();
            FillUserComboBoxWithAvaiulableUsers();
        }

        /// <summary>
        /// Delete selected Accounts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            List<ModelBankAccount> BankAccounts = new List<ModelBankAccount>();
            foreach (var checkedIndex in checkedListBox1.CheckedItems)
            {
                ModelBankAccount account = RepoBankAccount.Accounts[RepoTransaction.GetAcctKeyFromSelected(checkedIndex.ToString())];
                BankAccounts.Add(account);
            }
            RepoBankAccount.EditAccts(BankAccounts, 'D');
            FillCheckBoxWithAccounts();
            FillUserComboBoxWithAvaiulableUsers();
        }


        /// <summary>
        /// Make All Selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Make All Unselected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
