using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepoUserEditor
    {
        internal static List<string> UserHeaderList = new List<string>() { "User Id", "User Name", "First Name", "MI", "Last Name" };

        public ListViewRepoUserEditor(ListView lvo)
        {
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lvo, UserHeaderList);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        internal void AddDataToListView(ListView lview)
        {

            lview.Items.Clear();
            var users = UserEditorRepo.users;
            foreach (int key in users.Keys)
            {
                List<string> userHeaders = new List<string>();
                userHeaders.Add(users[key].UserKey.ToString());
                userHeaders.Add(users[key].userName.ToString());
                userHeaders.Add(users[key].FirstName.ToString());
                userHeaders.Add(users[key].MiddleInitial.ToString());
                userHeaders.Add(users[key].LastName.ToString());
                ListViewItem lvi = new ListViewItem(userHeaders.ToArray());
                lview.Items.Add(lvi);
            }
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
