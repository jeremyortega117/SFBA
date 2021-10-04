using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepoTransactions
    {

        internal static List<string> transactionHeaders = new List<string> { "Date", "Bank", "Acct", "Amount", "Type", "Description" };

        public ListViewRepoTransactions(ListView lvo)
        {
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lvo, transactionHeaders);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        internal void AddDataToListView(ListView lview)
        {

            lview.Items.Clear();
            var trans = TransactionRepo.Trans;
            foreach (int key in trans.Keys)
            {
                List<string> transaction = new List<string>();
                transaction.Add(trans[key].TransDate.ToString());
                var bank = BankAccountRepo.Accounts[trans[key].AcctKey];
                transaction.Add(bank.BankName);
                transaction.Add(bank.AcctLastFour.ToString());
                transaction.Add(string.Format("{0:C}", trans[key].Amount));
                var transType = TransactionRepo.TransTypes[trans[key].TransTypeKey];
                transaction.Add(transType.TransDesc);
                transaction.Add(trans[key].TransDesc);
                ListViewItem lvi = new ListViewItem(transaction.ToArray());
                lview.Items.Add(lvi);
            }
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}