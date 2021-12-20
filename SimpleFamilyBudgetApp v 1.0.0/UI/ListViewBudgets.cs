using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewBudgets
    {
        public ListViewBudgets(ListView lview, List<string> budgetHeaderList)
        {
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lview, budgetHeaderList);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        internal static List<string> BudgetHeaderList = new List<string>()
        {
            "Expense Type",
            "Amount",
            "Budget Amount",
            "Trans Sign"
        };

        internal void AddDataToListView(ListView lview)
        {
            lview.Items.Clear();
            var Budget = RepoBudget.BudgetTotalsByID;
            //foreach (string key in RepoBudget.BudgetTotalsByID.Keys)
            foreach (string key in RepoTransaction.MapTransNew)
            {
                List<string> budgetHeaders = new List<string>();
                if (Budget.ContainsKey(key))
                {
                    if (Budget[key].posNeg != "-")
                    {
                        continue;
                    }
                    budgetHeaders.Add(Budget[key].TransDesc);
                    budgetHeaders.Add(Budget[key].Amount.ToString());

                    double budgetAmount;
                    if (RepoBudget.BudgetByString.ContainsKey(Budget[key].TransDesc))
                        budgetAmount = RepoBudget.BudgetByString[Budget[key].TransDesc];
                    else
                        budgetAmount = 0;

                    budgetHeaders.Add(budgetAmount.ToString());
                    budgetHeaders.Add(Budget[key].posNeg);
                }
                else
                {
                    budgetHeaders.Add(key);
                    budgetHeaders.Add("-");
                    budgetHeaders.Add("-");
                    budgetHeaders.Add("-");
                }


                ListViewItem lvi = new ListViewItem(budgetHeaders.ToArray());
                lview.Items.Add(lvi);
            }
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

    }
}
