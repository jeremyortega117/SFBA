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
    public partial class Form1 : Form
    {
        internal static bool sideBarVisible = true;

        ListViewRepoTransactions lvr1;
        ListViewRepoTransactions lvr2;
        ListViewRepoBills lvBill;
        List<string> Accounts;
        List<string> ExpenseTypes;

        internal static DateTime BillFrom;
        internal static DateTime BillTo;

        public Form1()
        {
            InitializeComponent();
            leftBarButtonHide();
            RepoUserEditor.PrepareUserEditorData();
            RepoBankAccount.PrepareAccountTypes();
            RepoBankAccount.PrepareAcctEditorData();
            RepoTransaction.PrepareTransTypes();
            RepoFrequency.PrepareFrequencyData();
            RepoBills.PrepareBillEditorData();
            BillFrom = dateTimePickerBillFromDate.Value = GetFirstOfMonth();
            BillTo = dateTimePickerBillToDate.Value = GetEndOfMonth();
            DisplayAllExpenseCheckTypes();
            DisplayAllAccounts();
            FillAccountsAndExpenseTypesChecked();
            RepoTransaction.PrepareTransDataWithFilters(Accounts, ExpenseTypes);
            PrepareListViews();
            PrepareToolOptions(); 
        }

        private DateTime GetFirstOfMonth()
        {
            DateTime date = DateTime.Now;
            return new DateTime(date.Year, date.Month, 1);
        }


        private DateTime GetEndOfMonth()
        {
            int daysInMonth;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            DateTime tempdate = DateTime.Now;
            if (tempdate.Day > 9)
            {
                if (month == 12)
                {
                    year++;
                    month = 1;
                }
                else
                {
                    month++;
                }
                daysInMonth = DateTime.DaysInMonth(year, month);
            }
            else
            {
                daysInMonth = DateTime.DaysInMonth(year, month);
            }
            return new DateTime(year, month, daysInMonth);
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
            Accounts = new List<string>();
            ExpenseTypes = new List<string>();
            foreach(var checkedIndex in checkedListBox1.CheckedItems)
            {
                ExpenseTypes.Add(checkedIndex.ToString());
            }
            foreach (var checkedIndex in checkedListBox2.CheckedItems)
            {
                Accounts.Add(checkedIndex.ToString());
            }
        }

        private void PrepareListViews()
        {
            listViewOne.Clear();
            listViewTwo.Clear();
            listViewBill.Clear();

            lvr1 = new ListViewRepoTransactions(listViewOne);
            lvr2 = new ListViewRepoTransactions(listViewTwo);
            lvBill = new ListViewRepoBills(listViewBill, ListViewRepoBills.BillCycleHeaderList);

            lvr1.AddDataToListView(listViewOne);
            lvr2.AddDataToListView(listViewTwo);
            lvBill.AddDataToCycleListView(listViewBill, BillFrom, BillTo);
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
            if (sideBarVisible)
            {
                panelLeftFilterBar.Width = 0;
                sideBarVisible = false;
                buttonLeftFilterHide.Text = ">";
            }
            else
            {
                panelLeftFilterBar.Width = 211;
                sideBarVisible = true;
                buttonLeftFilterHide.Text = "<";
            }
        }
        #endregion

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

        private void DisplayAllExpenseCheckTypes()
        {
            foreach(var types in RepoTransaction.TransTypes.Values)
            {
                checkedListBox1.Items.Add(types.TransDesc, CheckState.Checked);
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
            BillFrom = dateTimePickerBillFromDate.Value;
        }

        private void dateTimePickerBillToDate_ValueChanged(object sender, EventArgs e)
        {
            BillTo = dateTimePickerBillToDate.Value;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PrepareListViews();
        }
    }
}
