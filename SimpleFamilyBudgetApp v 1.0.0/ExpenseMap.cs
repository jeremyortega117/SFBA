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
    public partial class ExpenseMap : Form
    {
        public ExpenseMap()
        {
            InitializeComponent();
            PrepareMappingData();
            button2.Enabled = false;
            label1.Visible = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void PrepareMappingData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn tbCol = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cbCol = new DataGridViewComboBoxColumn();
            DataGridViewButtonColumn bcCol = new DataGridViewButtonColumn();
            tbCol.HeaderText = "Original Type";
            cbCol.HeaderText = "New Type";
            bcCol.HeaderText = "Color Picker";
            bcCol.Name = "Color Picker";
            dataGridView1.Columns.AddRange(tbCol, cbCol,bcCol);

            int row = 0;
            HashSet<string> added = new HashSet<string>();
            foreach (var temp in RepoTransaction.TransTypes.Values)
            {
                added.Add(temp.TransDesc);
                AddAnotherRow(row);
                string NewValue = "";
                NewValue = GetRemappedExpenseType(temp.TransDesc);
                dataGridView1.Rows[row].Cells[1].Value = NewValue;
                dataGridView1.Rows[row].Cells[0].Value = temp.TransDesc;
                row++;
            }

            tbCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cbCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        private string GetRemappedExpenseType(string keyToCheck)
        {
            if (RepoTransaction.MapTransTypes.ContainsKey(keyToCheck))
                return RepoTransaction.MapTransTypes[keyToCheck];
            else
                return keyToCheck;
        }

        private void AddAnotherRow(int row)
        {
            dataGridView1.Rows.Add();
            ComboBox expenseTypes = new ComboBox();
            List<string> str = RepoTransaction.GetAllAvailableTypes();
            str.Sort();
            expenseTypes.Items.AddRange(str.ToArray());
            DataGridViewComboBoxCell dgvcbc = new DataGridViewComboBoxCell();
            dataGridView1[1, row] = dgvcbc;
            dgvcbc.DataSource = expenseTypes.Items;

            Button colorButton = new Button();
            colorButton.BackColor = Color.Aqua;
            DataGridViewButtonCell bCell = new DataGridViewButtonCell();
            dataGridView1[2, row] = bCell;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            RepoTransaction.choseColor = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView1.Columns["Color Picker"].Index) return;

            if (!RepoTransaction.choseColor)
            {
                RepoTransaction.choseColor = true;
                // Retrieve the task ID.
                string column = dataGridView1[1, e.RowIndex].Value.ToString();


                MessageBox.Show(String.Format(
                    "Task {0} is unassigned.", column), "Status Request");
            }
        }

        private void ColorPicker(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<ModelMapExpenseTypes> maps = new List<ModelMapExpenseTypes>();
            ModelMapExpenseTypes map = new ModelMapExpenseTypes();
            map.OrigVal = "";
            map.NewVal = textBox1.Text;
            maps.Add(map);
            RepoTransaction.EditTransMap(maps, 'A');
            RepoTransaction.PrepareTransMap();
            PrepareMappingData();
        }

        private void EnableButton(object sender, EventArgs e)
        {
            string newText = textBox1.Text.Trim();
            if (newText != "" && !RepoTransaction.MapTransNew.Contains(newText))
            {
                button2.Enabled = true;
                label1.Visible = false;
            }
            else
            {
                if (RepoTransaction.MapTransNew.Contains(newText))
                {
                    label1.Visible = true;
                }
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ModelMapExpenseTypes> mapsToUpdate = new List<ModelMapExpenseTypes>();
            List<ModelMapExpenseTypes> newmaps = new List<ModelMapExpenseTypes>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string origvl = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                DataGridViewComboBoxCell cbcell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1];
                string newVal = cbcell.EditedFormattedValue.ToString().Trim();

                if (RepoTransaction.MapTransTypes.ContainsKey(origvl))
                {
                    if (RepoTransaction.MapTransTypes[origvl] != newVal)
                    {
                        ModelMapExpenseTypes map = new ModelMapExpenseTypes();
                        map.MapId = RepoTransaction.GetExpenseTypeKey(origvl);
                        map.OrigVal = origvl;
                        map.NewVal = newVal;
                        mapsToUpdate.Add(map);
                    }
                }
                else
                {
                    ModelMapExpenseTypes map = new ModelMapExpenseTypes();
                    map.OrigVal = origvl;
                    map.NewVal = newVal;
                    newmaps.Add(map);
                }
            }
            if (newmaps.Count > 0)
            {
                RepoTransaction.EditTransMap(newmaps, 'A');
            }
            if (mapsToUpdate.Count > 0)
            {
                RepoTransaction.EditTransMap(mapsToUpdate, 'U');
            }
            labelUpdate.Text = $"Updated {mapsToUpdate.Count} Maps.  Added {newmaps.Count} Maps.";
            labelUpdate.Visible = true;
            RepoTransaction.PrepareTransMap();
            PrepareMappingData();
        }

        private void ExpenseMap_Load(object sender, EventArgs e)
        {

        }
    }
}
