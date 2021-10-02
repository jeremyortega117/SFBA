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
        internal void PrepareListViewHeaders(ListView lvo, List<string> headerList)
        {
            lvo.GridLines = true;
            lvo.AllowColumnReorder = true;
            lvo.LabelEdit = true;
            lvo.FullRowSelect = true;
            lvo.Sorting = SortOrder.Ascending;
            lvo.View = View.Details;
            lvo.Columns.AddRange(PrepareAsColHeaders(headerList).ToArray());
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
