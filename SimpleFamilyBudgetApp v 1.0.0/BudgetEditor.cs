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

            RefreshData();
        }

        private void RefreshData()
        {
            RepoBudget.PrepareBudgetData(dateTimePicker1.Value, dateTimePicker2.Value);
            RepoBudget.PrepareBudgetPlan();
            PrepareMappings();
            PrepareListViews();
        }

        private void PrepareListViews()
        {
            listViewBudgetViewWindow.Clear();
            lvue = new ListViewBudgets(listViewBudgetViewWindow, ListViewBudgets.BudgetHeaderList);
            TimeSpan ts = dateTimePicker2.Value - dateTimePicker1.Value;
            lvue.AddDataToListView(listViewBudgetViewWindow, ts.Days);
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
            foreach (string strTransType in RepoTransaction.MapTransNewPositive)
            {
                dataGridViewBudgets.Rows.Add();
                dataGridViewBudgets.Rows[row].Cells[0].Value = strTransType;
                dataGridViewBudgets.Rows[row].Cells[1].Value = RepoBudget.BudgetByString.ContainsKey(strTransType) ? RepoBudget.BudgetByString[strTransType] : 0;
                row++;
            }

            cbCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ModelBudget> budgetsToAdd = new List<ModelBudget>();
            List<ModelBudget> budgetsToUpdate = new List<ModelBudget>();
            for (int index = 0; index < dataGridViewBudgets.RowCount-1; index++)
            {
                string type = dataGridViewBudgets.Rows[index].Cells[0].Value.ToString();
                double value = Convert.ToDouble(dataGridViewBudgets.Rows[index].Cells[1].Value);

                ModelBudget budget = new ModelBudget();
                budget.TRANS_DESC = type;
                budget.BudgetAmount = value;

                if (RepoBudget.BudgetByString.ContainsKey(type))
                {
                    double storedAmt = RepoBudget.BudgetByString[type];
                    if (value != storedAmt) {
                        int Key = 0;
                        foreach (int key in RepoBudget.BudgetByID.Keys)
                        {
                            if (RepoBudget.BudgetByID[key].TRANS_DESC == type)
                            {
                                budget.ID = RepoBudget.BudgetByID[key].ID;
                                Key = key;
                                break;
                            }
                        }
                        budget.AcctKey = RepoBudget.BudgetByID[Key].AcctKey;
                        budgetsToUpdate.Add(budget);
                    }
                }
                else {
                    budget.AcctKey = 0;
                    budget.ID = 0;
                    budgetsToAdd.Add(budget);
                }
            }
            RepoBudget.EditBudgetMap(budgetsToAdd, 'A');
            RepoBudget.EditBudgetMap(budgetsToUpdate, 'U');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-1);
            dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1);

            dateTimePicker2.Value = dateTimePicker2.Value.AddMonths(-1);
            dateTimePicker2.Value = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, DateTime.DaysInMonth(dateTimePicker2.Value.Year,dateTimePicker2.Value.Month));
            RefreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(1);
            dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1);

            dateTimePicker2.Value = dateTimePicker2.Value.AddMonths(1);
            dateTimePicker2.Value = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, DateTime.DaysInMonth(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month));
            RefreshData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddYears(-1);
            dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1);

            dateTimePicker2.Value = dateTimePicker2.Value.AddYears(-1);
            dateTimePicker2.Value = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, DateTime.DaysInMonth(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month));
            RefreshData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddYears(1);
            dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1);

            dateTimePicker2.Value = dateTimePicker2.Value.AddYears(1);
            dateTimePicker2.Value = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, DateTime.DaysInMonth(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month));
            RefreshData();
        }

        private void dataGridViewBudgets_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
