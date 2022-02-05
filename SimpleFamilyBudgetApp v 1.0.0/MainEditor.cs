using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        //ListViewRepoTransactions lvr2;
        ListViewRepoBills lvBill;
        ListViewBudgets lvBudget;
        Dictionary<int, string> Users;
        List<string> Accounts;
        List<string> ExpenseTypes;
        List<string> Bills;
        ListViewColumnSorter lvcs;

        internal static DateTime BillFrom;
        internal static DateTime BillTo;

        public MainEditor()
        {
            InitializeComponent();
            checkedListBoxUsers.CheckOnClick = true;
            checkedListBox1.CheckOnClick = true;
            checkedListBox2.CheckOnClick = true;
            lvcs = new ListViewColumnSorter();
            PrepareAllData();
        }

        internal void listView1_ColumnSort(object sender, ColumnClickEventArgs e)
        {
            
        }

        private void PrepareAllData()
        {
            RepoUserEditor.PrepareUserEditorData();
            RepoBankAccount.PrepareAccountTypes();
            RepoBankAccount.PrepareAcctEditorData();
            RepoTransaction.PrepareTransTypes();
            RepoTransaction.PrepareTransMap();
            RepoFrequency.PrepareFrequencyData();
            RepoBills.PrepareBillEditorData();
            BillFrom = dateTimePickerFrom.Value = GetFirstOfMonth();
            BillTo = dateTimePickerTo.Value = GetEndOfMonth();
            DisplayAllUsersCheckTypes();
            DisplayAllExpenseCheckTypes();
            DisplayAllBillCheckTypes();
            DisplayAllAccounts();
            radioExpenses.Checked = true;
            PrepareToolOptions();
            refreshAfterFilter();
        }



        private void PrepareLabels()
        {
            double total = 0;
            Dictionary<int, string> keyAndName = new Dictionary<int, string>();
            foreach (string account in Accounts)
            {
                int AcctKey = RepoTransaction.GetAcctKeyFromSelected(account);
                int userKey = RepoBankAccount.Accounts[AcctKey].UserKey;
                total += RepoBankAccount.Accounts[AcctKey].Balance;
                if (!keyAndName.ContainsKey(userKey))
                {
                    string fName = RepoUserEditor.users[userKey].FirstName;
                    keyAndName.Add(userKey, fName);
                }
            }
            labelNamesOnAccts.Text = string.Join(", ", keyAndName.Values);
            labelTotalSaved.Text = total.ToString("C", CultureInfo.CurrentCulture);
            Text = "SimpleFamilyBudgetApp_v_1._0._0 - " + labelNamesOnAccts.Text;

            total = 0;
            DateTime dateNow = DateTime.Now;
            foreach(int transKeys in RepoTransaction.Trans.Keys)
            {
                ModelTrans trans = RepoTransaction.Trans[transKeys];
                DateTime dateFrom = new DateTime(dateNow.Year, dateNow.AddMonths(-1).Month, 1);
                DateTime dateTo = new DateTime(dateNow.Year, dateNow.Month, 1);
                if (trans.TransDate >= dateFrom && trans.TransDate < dateTo) 
                {
                    if (trans.Amount > 0)
                    {
                        total += trans.Amount;
                    }
                }
            }
            labelMonthlyNet.Text = total.ToString("C", CultureInfo.CurrentCulture);
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
            ToolStripMenuItemCreateBudget.Enabled = true;
        }

        private void DisableAllTools()
        {
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
                if(!Users.ContainsKey(userKey))
                    Users.Add(userKey, name);
            }
            if (usersChanged)
            {
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
                string check = checkedIndex.ToString();
                if (RepoTransaction.MapTransNew.Contains(check))
                {
                    foreach (var trans in RepoTransaction.MapTransTypes) 
                    {
                        if (!ExpenseTypes.Contains(trans.Key) && trans.Value == check)
                        {
                            ExpenseTypes.Add(trans.Key);
                        }
                    }
                }
                else if (!RepoTransaction.MapTransTypes.ContainsKey(check))
                {
                    if (!ExpenseTypes.Contains(check))
                    {
                        ExpenseTypes.Add(check);
                    }
                }
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
            if (radioExpenses.Checked)
            {
                lvr1 = new ListViewRepoTransactions(listView1, chart1);
                lvr1.AddDataToListView(listView1, dateTimePickerFrom.Value, dateTimePickerTo.Value);
                listView1.ListViewItemSorter = lvcs;
            }
            else if (radioBills.Checked)
            {
                lvBill = new ListViewRepoBills(listView1, ListViewRepoBills.BillCycleHeaderList, chart1);
                lvBill.AddDataToCycleListView(listView1, BillFrom, BillTo);
                listView1.ListViewItemSorter = lvcs;
            }
            else if (radioBudgets.Checked)
            {
                lvBudget = new ListViewBudgets(listView1, ListViewBudgets.BudgetHeaderList);
                TimeSpan tspan = new TimeSpan();
                tspan = dateTimePickerTo.Value - dateTimePickerFrom.Value;
                lvBudget.AddDataToListView(listView1,tspan.Days, labelTotalSpent, labelTotalSaved);
                
            }
            //else if (radioBudgets.Checked)
            //{
            //    lvr2 = new ListViewRepoTransactions(listView1);
            //    lvr2.AddDataToListView(listView1);
            //}
        }





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
            PrepareAllData();
        }

        private void form_close(object sender, FormClosingEventArgs e)
        {
            RepoDBClass.DB.Close();
        }

        private void bankAcctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.ShowDialog();
            PrepareAllData();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransactionEditor transEditor = new TransactionEditor();
            transEditor.ShowDialog();
            PrepareAllData();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DisplayAllUsersCheckTypes()
        {
            checkedListBoxUsers.Items.Clear();
            foreach (var user in RepoUserEditor.users.Values)
            {
                string userCombonation = $"{user.LastName}, {user.FirstName} {user.MiddleInitial} : {user.userName}.";
                checkedListBoxUsers.Items.Add(userCombonation, CheckState.Checked);
            }
        }

        private void DisplayAllBillCheckTypes()
        {
            checkedListBoxBills.Items.Clear();
            Bills = new List<string>();
            foreach (string names in RepoBills.BillDescriptions)
            {
                checkedListBoxBills.Items.Add(names, CheckState.Checked);
                Bills.Add(names);
            }
        }

        private void DisplayAllExpenseCheckTypes()
        {
            checkedListBox1.Items.Clear();
            List<string> alreadyadded = new List<string>();
            if (RepoTransaction.MapTransTypes.Count > 0)
            {
                foreach (var types in RepoTransaction.MapTransTypes)
                {
                    if (!alreadyadded.Contains(types.Value) && RepoTransaction.MapTransTypesByIncluded.Contains(types.Value))
                    {
                        alreadyadded.Add(types.Value);
                    }
                }
            }
            else
            {
                foreach (var types in RepoTransaction.TransTypes.Values)
                {
                    if (!alreadyadded.Contains(types.TransDesc) && RepoTransaction.MapTransTypesByIncluded.Contains(types.TransDesc))
                    {
                        alreadyadded.Add(types.TransDesc);
                    }
                }
            }
            foreach (string type in RepoTransaction.IncludedNewMapVal)
            {
                if (!alreadyadded.Contains(type))
                {
                    alreadyadded.Add(type);
                }
            }
            alreadyadded.Sort();
            foreach (string expenseCheck in alreadyadded)
            {
                checkedListBox1.Items.Add(expenseCheck, CheckState.Checked);
            }
        }

        private void DisplayAllAccounts(Dictionary<int, string> users)
        {
            checkedListBox2.Items.Clear();
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
            checkedListBox2.Items.Clear();
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
            refreshAfterFilter();
        }

        private void refreshAfterFilter()
        {
            BillFrom = dateTimePickerFrom.Value;
            BillTo = dateTimePickerTo.Value;

            if (radioExpenses.Checked)
            {
                FillAccountsAndExpenseTypesChecked(); // Fills objects with filtered data
                RepoTransaction.PrepareTransDataWithFilters(Accounts, ExpenseTypes);
            }
            else if (radioBills.Checked)
            {
                FillBillsTypesChecked();
                RepoBills.PrepareBillEditorDataWithFilters(Bills);
            }
            else if (radioBudgets.Checked)
            {
                RepoBudget.PrepareBudgetData(dateTimePickerFrom.Value, dateTimePickerTo.Value);
            }

            PrepareLabels();
            PrepareListViews();
            if (radioExpenses.Checked) 
            {
                labelTotalIncome.Text = string.Format("{0:C}", ListViewRepoTransactions.totalIncome);
                labelTotalSpent.Text = string.Format("{0:C}", ListViewRepoTransactions.totalSpent);
                labelTotalBal.Text = string.Format("{0:C}", ListViewRepoTransactions.totalIncome + ListViewRepoTransactions.totalSpent);
            }
            else if (radioBills.Checked)
            {
                decimal income = ListViewRepoBills.paycheckCount * Convert.ToDecimal(labelMonthlyNet.Text.Replace("$", "")) / 2;
                decimal spent = ListViewRepoBills.Total;
                decimal bal = income - spent;

                labelTotalIncome.Text = string.Format("{0:C}", income);
                labelTotalSpent.Text = string.Format("{0:C}", spent);
                labelTotalBal.Text = string.Format("{0:C}", bal);
            }
            else if (radioBudgets.Checked)
            {
                
            }


        }

        private void FillBillsTypesChecked()
        {
            Bills = new List<string>();

            foreach (var checkedIndex in checkedListBoxBills.CheckedItems)
            {
                string name = checkedIndex.ToString();
                if (!Bills.Contains(name))
                    Bills.Add(name);
            }
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

        private void buttonBackOneMonth_Click(object sender, EventArgs e)
        {
            dateTimePickerTo.Value = dateTimePickerTo.Value.AddMonths(-1);
            dateTimePickerTo.Value = new DateTime(dateTimePickerTo.Value.Year, dateTimePickerTo.Value.Month, DateTime.DaysInMonth(dateTimePickerTo.Value.Year, dateTimePickerTo.Value.Month));
            dateTimePickerFrom.Value = dateTimePickerFrom.Value.AddMonths(-1);
            refreshAfterFilter();
        }

        private void buttonBackOneYear_Click(object sender, EventArgs e)
        {
            dateTimePickerTo.Value = dateTimePickerTo.Value.AddYears(-1);
            dateTimePickerTo.Value = new DateTime(dateTimePickerTo.Value.Year, dateTimePickerTo.Value.Month, DateTime.DaysInMonth(dateTimePickerTo.Value.Year, dateTimePickerTo.Value.Month));
            dateTimePickerFrom.Value = dateTimePickerFrom.Value.AddYears(-1);
            refreshAfterFilter();
        }

        private void buttonForwardOneMonth_Click(object sender, EventArgs e)
        {
            dateTimePickerTo.Value = dateTimePickerTo.Value.AddMonths(1);
            dateTimePickerTo.Value = new DateTime(dateTimePickerTo.Value.Year, dateTimePickerTo.Value.Month, DateTime.DaysInMonth(dateTimePickerTo.Value.Year, dateTimePickerTo.Value.Month));
            dateTimePickerFrom.Value = dateTimePickerFrom.Value.AddMonths(1);
            refreshAfterFilter();
        }

        private void ForwardOneYear_Click(object sender, EventArgs e)
        {
            dateTimePickerTo.Value = dateTimePickerTo.Value.AddYears(1);
            dateTimePickerFrom.Value = dateTimePickerFrom.Value.AddYears(1);
            dateTimePickerTo.Value = new DateTime(dateTimePickerTo.Value.Year, dateTimePickerTo.Value.Month, DateTime.DaysInMonth(dateTimePickerTo.Value.Year, dateTimePickerTo.Value.Month));
            refreshAfterFilter();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void radioExpenses_CheckedChanged(object sender, EventArgs e)
        {
            refreshAfterFilter();

        }

        private void radioBudgets_CheckedChanged(object sender, EventArgs e)
        {
            refreshAfterFilter();
        }

        private void radioBills_CheckedChanged(object sender, EventArgs e)
        {
            refreshAfterFilter();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemCreateBudget_Click(object sender, EventArgs e)
        {
            BudgetEditor budget = new BudgetEditor();
            budget.ShowDialog();
        }

        private void mapExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseMap map = new ExpenseMap();
            map.ShowDialog();
            PrepareAllData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonNoBillTypes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxBills.Items.Count; i++)
            {
                checkedListBoxBills.SetItemChecked(i, false);
            }
        }

        private void buttonAllBillTypes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxBills.Items.Count; i++)
            {
                checkedListBoxBills.SetItemChecked(i, true);
            }
        }

        private void checkedListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBoxBills_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void investInterestCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvestmentInterestCalculator calc = new InvestmentInterestCalculator();
            calc.ShowDialog();

        }
    }
}
