using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public partial class User_Editor : Form
    {
        internal static List<string> UserHeaderList = new List<string>() { "User Id", "User Name", "First Name", "MI","Last Name" };

        public User_Editor()
        {
            InitializeComponent();
            PrepareListView();
            UserEditorRepo.PrepareUserEditorData();
            AddDataToListView(UserEditorRepo.users);
            ResetUI();
        }

        private void AddDataToListView(Dictionary<int, UserEditorModel> users)
        {
            listViewUserEditor.Items.Clear();
            foreach(int key in users.Keys)
            {
                List<string> userHeaders = new List<string>();
                userHeaders.Add(users[key].UserKey.ToString());
                userHeaders.Add(users[key].userName.ToString());
                userHeaders.Add(users[key].FirstName.ToString());
                userHeaders.Add(users[key].MiddleInitial.ToString());
                userHeaders.Add(users[key].LastName.ToString());
                ListViewItem lvi = new ListViewItem(userHeaders.ToArray());
                listViewUserEditor.Items.Add(lvi);
            }
        }

        private void PrepareListView()
        {
            ListViewHeadersClass prepListView = new ListViewHeadersClass();
            prepListView.PrepareListViewHeaders(listViewUserEditor, UserHeaderList);
        }



        /// <summary>
        /// Add User Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<UserEditorModel> users = new List<UserEditorModel>();
            UserEditorModel user = new UserEditorModel();
            user.userName = textBoxUsername.Text;
            user.FirstName = textBoxFirstName.Text;
            user.LastName = textBoxLastName.Text;
            user.MiddleInitial = Convert.ToChar(textBoxMI.Text);
            user.UserPass = textBoxUsername.Text;
            user.UserKey = 0;
            users.Add(user);
            UserEditorRepo.EditUser(users, 'A');
            ResetUI();
            UserEditorRepo.PrepareUserEditorData();
            AddDataToListView(UserEditorRepo.users);
        }

        private void ResetUI()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxMI.Text = "";
            textBoxUsername.Text = "";
            textBoxUserPass.Text = "";
        }

        /// <summary>
        /// First Name Text Change
        /// </summary>
        private void Text_Changed(object sender, EventArgs e)
        {
            CheckIfAllTextChanged();
        }
        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            CheckIfAllTextChanged();
        }
        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            CheckIfAllTextChanged();
        }



        private void CheckIfAllTextChanged()
        {
            if (textBoxFirstName.Text.Trim() != ""
                && textBoxFirstName.Text.Trim().Length < 30
                && textBoxLastName.Text.Trim() != ""
                && textBoxLastName.Text.Trim().Length < 30
                && textBoxUsername.Text.Trim() != ""
                && textBoxUsername.Text.Trim().Length < 30)
            {
                button1.Enabled = true;
            }
            else button1.Enabled = false;
        }
    }
}
