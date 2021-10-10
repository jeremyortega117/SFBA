using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepoBills
    {
        internal static List<string> BillHeaderList = new List<string>() 
        { 
            "BK", 
            "Start Date", 
            "End Date", 
            "Bill Description", 
            "Amount", 
            "Total",
            "Bill Type", 
            "Account", 
            "Frequency", 
            "Mon", 
            "Tues", 
            "Wed", 
            "Thur", 
            "Fri", 
            "Sat", 
            "Sun" 
        };

        public ListViewRepoBills(ListView lview)
        {
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lview, BillHeaderList);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        internal void AddDataToListView(ListView lview)
        {
            var Bills = RepoBills.Bills;
            lview.Items.Clear();
            foreach (int key in Bills.Keys)
            {
                List<string> billHeaders = new List<string>();

                billHeaders.Add(Bills[key].BillKey.ToString());
                billHeaders.Add(Bills[key].BillStartDate.ToString("MM/dd/yyyy"));
                billHeaders.Add(Bills[key].BillEndDate.ToString("MM/dd/yyyy"));
                billHeaders.Add(Bills[key].BillDesc.ToString());
                billHeaders.Add(Bills[key].Amount.ToString());
                billHeaders.Add(Bills[key].Total.ToString());
                billHeaders.Add(Bills[key].BillType.ToString());

                var acct = RepoBankAccount.Accounts[Bills[key].AccKey];
                var acctType = RepoBankAccount.AccountTypes[acct.AcctTypeKey];
                billHeaders.Add($"{acct.BankName}, {acct.AcctLastFour}, {acctType.AcctType}");

                billHeaders.Add(Bills[key].Frequency.FreqType.ToString());
                billHeaders.Add(Bills[key].Frequency.Monday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Tuesday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Wednesday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Thursday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Friday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Saturday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Sunday ? "X" : "");


                ListViewItem lvi = new ListViewItem(billHeaders.ToArray());
                lview.Items.Add(lvi);
            }
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
