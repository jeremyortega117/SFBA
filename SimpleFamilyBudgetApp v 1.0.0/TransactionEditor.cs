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
    public partial class TransactionEditor : Form
    {

        internal static int key = -1;
        internal static HashSet<string> acctStrCheck;

        public TransactionEditor()
        {
            InitializeComponent();
            ResetUI();
            buttonSubmitExpense.Enabled = false;
            buttonImportFile.Enabled = false;
        }

        private void ResetUI()
        {
            comboBoxTransType.Text = "";
            comboBoxAcct.Text = "";
            textBoxAmount.Text = "";
            textBoxDescription.Text = "";
            checkBoxIncome.Checked = false;
            dateTimePickerTransDate.Value = DateTime.Now;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            checkBoxUpdateBalance.Checked = true;
            RepoBankAccount.PrepareAccountTypes();
            RepoBankAccount.PrepareAcctEditorData();
            RepoTransaction.PrepareTransTypes();
            RepoTransaction.PrepareTransData();
            ListViewRepoTransactions lvrt = new ListViewRepoTransactions(listView1);
            lvrt.AddDataToListView(listView1);
            PrepareComboBoxes();
        }

        private void PrepareComboBoxes()
        {
            comboBoxTransType.Items.Clear();
            foreach (ModelTransType trans in RepoTransaction.TransTypes.Values)
            {
                comboBoxTransType.Items.Add($"{trans.TransDesc}");
            }

            comboBoxAcct.Items.Clear();
            acctStrCheck = new HashSet<string>();
            foreach (var BankInfo in RepoBankAccount.Accounts.Values)
            {
                var acctType = RepoBankAccount.AccountTypes[BankInfo.AcctTypeKey];
                string strChk = $"{BankInfo.BankName}, {BankInfo.AcctLastFour}, {acctType.AcctType}";
                comboBoxAcct.Items.Add(strChk);
                if (!acctStrCheck.Contains(strChk))
                {
                    acctStrCheck.Add(strChk);
                }
            }
        }

        /// <summary>
        /// Add Expense Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddTransType_Click(object sender, EventArgs e)
        {
            if (comboBoxTransType.Text.Trim() != "")
            {
                listView1.Clear();
                List<ModelTransType> transTypes = new List<ModelTransType>();
                ModelTransType transType = new ModelTransType();
                transType.TransDesc = comboBoxTransType.Text;
                if (checkBoxIncome.Checked)
                {
                    transType.TransSign = '+';
                }
                else
                {
                    transType.TransSign = '-';
                }
                transTypes.Add(transType);
                RepoTransaction.EditTransType(transTypes, 'A');
                ResetUI();
            }
        }

        /// <summary>
        /// Submit Transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            List<ModelTrans> transTypes = new List<ModelTrans>();
            ModelTrans transType = new ModelTrans();
            transType.TransTypeKey = RepoTransaction.GetTransTypeKeyFromSelected(comboBoxTransType.Text);
            char sign = RepoTransaction.TransTypes[transType.TransTypeKey].TransSign;
            transType.Amount = Convert.ToDouble(textBoxAmount.Text.Replace("$", "").Replace("(", "").Replace(")", ""));
            if (sign != '+') {
                transType.Amount *= -1;
            }
            transType.TransDate = dateTimePickerTransDate.Value;
            transType.AcctKey = RepoTransaction.GetAcctKeyFromSelected(comboBoxAcct.Text);
            transType.TransDesc = textBoxDescription.Text;
            transTypes.Add(transType);
            RepoTransaction.EditTrans(transTypes, 'A');
            ResetUI();
        }

        private void comboBoxTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int transTypeKey = RepoTransaction.GetTransTypeKeyFromSelected(comboBoxTransType.Text);
            if (transTypeKey != -1)
            {
                if (RepoTransaction.TransTypes[transTypeKey].TransSign == '+')
                {
                    checkBoxIncome.Checked = true;
                }
                else
                {
                    checkBoxIncome.Checked = false;
                }
                checkBoxIncome.Enabled = false;
            }
            else
            {
                checkBoxIncome.Enabled = true;
            }
            CheckIfButtonEnabled();
        }

        private void CheckIfButtonEnabled()
        {
            if(textBoxDescription.Text.Trim() != ""
                && textBoxAmount.Text.Trim() != ""
                && comboBoxAcct.Text.Trim() != ""
                && comboBoxTransType.Text.Trim() != "")
            {
                buttonSubmitExpense.Enabled = true;
            }
            else
            {
                buttonSubmitExpense.Enabled = false;
            }
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIfButtonEnabled();
            if(acctStrCheck.Contains(comboBoxAcct.Text))
            {
                buttonImportFile.Enabled = true;
            }
            else
            {
                buttonImportFile.Enabled = false;
            }
        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            CheckIfButtonEnabled();
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            CheckIfButtonEnabled();
        }

        private void buttonImportFile_Click(object sender, EventArgs e)
        {
            ImportFile file = new ImportFile(comboBoxAcct.Text);
            file.ShowDialog();
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 1)
            {
                buttonSubmitExpense.Enabled = false;
                buttonUpdate.Enabled = false;
                buttonDelete.Enabled = true;
                labelKey.Text = "";
                ClearText();
            }
            else if(listView1.SelectedItems.Count == 1)
            {
                buttonSubmitExpense.Enabled = true;
                buttonUpdate.Enabled = true;
                buttonDelete.Enabled = true;
                FillDataInEditor();
            }
            else if (listView1.SelectedItems.Count == 0)
            {
                buttonSubmitExpense.Enabled = true;
                buttonUpdate.Enabled = false;
                buttonDelete.Enabled = false;
                labelKey.Text = "";
            }
        }

        private void FillDataInEditor()
        {
            // Transaction Type
            int transKey = Convert.ToInt32(listView1.SelectedItems[0].SubItems[9].Text);
            labelKey.Text = transKey.ToString();
            ModelTransType type = RepoTransaction.TransTypes[RepoTransaction.Trans[transKey].TransTypeKey];
            string transType = type.TransDesc;
            comboBoxTransType.Text = transType;

            // Acct
            int AcctNum = Convert.ToInt32(listView1.SelectedItems[0].SubItems[8].Text);
            comboBoxAcct.Text = RepoBankAccount.RetrieveAcctSummaryFromAcctKey(AcctNum);

            // Balance
            textBoxAmount.Text = listView1.SelectedItems[0].SubItems[1].Text;

            // Description
            textBoxDescription.Text = listView1.SelectedItems[0].SubItems[3].Text;

            // Date Time
            DateTime date = Convert.ToDateTime(listView1.SelectedItems[0].SubItems[0].Text);
            dateTimePickerTransDate.Value = date;

            if(type.TransSign == '+')
            {
                checkBoxIncome.Checked = true;
            }
            else
            {
                checkBoxIncome.Checked = false;
            }

            //MessageBox.Show(transType);
        }

        private void TransactionEditor_Load(object sender, EventArgs e)
        {

        }

        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            ClearText();
        }

        private void ClearText()
        {
            comboBoxTransType.Text = "";
            comboBoxAcct.Text = "";
            textBoxAmount.Text = "";
            textBoxDescription.Text = "";
            checkBoxIncome.Checked = false;
            dateTimePickerTransDate.Value = DateTime.Now;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int transKey = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text);
            List<ModelTrans> trans = new List<ModelTrans>();
            ModelTrans tran = RepoTransaction.Trans[transKey];
            tran.TransTypeKey = RepoTransaction.GetTransTypeKeyFromSelected(comboBoxTransType.Text);
            tran.TransDesc = textBoxDescription.Text;
            tran.Amount = Convert.ToDouble(textBoxAmount.Text.Replace("$", "").Replace("(", "").Replace(")", ""));
            trans.Add(tran);
            RepoTransaction.EditTrans(trans, 'U');
            listView1.Clear();
            ResetUI();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            List<ModelTrans> trans = new List<ModelTrans>();
            for (int count = 0; count < listView1.SelectedItems.Count; count++)
            {
                int key = Convert.ToInt32(listView1.SelectedItems[count].SubItems[1].Text);
                ModelTrans tran = RepoTransaction.Trans[Convert.ToInt32(key)];
                trans.Add(tran);
            }

            RepoTransaction.EditTrans(trans, 'D');
            ResetUI();
        }

        private void checkBoxUpdateBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUpdateBalance.Checked)
            {
                RepoTransaction.editBal = 'Y';
            }
            else
            {
                RepoTransaction.editBal = 'N';
            }
        }
    }
}
