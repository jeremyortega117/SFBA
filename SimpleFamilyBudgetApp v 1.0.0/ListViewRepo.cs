using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepo
    {

        internal static List<string> transactionHeaders = new List<string> { "Date", "Bank", "Acct", "Amount", "Type", "Description" };

        public ListViewRepo(ListView lvo)
        {
            CreateListViewColumnHeaders(lvo, transactionHeaders);
        }


        /// <summary>
        /// Prepare Column Headers
        /// </summary>
        /// <param name="lvo"></param>
        private void CreateListViewColumnHeaders(ListView lvo, List<string> headerList)
        {
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lvo, headerList);
        }
    }
}