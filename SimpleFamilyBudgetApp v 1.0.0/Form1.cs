﻿using System;
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
            ListViewRepo lvr1 = new ListViewRepo(listViewOne);
            ListViewRepo lvr2 = new ListViewRepo(listViewTwo);
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
    }
}
