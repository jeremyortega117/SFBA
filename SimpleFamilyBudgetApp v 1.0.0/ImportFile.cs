using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public partial class ImportFile : Form
    {
        
        public ImportFile(string text)
        {
            InitializeComponent();
            buttonImport.Enabled = false;
            account = text;
            checkBoxIgnoreDups.Checked = true;
        }


        internal static string account;
        internal static string fileContent;
        internal static OpenFileDialog openFileDialog;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            fileContent = string.Empty;
            var filePath = string.Empty;

            using (openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                //openFileDialog.Filter = "txt files (*.txt)|*.txt|Excel files (*.xlsx)|*.xlsx|Csv files (*.csv)|*.csv";
                openFileDialog.Filter = "Csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    string ext = Path.GetExtension(openFileDialog.FileName);

                    //switch (ext)
                    //{
                    //    case ".xlsx":
                    //        MessageBox.Show("Importing Excel File");
                    //        break;
                    //    case ".txt":
                    //        MessageBox.Show("Importing Text File");
                    //        break;
                    //    case ".csv":
                    //        MessageBox.Show("Importing csv File");
                    //        break;
                    //}
                    buttonImport.Enabled = true;
                }
                else
                {
                    buttonImport.Enabled = false;
                }
            }
            textBoxFileLocation.Text = filePath;
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            //Read the contents of the file into a stream
            var fileStream = openFileDialog.OpenFile();

            if (checkBoxIgnoreDups.Checked)
            {
                RepoTransaction.IgnoreDups = true;
            }

            using (StreamReader reader = new StreamReader(fileStream))
            {
                reader.ReadLine();
                List<ModelTrans> trans = new List<ModelTrans>();
                while (reader.Peek() >= 0)
                {
                    fileContent = reader.ReadLine();
                    ModelTrans tran = new ModelTrans();
                    string[] line = fileContent.Split(',');
                    tran.TransDate = Convert.ToDateTime(line[0]);
                    tran.TransDesc = $"{line[1]} - {line[2]}";
                    tran.TransDesc = tran.TransDesc.Replace("\"", "");
                    tran.Amount = Convert.ToDouble(line[4]);
                    if (RepoTransaction.GetTransTypeKeyFromSelected(line[3]) == -1)
                    {
                        List<ModelTransType> transTypes = new List<ModelTransType>();
                        ModelTransType transType = new ModelTransType();
                        transType.TransDesc = line[3];
                        if (tran.Amount > 0)
                        {
                            transType.TransSign = '+';

                        }
                        else
                        {
                            transType.TransSign = '-';
                        }
                        transTypes.Add(transType);
                        RepoTransaction.EditTransType(transTypes, 'A');
                        RepoTransaction.PrepareTransTypes();
                    }
                    tran.TransTypeKey = RepoTransaction.GetTransTypeKeyFromSelected(line[3]);
                    tran.AcctKey = RepoTransaction.GetAcctKeyFromSelected(account);
                    trans.Add(tran);
                }
                RepoTransaction.EditTrans(trans, 'A');
            }
            Close();
        }

        private void checkBoxIgnoreDups_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIgnoreDups.Checked)
            {
                RepoTransaction.IgnoreDups = true;
            }
            else
            {
                RepoTransaction.IgnoreDups = false;
            }
        }
    }
}
