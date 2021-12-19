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
            DataGridViewCheckBoxColumn inCol = new DataGridViewCheckBoxColumn();
            tbCol.HeaderText = "Original Type";
            cbCol.HeaderText = "New Type";
            bcCol.HeaderText = "Color Picker";
            bcCol.Name = "Color Picker";
            inCol.HeaderText = "Include Expense";
            dataGridView1.Columns.AddRange(tbCol,cbCol,bcCol,inCol);

            Dictionary<string, string> colorForFiguredTransTypes = new Dictionary<string, string>();
            int row = 0;
            HashSet<string> added = new HashSet<string>();
            foreach (var temp in RepoTransaction.TransTypes.Values)
            {
                int mapID;
                string color;
                string NewValue = "";
                NewValue = GetRemappedExpenseType(temp.TransDesc);
                mapID = RepoTransaction.GetExpenseTypeKey(temp.TransDesc);
                if(mapID != int.MinValue)
                    color = RepoTransaction.MapTransTypesByKey[mapID].ColorValue;
                else
                    color = "White";
                added.Add(temp.TransDesc);
                AddAnotherRow(row);
                dataGridView1.Rows[row].Cells[0].Value = temp.TransDesc;
                dataGridView1.Rows[row].Cells[1].Value = NewValue;
                dataGridView1.Rows[row].Cells[2].Value = color;
                dataGridView1.Rows[row].Cells[3].Value = RepoTransaction.MapTransTypesByKey[mapID].IncludeExpense;
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

            RepoTransaction.choseColor = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //null checking for  the column
            if (dataGridView1.CurrentRow.Cells["Color Picker"] != null)
            {
                ColorDialog colorDlg = new ColorDialog(); //create colordialog instance
                colorDlg.AllowFullOpen = true;
                colorDlg.AnyColor = true;
                colorDlg.ShowDialog(); //display dialog
                dataGridView1.CurrentRow.Cells["Color Picker"].Value = colorDlg.Color.Name; //keep the selected value
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
            map.ColorValue = "BLUE";
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

            Dictionary<string, string> colorForFiguredTransTypes = new Dictionary<string, string>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string origvl = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                DataGridViewComboBoxCell cbcell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1];
                string newVal = cbcell.EditedFormattedValue.ToString().Trim();
                string colorVal;
                int mapID = RepoTransaction.GetExpenseTypeKey(origvl);
                bool checkedExpense = true;
                
                DataGridViewCheckBoxCell includeExpense = new DataGridViewCheckBoxCell();
                includeExpense = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[3];

                // Color Picker
                if (!colorForFiguredTransTypes.ContainsKey(newVal))
                {
                    colorVal = dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString().Trim();
                    colorForFiguredTransTypes.Add(newVal,colorVal);
                }
                else
                {
                    colorVal = colorForFiguredTransTypes[newVal];
                    dataGridView1.Rows[i].Cells[2].Value = colorVal;
                }

                // Mapped types
                if (RepoTransaction.MapTransTypes.ContainsKey(origvl))
                {
                    if (RepoTransaction.MapTransTypes[origvl] != newVal 
                        || RepoTransaction.MapTransTypesByKey[mapID].ColorValue != colorVal
                        || RepoTransaction.MapTransTypesByKey[mapID].IncludeExpense != (bool)includeExpense.Value)
                    {
                        ModelMapExpenseTypes map = new ModelMapExpenseTypes();
                        map.MapId = mapID;
                        map.OrigVal = origvl;
                        map.NewVal = newVal;
                        map.ColorValue = colorVal;
                        map.IncludeExpense = (bool)includeExpense.Value;
                        mapsToUpdate.Add(map);
                    }
                }
                else
                {
                    ModelMapExpenseTypes map = new ModelMapExpenseTypes();
                    map.OrigVal = origvl;
                    map.NewVal = newVal;
                    map.ColorValue = colorVal;
                    map.IncludeExpense = true;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                //null checking for  the column
                if (dataGridView1.CurrentRow.Cells["Color Picker"] != null)
                {
                    ColorDialog colorDlg = new ColorDialog(); //create colordialog instance
                    colorDlg.AllowFullOpen = true;
                    colorDlg.AnyColor = true;
                    colorDlg.ShowDialog(); //display dialog
                    dataGridView1.CurrentRow.Cells["Color Picker"].Value = colorDlg.Color.Name; //keep the selected value
                }
            }
        }
    }
}
