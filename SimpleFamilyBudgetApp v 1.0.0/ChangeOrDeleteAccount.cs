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
        //internal static List<string> Accounts;
        public ChangeOrDeleteAccount()
        {
            InitializeComponent();
            FillUserComboBoxWithAvaiulableUsers(comboBox1);
            FillUserComboBoxWithAvaiulableUsers(comboBox2);
            ResetUI();
        }

        private void ResetUI()
        {
            comboBox1.Text = "";
            comboBox1.Enabled = false;
            comboBox2.Text = "";
            checkedListBox1.Enabled = false;
            checkedListBox1.Items.Clear();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void FillUserComboBoxWithAvaiulableUsers(ComboBox comboB)
        {
            foreach (var user in RepoUserEditor.users.Values)
            {
                string userval = $"{user.LastName}, {user.FirstName} {user.MiddleInitial} : {user.userName}.";
                comboB.Items.Add(userval);
            }
        }

        private void FillCheckBoxWithAccounts(int userKey)
        {
            checkedListBox1.Items.Clear();
            foreach (var account in RepoBankAccount.Accounts.Values)
            {
                if (account.UserKey == userKey)
                {
                    var acctType = RepoBankAccount.AccountTypes[account.AcctTypeKey];
                    checkedListBox1.Items.Add($"{account.BankName}, {account.AcctLastFour}, {acctType.AcctType}", CheckState.Checked);
                }
            }
        }

        /// <summary>
        /// Select User to move accounts to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
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
            ResetUI();
        }

        /// <summary>
        /// Delete selected Accounts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

            int userKey = RepoUserEditor.RetrieveUserKeyFromName(comboBox2.Text);
            foreach (int accountKey in RepoBankAccount.Accounts.Keys)
            {
                if (RepoBankAccount.Accounts[accountKey].UserKey == userKey)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all records associated with this Bank Account?", "Delete All Account Records?", MessageBoxButtons.YesNo);
                    if(dialogResult == DialogResult.Yes)
                    {
                        RepoTransaction.RemoveAllTransactionsAssociatedWithUserKey(accountKey);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            List<ModelBankAccount> BankAccounts = new List<ModelBankAccount>();
            foreach (var checkedIndex in checkedListBox1.CheckedItems)
            {
                ModelBankAccount account = RepoBankAccount.Accounts[RepoTransaction.GetAcctKeyFromSelected(checkedIndex.ToString())];
                BankAccounts.Add(account);
            }
            RepoBankAccount.EditAccts(BankAccounts, 'D');
            ResetUI();
        }


        /// <summary>
        /// Make All Selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Make All Unselected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }



        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Select User whose accounts will be managed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCheckBoxWithAccounts(RepoUserEditor.users[RepoUserEditor.RetrieveUserKeyFromName(comboBox2.Text)].UserKey);
            comboBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            checkedListBox1.Enabled = true;
        }
    }
}
