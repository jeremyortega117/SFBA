using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepoTransactions
    {

        internal static List<string> transactionHeaders = new List<string> { "Date", "Bank", "Acct", "Amount", "Type", "Sign", "Description" };
        internal static Dictionary<int, List<string>> TransactionsByTransKey;
        internal static double totalSpent = 0;
        internal static double totalIncome = 0;

        internal static Chart chart;

        public ListViewRepoTransactions(ListView lvo)
        {
            lvo.Columns.Clear();
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lvo, transactionHeaders);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public ListViewRepoTransactions(ListView lvo, Chart Chart)
        {
            chart = Chart;
            lvo.Columns.Clear();
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lvo, transactionHeaders);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        internal void AddDataToListView(ListView lview)
        {
            TransactionsByTransKey = new Dictionary<int, List<string>>();
            totalSpent = totalIncome = 0;
            lview.Items.Clear();
            var trans = RepoTransaction.Trans;
            foreach (int key in trans.Keys)
            {

                List<string> transaction = new List<string>();

                transaction.Add(trans[key].TransDate.ToString("MM/dd/yyyy"));
                var bank = RepoBankAccount.Accounts[trans[key].AcctKey];
                transaction.Add(bank.BankName);
                transaction.Add(bank.AcctLastFour.ToString());
                transaction.Add(string.Format("{0:C}", trans[key].Amount));
                var transType = RepoTransaction.TransTypes[trans[key].TransTypeKey];
                transaction.Add(transType.TransDesc);
                transaction.Add(transType.TransSign.ToString());
                transaction.Add(trans[key].TransDesc);
                ListViewItem lvi = new ListViewItem(transaction.ToArray());
                if (transType.TransSign == '-')
                {
                    TransactionsByTransKey.Add(trans[key].TransKey, transaction);
                    totalSpent += trans[key].Amount;
                    lvi.BackColor = Color.FromArgb(200, 100, 100);
                }
                else if (transType.TransSign == '+')
                {
                    totalIncome += trans[key].Amount;
                    lvi.BackColor = Color.FromArgb(100, 200, 100);
                }
                lview.Items.Add(lvi);
            }

            BuildPieChart();

            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        internal void AddDataToListView(ListView lview, DateTime fromDate, DateTime toDate)
        {
            TransactionsByTransKey = new Dictionary<int, List<string>>();
            totalSpent = totalIncome = 0;
            lview.Items.Clear();
            var trans = RepoTransaction.Trans;

            foreach (int key in trans.Keys)
            {
                DateTime toCheck = trans[key].TransDate;

                if (toCheck > fromDate && toCheck < toDate)
                {
                    List<string> transaction = new List<string>();

                    transaction.Add(toCheck.ToString("MM/dd/yyyy"));
                    var bank = RepoBankAccount.Accounts[trans[key].AcctKey];
                    transaction.Add(bank.BankName);
                    transaction.Add(bank.AcctLastFour.ToString());
                    transaction.Add(string.Format("{0:C}", trans[key].Amount));
                    var transType = RepoTransaction.TransTypes[trans[key].TransTypeKey];
                    transaction.Add(transType.TransDesc);
                    transaction.Add(transType.TransSign.ToString());
                    transaction.Add(trans[key].TransDesc);
                    ListViewItem lvi = new ListViewItem(transaction.ToArray());
                    if (transType.TransSign == '-')
                    {
                        TransactionsByTransKey.Add(trans[key].TransKey, transaction);
                        totalSpent += trans[key].Amount;
                        lvi.BackColor = Color.FromArgb(200, 100, 100);
                    }
                    else if(transType.TransSign == '+')
                    {
                        totalIncome += trans[key].Amount;
                        lvi.BackColor = Color.FromArgb(100, 200, 100);
                    }
                    lview.Items.Add(lvi);
                }
            }

            BuildPieChart();

            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void BuildPieChart()
        {
            Dictionary<string, double> nameAndVal = new Dictionary<string, double>();

            List<string> names = new List<string>();

            foreach (int transKey in TransactionsByTransKey.Keys)
            {
                string name = TransactionsByTransKey[transKey][4].ToString();
                double value = Convert.ToDouble(TransactionsByTransKey[transKey][3].Replace("(", "").Replace(")", "").Replace("$", ""));

                if (!nameAndVal.ContainsKey(name))
                {
                    nameAndVal.Add(name, value);
                }
                else
                {
                    nameAndVal[name] += value;
                }
            }

            foreach (var trans in nameAndVal)
            {
                names.Add(trans.Key + " " + string.Format("{0:C}", trans.Value));
            }

            chart.Series[0].ChartType = SeriesChartType.Pie;
            chart.Series[0].Points.DataBindXY(names, nameAndVal.Values);
            chart.Legends[0].Enabled = true;
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;

        }
    }
}
