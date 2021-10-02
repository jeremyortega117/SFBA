using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepo
    {
        internal ListViewModel listViewData;
        internal ListView listViewObject = new ListView();
        internal static List<string> transactionHeaders = new List<string> { "Date", "Bank", "Acct", "Amount", "Type", "Description" };

        public ListViewRepo(ListView lvo)
        {
            //lvo.GridLines = true;
            //lvo.AllowColumnReorder = true;
            //lvo.LabelEdit = true;
            //lvo.FullRowSelect = true;
            //lvo.Sorting = SortOrder.Ascending;
            //lvo.View = View.Details;
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