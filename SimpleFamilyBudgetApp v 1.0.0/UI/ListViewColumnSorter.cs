using System.Collections;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;

        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;

        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor. Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface. It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            //x = x.ToString().Replace("$", "").Replace(",", "").Replace("(", "").Replace(")", "");
            //x = (ListViewItem)x;
            //y = y.ToString().Replace("$", "").Replace(",", "").Replace("(", "").Replace(")", "");
            //y = (object)y;

            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            bool DBLX = false;
            bool DBLY = false;
            //bool negX = listviewX.SubItems[ColumnToSort].Text.Contains("(") ? true : false;
            //bool negY = listviewY.SubItems[ColumnToSort].Text.Contains("(") ? true : false;
            bool negX = listviewX.SubItems[6].Text.Contains("-") ? true : false;
            bool negY = listviewY.SubItems[6].Text.Contains("-") ? true : false;
            
            string str1 = listviewX.SubItems[ColumnToSort].Text.ToString().Replace("$", "").Replace(",", "").Replace("(", "").Replace(")", "");
            string str2 = listviewY.SubItems[ColumnToSort].Text.ToString().Replace("$", "").Replace(",", "").Replace("(", "").Replace(")", "");
            double dx,dy;
            if (double.TryParse(str1,out dx) && double.TryParse(str2, out dy))
            {
                if (negX)
                {
                    dx *= -1;
                }
                if (negY)
                {
                    dy *= -1;
                }

                compareResult = ObjectCompare.Compare(dx, dy);

                DBLX = true;
                DBLY = true;

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
            }

            //if (DBLX && DBLY)
            //{
            //    compareResult = ObjectCompare.Compare(dx, dy);
            //}
            if(!DBLX || !DBLY)
            {
                // Compare the two items
                compareResult = ObjectCompare.Compare(str1, str2);

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
            }


            //// Compare the two items
            //compareResult = ObjectCompare.Compare(str1, str2);
            //compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            //// Calculate correct return value based on object comparison
            //if (OrderOfSort == SortOrder.Ascending)
            //{
            //    // Ascending sort is selected, return normal result of compare operation
            //    return compareResult;
            //}
            //else if (OrderOfSort == SortOrder.Descending)
            //{
            //    // Descending sort is selected, return negative result of compare operation
            //    return (-compareResult);
            //}
            //else
            //{
                // Return '0' to indicate they are equal
                return 0;
            //}
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}