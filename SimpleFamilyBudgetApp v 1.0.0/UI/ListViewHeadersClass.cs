using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewHeadersClass
    {
        internal ListView lview;// = new ListView();
        internal void PrepareListViewHeaders(ListView lvo, List<string> headerList)
        {
            lview = new ListView();
            lvo.View = View.Details;
            lvo.FullRowSelect = false;
            lvo.Columns.Clear();
            lvo.Items.Clear();
            lvo.GridLines = true;
            lvo.AllowColumnReorder = true;
            lvo.LabelEdit = false;
            lvo.Sorting = SortOrder.Ascending;
            lvo.Columns.AddRange(PrepareAsColHeaders(headerList).ToArray());
            lvo.ColumnClick += new ColumnClickEventHandler(listView1_ColumnSort);
            lview = lvo;
        }

        private void listView1_ColumnSort(object sender, ColumnClickEventArgs e)
        {
            ListView lvi = (ListView)sender;
            ListViewColumnSorter lv = (ListViewColumnSorter)lvi.ListViewItemSorter;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lv.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lv.Order == SortOrder.Ascending)
                {
                    lv.Order = SortOrder.Descending;
                }
                else
                {
                    lv.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lv.SortColumn = e.Column;
                lv.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lview.Sort();
        }

        internal List<ColumnHeader> PrepareAsColHeaders(List<string> headerList)
        {
            List<ColumnHeader> temp = new List<ColumnHeader>();
            foreach (string header in headerList)
            {
                ColumnHeader colHead = new ColumnHeader();
                colHead.Text = header;
                
                temp.Add(colHead);
            }
            return temp;
        }
    }
}
