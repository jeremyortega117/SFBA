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
            DataGridViewTextBoxColumn tbCol = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cbCol = new DataGridViewComboBoxColumn();
            dataGridView1.Columns.AddRange(tbCol, cbCol);

            int row = 0;
            foreach (var temp in RepoTransaction.TransTypes.Values)
            {
                AddAnotherRow(row);

                string keyToCheck = RepoTransaction.MapTransOrig.ElementAt(row);
                string NewValue = "";

                if (RepoTransaction.MapTransTypes.ContainsKey(keyToCheck)) 
                    NewValue = RepoTransaction.MapTransTypes[keyToCheck];
                else
                    NewValue = keyToCheck;

                dataGridView1.Rows[row].Cells[1].Value = NewValue;
                dataGridView1.Rows[row].Cells[0].Value = keyToCheck;
                row++;
            }
            tbCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cbCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        private void AddAnotherRow(int row)
        {
            dataGridView1.Rows.Add();
            ComboBox expenseTypes = new ComboBox();
            expenseTypes.Items.AddRange(RepoTransaction.MapTransOrig.ToArray());
            DataGridViewComboBoxCell dgvcbc = new DataGridViewComboBoxCell();
            dataGridView1[1, row] = dgvcbc;
            dgvcbc.DataSource = expenseTypes.Items;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<ModelMapExpenseTypes> maps = new List<ModelMapExpenseTypes>();

            ModelMapExpenseTypes map = new ModelMapExpenseTypes();
            map.OrigVal = "";
            map.NewVal = textBox1.Text;
            maps.Add(map);
            RepoTransaction.EditTransMap(maps, 'A');
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
            PrepareMappingData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ModelMapExpenseTypes> mapsToUpdate = new List<ModelMapExpenseTypes>();
            List<ModelMapExpenseTypes> newmaps = new List<ModelMapExpenseTypes>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    string origvl = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                    DataGridViewComboBoxCell cbcell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1];
                    string newVal = cbcell.EditedFormattedValue.ToString().Trim();

                    if (RepoTransaction.MapTransTypes.ContainsKey(origvl))
                    {
                        if (RepoTransaction.MapTransTypes[origvl] != newVal)
                        {
                            ModelMapExpenseTypes map = new ModelMapExpenseTypes();
                            foreach (int key in RepoTransaction.MapTransTypesByKey.Keys)
                            {
                                if (RepoTransaction.MapTransTypesByKey[key].OrigVal == origvl)
                                {
                                    map.MapId = key;
                                    break;
                                }
                            }
                            map.OrigVal = origvl;
                            map.NewVal = newVal;
                            mapsToUpdate.Add(map);
                        }
                    }
                    if (!RepoTransaction.MapTransNew.Contains(newVal))
                    {
                        ModelMapExpenseTypes map = new ModelMapExpenseTypes();
                        map.OrigVal = origvl;
                        map.NewVal = newVal;
                        newmaps.Add(map);
                    }
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
            RepoTransaction.PrepareTransMap();
            PrepareMappingData();
        }
    }
}
