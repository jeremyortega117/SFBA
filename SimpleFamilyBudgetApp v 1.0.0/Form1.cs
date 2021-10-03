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
    public partial class Form1 : Form
    {
        internal static bool sideBarVisible = true;
        

        public Form1()
        {
            InitializeComponent();
            leftBarButtonHide();
            PrepareListViews();
        }


        private void PrepareListViews()
        {
            ListViewRepoMain lvr1 = new ListViewRepoMain(listViewOne);
            ListViewRepoMain lvr2 = new ListViewRepoMain(listViewTwo);
        }



        #region Side Bar Button
        private void buttonLeftFilterHide_Click(object sender, EventArgs e)
        {
            leftBarButtonHide();
        }

        /// <summary>
        /// Show/Hide customizable filters.
        /// </summary>
        private void leftBarButtonHide()
        {
            if (sideBarVisible)
            {
                panelLeftFilterBar.Width = 0;
                sideBarVisible = false;
                buttonLeftFilterHide.Text = ">";
            }
            else
            {
                panelLeftFilterBar.Width = 343;
                sideBarVisible = true;
                buttonLeftFilterHide.Text = "<";
            }
        }
        #endregion

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Open User Editor Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Editor editor = new User_Editor();
            editor.ShowDialog();
        }

        private void form_close(object sender, FormClosingEventArgs e)
        {
            DBClass.DB.Close();
        }

        private void bankAcctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.ShowDialog();
        }
    }
}
