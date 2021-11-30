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

            DataTable dt = new DataTable();
            dt.Columns.Add("OriginalType", typeof(String));
            dt.Columns.Add("NewType", typeof(String));

            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("Money", typeof(String));
            //dt2.Columns.Add("Meaning", typeof(String));


            List<string> beforeCheckRightSide = new List<string>();
            foreach (var temp in RepoTransaction.TransTypes.Values)
            {
                if (!beforeCheckRightSide.Contains(temp.TransDesc))
                {
                    beforeCheckRightSide.Add(temp.TransDesc);
                }
            }

            int count = 0;
            foreach (var temp in RepoTransaction.TransTypes.Values) {
                //dt.Rows.Add(new object[] { temp.TransDesc, count });
                if (!RepoTransaction.MapTransTypes.ContainsKey(temp.TransDesc)) 
                {
                    dt.Rows.Add(new object[] { temp.TransDesc, temp.TransDesc });
                }
                else
                {
                    dt.Rows.Add(new object[] { temp.TransDesc, RepoTransaction.MapTransTypes[temp.TransDesc] });
                }
                count++;
            }

            DataGridViewTextBoxColumn OrigTypes = new DataGridViewTextBoxColumn();
            OrigTypes.HeaderText = "OriginalType";
            OrigTypes.DataPropertyName = "OriginalType";


            DataGridViewComboBoxColumn FiguredTypes = new DataGridViewComboBoxColumn();
            FiguredTypes.DataSource = beforeCheckRightSide;
            //FiguredTypes.HeaderText = "Money";
            //FiguredTypes.DataPropertyName = "Money";
            //FiguredTypes.DisplayMember = "Meaning";
            //FiguredTypes.ValueMember = "Money";

            dataGridView1.Columns.Add(OrigTypes);
            dataGridView1.Columns.Add(FiguredTypes);
            dataGridView1.DataSource = dt;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells[0].Value != null)
            //    {
            //        string origvl = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
            //        DataGridViewComboBoxCell cbcell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1];
            //        string newVal = cbcell.EditedFormattedValue.ToString().Trim();

            //        if (RepoTransaction.MapTransTypes.ContainsKey(origvl))
            //        {
            //            if (RepoTransaction.MapTransTypes[origvl] != newVal)
            //            {
            //                cbcell. = RepoTransaction.MapTransTypes[origvl];
            //            }
            //        }
            //    }
            //}
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
        }
    }
}
