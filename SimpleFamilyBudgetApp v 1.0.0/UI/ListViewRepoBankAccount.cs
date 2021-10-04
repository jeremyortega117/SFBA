using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepoBankAccount
    {
        internal static List<string> AcctHeaderList = new List<string>() { "Username", "Bank Name", "Acct Last Four", "Account Type", "Amount", "Interest Frequency", "Interest Amount" };

        public ListViewRepoBankAccount(ListView lview)
        {
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lview, AcctHeaderList);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        internal void AddDataToListView(ListView lview)
        {
            var Accounts = BankAccountRepo.Accounts;
            lview.Items.Clear();
            foreach (int key in Accounts.Keys)
            {
                List<string> userHeaders = new List<string>();
                var user = UserEditorRepo.users[Accounts[key].UserKey];
                userHeaders.Add($"{user.userName} : {user.LastName}, {user.FirstName} {user.MiddleInitial}");
                userHeaders.Add(Accounts[key].BankName);
                userHeaders.Add(Accounts[key].AcctLastFour.ToString());
                var acctType = BankAccountRepo.AccountTypes[Accounts[key].AcctTypeKey];
                userHeaders.Add(acctType.AcctType);
                userHeaders.Add(string.Format("{0:C}",Accounts[key].Balance));
                userHeaders.Add(Accounts[key].InterestFreq.ToString());
                userHeaders.Add(Accounts[key].InterestPercent.ToString());
                ListViewItem lvi = new ListViewItem(userHeaders.ToArray());
                lview.Items.Add(lvi);
            }
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
