using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public partial class MainEditor : Form
    {
        internal static bool sideBarVisible = true;
        internal static bool rightSideBarVisible = true;

        ListViewRepoTransactions lvr1;
        ListViewRepoTransactions lvr2;
        ListViewRepoBills lvBill;
        Dictionary<int, string> Users;
        List<string> Accounts;
        List<string> ExpenseTypes;

        internal static DateTime BillFrom;
        internal static DateTime BillTo;

        public MainEditor()
        {
            InitializeComponent();
            leftBarButtonHide();
            //RightBarHide();
            RepoUserEditor.PrepareUserEditorData();
            RepoBankAccount.PrepareAccountTypes();
            RepoBankAccount.PrepareAcctEditorData();
            RepoTransaction.PrepareTransTypes();
            RepoFrequency.PrepareFrequencyData();
            RepoBills.PrepareBillEditorData();
            BillFrom = dateTimePickerFrom.Value = GetFirstOfMonth();
            BillTo = dateTimePickerTo.Value = GetEndOfMonth();
            DisplayAllUsersCheckTypes();
            DisplayAllExpenseCheckTypes();
            DisplayAllAccounts();
            FillAccountsAndExpenseTypesChecked();
            RepoTransaction.PrepareTransDataWithFilters(Accounts, ExpenseTypes);
            PrepareListViews();
            PrepareToolOptions();
            PrepareWebViews();
        }


        private void PrepareWebViews()
        {
            //string curDir = Directory.GetCurrentDirectory();
            //webBrowser1.Url = new Uri(String.Format("{0}/WEB_BROWSER/PieChart.html", curDir));
            //webBrowser2.Url = new Uri(String.Format("{0}/WEB_BROWSER/PieChart.html", curDir));
        }

        private DateTime GetFirstOfMonth()
        {
            DateTime date = DateTime.Now;
            return new DateTime(date.Year, date.Month, 1);
        }


        private DateTime GetEndOfMonth()
        {
            DateTime date = DateTime.Now;
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            //int daysInMonth;
            //int month = DateTime.Now.Month;
            //int year = DateTime.Now.Year;
            //DateTime tempdate = DateTime.Now;
            //if (tempdate.Day > 9)
            //{
            //    if (month == 12)
            //    {
            //        year++;
            //        month = 1;
            //    }
            //    else
            //    {
            //        month++;
            //    }
            //    daysInMonth = DateTime.DaysInMonth(year, month);
            //}
            //else
            //{
            //    daysInMonth = DateTime.DaysInMonth(year, month);
            //}
            //return new DateTime(year, month, daysInMonth);
        }


        private void PrepareToolOptions()
        {
            DisableAllTools();

            // If a user exists you can make an account.
            if (RepoUserEditor.users.Count == 0)
            {
                return;
            }
            ToolStripMenuItembankAcct.Enabled = true;

            // If a user and account exist you can make a bill.
            if (RepoBankAccount.Accounts.Count == 0)
            {
                return;
            }
            ToolStripMenuItembillType.Enabled = true;

            // If a user, an account exist you can start adding transactions.
            ToolStripMenuItemtransaction.Enabled = true;
            toolStripMenuItemImportFile.Enabled = true;
            ToolStripMenuItemCreateBudget.Enabled = true;
        }

        private void DisableAllTools()
        {
            toolStripMenuItemImportFile.Enabled = false;
            ToolStripMenuItembankAcct.Enabled = false;
            ToolStripMenuItemCreateBudget.Enabled = false;
            ToolStripMenuItembillType.Enabled = false;
            ToolStripMenuItemtransaction.Enabled = false;
        }

        private void FillAccountsAndExpenseTypesChecked()
        {
            bool usersChanged = false;
            if (Users != null && CheckIfUsersHaveChanged())
            {
                usersChanged = true;
            }
            Users = new Dictionary<int, string>();
            Accounts = new List<string>();
            ExpenseTypes = new List<string>();
            foreach (var checkedIndex in checkedListBoxUsers.CheckedItems)
            {
                string name = checkedIndex.ToString();
                int userKey = RepoUserEditor.RetrieveUserKeyFromName(name);
                Users.Add(userKey, name);
            }
            if (usersChanged) {
                checkedListBox2.Items.Clear();
                DisplayAllAccounts(Users);
            }
            foreach (var checkedIndex in checkedListBox2.CheckedItems)
            {
                if (usersChanged)
                {
                    string accountType = checkedIndex.ToString();
                    int accKey = RepoTransaction.GetAcctKeyFromSelected(accountType);
                    if (Users.Keys.Contains(RepoBankAccount.Accounts[accKey].UserKey))
                        Accounts.Add(accountType);
                }
                else
                {
                    Accounts.Add(checkedIndex.ToString());
                }
            }
            foreach (var checkedIndex in checkedListBox1.CheckedItems)
            {
                ExpenseTypes.Add(checkedIndex.ToString());
            }
        }

        private bool CheckIfUsersHaveChanged()
        {
            if (checkedListBoxUsers.CheckedItems.Count != Users.Keys.Count)
            {
                return true;
            }
            foreach (var checkedIndex in checkedListBoxUsers.CheckedItems)
            {
                string name = checkedIndex.ToString();
                int userKey = RepoUserEditor.RetrieveUserKeyFromName(name);
                if (!Users.ContainsKey(userKey))
                {
                    return true;
                }
            }
            return false;
        }

        private void PrepareListViews()
        {
            //listViewSecondaryTwo.Clear();
            //listViewBill.Clear();

            //lvr1 = new ListViewRepoTransactions(listViewMainOne);
            //lvr2 = new ListViewRepoTransactions(listViewSecondaryOne);
            //lvBill = new ListViewRepoBills(listViewBill, ListViewRepoBills.BillCycleHeaderList);

            //lvr1.AddDataToListView(listViewMainOne);
            //lvr2.AddDataToListView(listViewSecondaryOne);
            //lvBill.AddDataToCycleListView(listViewBill, BillFrom, BillTo);
        }



        #region Side Bar Button
        private void buttonLeftFilterHide_Click(object sender, EventArgs e)
        {
            leftBarButtonHide();
        }

        /// <summary>
        /// Show/Hide customizable filters.
        /// </summary>
        private void leftBarButtonHide()
        {
            //if (sideBarVisible)
            //{
            //    panelLeftFilterBar.Width = 0;
            //    sideBarVisible = false;
            //    buttonLeftFilterHide.Text = ">";
            //}
            //else
            //{
            //    panelLeftFilterBar.Width = 211;
            //    sideBarVisible = true;
            //    buttonLeftFilterHide.Text = "<";
            //}
        }
        #endregion

        //private void RightBarHide()
        //{
        //    if (rightSideBarVisible)
        //    {
        //        rightSideBarVisible = false;
        //        buttonRightCompare.Text = "<";
        //        int newWidth = 100;
        //        if (sideBarVisible)
        //        {
        //            newWidth += 230;
        //        }
        //        splitContainer1.SplitterDistance = this.Width-newWidth;
        //        panelMainOne.Width *= 2;
        //    }
        //    else
        //    {
        //        rightSideBarVisible = true;
        //        buttonRightCompare.Text = ">";
        //        splitContainer1.SplitterDistance = this.Width/2;
        //        panelMainOne.Width /= 2;
        //    }
        //}

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Open User Editor Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Editor editor = new User_Editor();
            editor.ShowDialog();
            PrepareListViews();
            PrepareToolOptions();
        }

        private void form_close(object sender, FormClosingEventArgs e)
        {
            RepoDBClass.DB.Close();
        }

        private void bankAcctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.ShowDialog();
            PrepareListViews();
            PrepareToolOptions();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransactionEditor transEditor = new TransactionEditor();
            transEditor.ShowDialog();
            PrepareListViews();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DisplayAllUsersCheckTypes()
        {
            foreach (var user in RepoUserEditor.users.Values)
            {
                string userCombonation = $"{user.LastName}, {user.FirstName} {user.MiddleInitial} : {user.userName}.";
                checkedListBoxUsers.Items.Add(userCombonation, CheckState.Checked);
            }
        }

        private void DisplayAllExpenseCheckTypes()
        {
            foreach(var types in RepoTransaction.TransTypes.Values)
            {
                checkedListBox1.Items.Add(types.TransDesc, CheckState.Checked);
            }
        }

        private void DisplayAllAccounts(Dictionary<int, string> users)
        {
            foreach (var acct in RepoBankAccount.Accounts.Values)
            {
                string acctType = RepoBankAccount.AccountTypes[acct.AcctTypeKey].AcctType;
                string acctInfo = $"{acct.BankName}, {acct.AcctLastFour}, {acctType}";
                if (users.ContainsKey(acct.UserKey))
                {
                    checkedListBox2.Items.Add(acctInfo, CheckState.Checked);
                }
                else
                {
                    checkedListBox2.Items.Add(acctInfo, CheckState.Unchecked);
                }
            }
        }

        private void DisplayAllAccounts()
        {
            foreach (var acct in RepoBankAccount.Accounts.Values)
            {
                string acctType = RepoBankAccount.AccountTypes[acct.AcctTypeKey].AcctType;
                string acctInfo = $"{acct.BankName}, {acct.AcctLastFour}, {acctType}";
                checkedListBox2.Items.Add(acctInfo, CheckState.Checked);
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Make Adjustment To Filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FillAccountsAndExpenseTypesChecked();
            RepoTransaction.PrepareTransDataWithFilters(Accounts, ExpenseTypes);
            PrepareListViews();
        }

        private void buttonAllExpenses_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void buttonUncheckAllExpenses_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void buttonCheckAllAccounts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, true);
            }
        }

        private void buttonUncheckAllBoxes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxUsers.Items.Count; i++)
            {
                checkedListBoxUsers.SetItemChecked(i, false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxUsers.Items.Count; i++)
            {
                checkedListBoxUsers.SetItemChecked(i, true);
            }
        }

        private void billTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillEditor Bill = new BillEditor();
            Bill.ShowDialog();
            PrepareListViews();
            PrepareToolOptions();
        }

        private void createNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.ShowDialog();
            PrepareListViews();
            PrepareToolOptions();
        }

        private void moveDeleteAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeOrDeleteAccount changeAccountForm = new ChangeOrDeleteAccount();
            changeAccountForm.ShowDialog();
            PrepareListViews();
            PrepareToolOptions(); 
        }

        private void dateTimePickerBillFromDate_ValueChanged(object sender, EventArgs e)
        {
            //BillFrom = dateTimePickerBillFromDate.Value;
        }

        private void dateTimePickerBillToDate_ValueChanged(object sender, EventArgs e)
        {
            //BillTo = dateTimePickerBillToDate.Value;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PrepareListViews();
        }

        private void excelxlsxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listViewBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void buttonRightCompare_Click(object sender, EventArgs e)
        {
            //RightBarHide();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemImportFile_Click(object sender, EventArgs e)
        {
            //ImportFile file = new ImportFile();
            //file.ShowDialog();
            //PrepareListViews();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panelLeftFilterBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

    }
}
