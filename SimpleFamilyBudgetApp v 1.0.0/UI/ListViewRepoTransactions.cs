using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepoTransactions
    {

        internal static List<string> transactionHeaders = new List<string> { "Date", "Bank", "Acct", "Amount", "Type", "Sign", "Description" };
        internal static Dictionary<int, List<string>> TransactionsByTransKey;

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

            lview.Items.Clear();
            var trans = RepoTransaction.Trans;
            foreach (int key in trans.Keys)
            {

                List<string> transaction = new List<string>();

                transaction.Add(trans[key].TransDate.ToString());
                var bank = RepoBankAccount.Accounts[trans[key].AcctKey];
                transaction.Add(bank.BankName);
                transaction.Add(bank.AcctLastFour.ToString());
                transaction.Add(string.Format("{0:C}", trans[key].Amount));
                var transType = RepoTransaction.TransTypes[trans[key].TransTypeKey];
                transaction.Add(transType.TransDesc);
                transaction.Add(transType.TransSign.ToString());
                transaction.Add(trans[key].TransDesc);
                if (transType.TransSign == '-')
                {
                    TransactionsByTransKey.Add(trans[key].TransKey, transaction);
                }
                ListViewItem lvi = new ListViewItem(transaction.ToArray());
                lview.Items.Add(lvi);
            }

            BuildPieChart();

            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        internal void AddDataToListView(ListView lview, DateTime fromDate, DateTime toDate)
        {
            TransactionsByTransKey = new Dictionary<int, List<string>>();

            lview.Items.Clear();
            var trans = RepoTransaction.Trans;

            foreach (int key in trans.Keys)
            {
                DateTime toCheck = trans[key].TransDate;

                if (toCheck > fromDate && toCheck < toDate)
                {
                    List<string> transaction = new List<string>();

                    transaction.Add(toCheck.ToString());
                    var bank = RepoBankAccount.Accounts[trans[key].AcctKey];
                    transaction.Add(bank.BankName);
                    transaction.Add(bank.AcctLastFour.ToString());
                    transaction.Add(string.Format("{0:C}", trans[key].Amount));
                    var transType = RepoTransaction.TransTypes[trans[key].TransTypeKey];
                    transaction.Add(transType.TransDesc);
                    transaction.Add(transType.TransSign.ToString());
                    transaction.Add(trans[key].TransDesc);
                    if (transType.TransSign == '-')
                    {
                        TransactionsByTransKey.Add(trans[key].TransKey, transaction);
                    }
                    ListViewItem lvi = new ListViewItem(transaction.ToArray());
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

            //List<string> names = new List<string>();
            //List<double> values = new List<double>();

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
                //names.Add(TransactionsByTransKey[transKey][4].ToString());
                //values.Add(Convert.ToDouble(TransactionsByTransKey[transKey][3].Replace("(", "").Replace(")", "").Replace("$", "")));
            }

            chart.Series[0].ChartType = SeriesChartType.Pie;
            chart.Series[0].Points.DataBindXY(nameAndVal.Keys, nameAndVal.Values);
            chart.Legends[0].Enabled = true;
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;

        }
    }
}
