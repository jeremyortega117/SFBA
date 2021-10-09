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
        ListViewRepoUserEditor lvue;
        internal static string selectedUser = "";

        public User_Editor()
        {
            InitializeComponent();
            RefreshData();
            
        }

        private void RefreshData()
        {
            listViewUserEditor.Clear();
            lvue = new ListViewRepoUserEditor(listViewUserEditor);
            RepoUserEditor.PrepareUserEditorData();
            lvue.AddDataToListView(listViewUserEditor);
            ResetUI();
        }



        /// <summary>
        /// Add User Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<ModelUserEditor> users = new List<ModelUserEditor>();
            ModelUserEditor user = prepareUserData();
            user.UserKey = 0;
            users.Add(user);
            RepoUserEditor.EditUser(users, 'A');
            RefreshData();
        }

        private ModelUserEditor prepareUserData()
        {
            ModelUserEditor user = new ModelUserEditor();
            user.userName = textBoxUsername.Text;
            user.FirstName = textBoxFirstName.Text;
            user.LastName = textBoxLastName.Text;
            user.MiddleInitial = Convert.ToChar(textBoxMI.Text);
            user.UserPass = textBoxUserPass.Text.Trim();
            return user;
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

        /// <summary>
        /// Grab Data on Selected User and populate form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewUserEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUserEditor.SelectedItems != null && listViewUserEditor.SelectedItems.Count>0)
            {
                ListViewItem items = listViewUserEditor.SelectedItems[0];
                List<string> itemNames = new List<string>();
                for (int i = 1; i < 5; i++)
                {
                    itemNames.Add(items.SubItems[i].Text);
                }
                string[] fieldArr = itemNames.ToArray();
                textBoxFirstName.Text = fieldArr[1];
                textBoxLastName.Text = fieldArr[3];
                textBoxMI.Text = fieldArr[2];
                textBoxUsername.Text = fieldArr[0];
                button2.Enabled = true;
                button3.Enabled = true;
                ModelUserEditor user = prepareUserData();
                selectedUser = $"{user.LastName}, {user.FirstName} {user.MiddleInitial} : {user.userName}.";
            }
            else
            {
                ResetUI();
            }
        }

        /// <summary>
        /// Update Selected User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            List<ModelUserEditor> users = new List<ModelUserEditor>();
            ModelUserEditor user = prepareUserData();
            user.UserKey = RepoUserEditor.RetrieveUserKeyFromName(selectedUser);
            users.Add(user);
            if(user.UserPass == "")
            {
                user.UserPass = RepoUserEditor.users[RepoUserEditor.RetrieveUserKeyFromName(selectedUser)].UserPass;
            }
            RepoUserEditor.EditUser(users, 'U');
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<ModelUserEditor> users = new List<ModelUserEditor>();
            ModelUserEditor user = prepareUserData();
            user.UserKey = RepoUserEditor.RetrieveUserKeyFromName(selectedUser);
            users.Add(user);
            RepoUserEditor.EditUser(users, 'D');
            RefreshData();
        }
    }
}
