using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepo
    {
        internal List<ListViewModel> listViewData;
        internal ListView listViewObject = new ListView();
        internal static List<string> transactionHeaders = new List<string> { "Date", "Bank", "Acct", "Amount", "Type", "Description" };

        public ListViewRepo(ListView lvo)
        {
            lvo.GridLines = true;
            lvo.AllowColumnReorder = true;
            lvo.LabelEdit = true;
            lvo.FullRowSelect = true;
            lvo.Sorting = SortOrder.Ascending;
            lvo.View = View.Details;
            CreateListViewColumnHeaders(lvo, transactionHeaders);
            listViewData = new List<ListViewModel>();
            FillListViewData(listViewData);
        }

        private void FillListViewData(List<ListViewModel> listViewData)
        {
            //throw new NotImplementedException();
        }


        #region PrepareColumn Headers for transaction History
        /// <summary>
        /// Prepare Column Headers
        /// </summary>
        /// <param name="lvo"></param>
        private void CreateListViewColumnHeaders(ListView lvo, List<string> headerList)
        {
            lvo.Columns.AddRange(PrepareAsColHeaders(headerList).ToArray());
        }

        private List<ColumnHeader> PrepareAsColHeaders(List<string> headerList)
        {
            List<ColumnHeader> temp = new List<ColumnHeader>();
            foreach (string header in headerList) {
                ColumnHeader colHead = new ColumnHeader();
                colHead.Text = header;
                temp.Add(colHead);
            }
            return temp;
        }
        #endregion
    }
}