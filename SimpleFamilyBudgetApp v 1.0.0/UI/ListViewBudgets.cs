using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            "Amount Remaining",
        };

        internal void AddDataToListView(ListView lview, int days, Label labelBudgeted, Label labelSpent)
        {
            lview.Items.Clear();

            List<string> temp = new List<string>();
            temp = RepoBudget.BudgetTotalsByNewVal.Keys.ToList();
            temp.Sort();

            double totalSpent = 0;
            double totalBudgeted = 0;

            foreach (string str in temp)
            {
                List<string> budgetHeaders = new List<string>();
                double perc;

                double mod = (double)days / 30;
                double amt = Math.Abs(RepoBudget.BudgetTotalsByNewVal[str] * mod);
                budgetHeaders.Add(str);
                budgetHeaders.Add(amt.ToString("0.00"));
                totalSpent += amt;

                double budgetAmount;
                if (RepoBudget.BudgetByString.ContainsKey(str))
                    budgetAmount = Math.Abs(RepoBudget.BudgetByString[str] * mod);
                else
                    budgetAmount = 0;
                totalBudgeted += budgetAmount;
                budgetHeaders.Add(budgetAmount.ToString("0.00"));
                budgetHeaders.Add(Math.Abs((Math.Abs(amt) - Math.Abs(budgetAmount))).ToString("0.00"));

                perc = amt / budgetAmount;

                ListViewItem lvi = new ListViewItem(budgetHeaders.ToArray());
                Color col = Color.White;
                if (perc > 0.0001)
                {
                    if (perc <= 0.60)
                    {
                        col = ColorTranslator.FromHtml($"#34B643");
                    }
                    if (perc > 0.60)
                    {
                        col = ColorTranslator.FromHtml($"#34B643");
                    }
                    if (perc > 0.75)
                    {
                        col = ColorTranslator.FromHtml($"#D3D33A");
                    }
                    if (perc > 0.90)
                    {
                        col = ColorTranslator.FromHtml($"#E67E1C");
                    }
                    if (perc > 1)
                    {
                        col = ColorTranslator.FromHtml($"#E6341C");
                    }
                }
                lvi.BackColor = col;
                lview.Items.Add(lvi);
            }
            labelBudgeted.Text = totalBudgeted.ToString("$0.00");
            labelSpent.Text = totalSpent.ToString("$0.00");
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

    }
}
