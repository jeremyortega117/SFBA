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
    public partial class BudgetEditor : Form
    {
        internal static ListViewColumnSorter lvcs;
        internal static ListViewBudgets lvue;

        public BudgetEditor()
        {
            InitializeComponent();
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            int year, month;
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            dateTimePicker1.Value = new DateTime(year, month, 1);
            dateTimePicker2.Value = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            //lvcs = new ListViewColumnSorter();
            //listViewBudgetViewWindow.ListViewItemSorter = lvcs;
            RepoBudget.PrepareBudgetData();
            RepoBudget.PrepareBudgetPlan();
            PrepareMappings();
            PrepareListViews();
        }

        private void PrepareListViews()
        {
            listViewBudgetViewWindow.Clear();
            lvue = new ListViewBudgets(listViewBudgetViewWindow, ListViewBudgets.BudgetHeaderList);
            lvue.AddDataToListView(listViewBudgetViewWindow);
        }

        private void PrepareMappings()
        {
            dataGridViewBudgets.Rows.Clear();
            dataGridViewBudgets.Columns.Clear();

            DataGridViewTextBoxColumn cbCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn tbCol = new DataGridViewTextBoxColumn();
            cbCol.ReadOnly = true;
            cbCol.HeaderText = "Budget Description";
            tbCol.HeaderText = "Budget Amount";
            dataGridViewBudgets.Columns.AddRange(cbCol, tbCol);

            int row = 0;
            foreach (string strTransType in RepoTransaction.MapTransTypesByIncluded)
            {
                dataGridViewBudgets.Rows.Add();
                dataGridViewBudgets.Rows[row].Cells[0].Value = strTransType;
                dataGridViewBudgets.Rows[row].Cells[1].Value = row;
                row++;
            }

            cbCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //private void AddAnotherRow(int row)
        //{
        //    dataGridViewBudgets.Rows.Add();
        //    ComboBox BudgetTypes = new ComboBox();
        //    List<string> str = RepoTransaction.MapTransNew.ToList();
        //    str.Sort();
        //    BudgetTypes.Items.AddRange(str.ToArray());
        //    DataGridViewComboBoxCell dgvcbc = new DataGridViewComboBoxCell();
        //    dataGridViewBudgets[0, row] = dgvcbc;
        //    dgvcbc.DataSource = BudgetTypes.Items;
        //}
    }
}
