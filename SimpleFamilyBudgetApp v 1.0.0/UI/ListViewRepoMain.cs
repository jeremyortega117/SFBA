using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepoMain
    {

        internal static List<string> transactionHeaders = new List<string> { "Date", "Bank", "Acct", "Amount", "Type", "Description" };

        public ListViewRepoMain(ListView lvo)
        {
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lvo, transactionHeaders);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}