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
        public TransactionEditor()
        {
            InitializeComponent();
            ResetUI();
            button1.Enabled = false;
        }

        private void ResetUI()
        {
            comboBoxTransType.Text = "";
            comboBoxAcct.Text = "";
            textBoxAmount.Text = "";
            textBoxDescription.Text = "";
            dateTimePickerTransDate.Value = DateTime.Now;
            BankAccountRepo.PrepareAccountTypes();
            BankAccountRepo.PrepareAcctEditorData();
            TransactionRepo.PrepareTransTypes();
            TransactionRepo.PrepareTransData();
            ListViewRepoTransactions lvrt = new ListViewRepoTransactions(listView1);
            lvrt.AddDataToListView(listView1);
            PrepareComboBoxes();
        }

        private void PrepareComboBoxes()
        {
            comboBoxTransType.Items.Clear();
            foreach (TransTypeModel trans in TransactionRepo.TransTypes.Values)
            {
                comboBoxTransType.Items.Add($"{trans.TransDesc}");
            }

            comboBoxAcct.Items.Clear();
            foreach (var BankInfo in BankAccountRepo.Accounts.Values)
            {
                var acctType = BankAccountRepo.AccountTypes[BankInfo.AcctTypeKey];
                comboBoxAcct.Items.Add($"{BankInfo.BankName}, {BankInfo.AcctLastFour}, {acctType.AcctType}");
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
                List<TransTypeModel> transTypes = new List<TransTypeModel>();
                TransTypeModel transType = new TransTypeModel();
                transType.TransDesc = comboBoxTransType.Text;
                transTypes.Add(transType);
                TransactionRepo.EditTransType(transTypes, 'A');
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
            List<TransModel> transTypes = new List<TransModel>();
            TransModel transType = new TransModel();
            transType.Amount = Convert.ToDouble(textBoxAmount.Text);
            transType.TransDate = dateTimePickerTransDate.Value;
            transType.AcctKey = TransactionRepo.GetAcctKeyFromSelected(comboBoxAcct.Text);
            transType.TransTypeKey = TransactionRepo.GetTransTypeKeyFromSelected(comboBoxTransType.Text);
            transType.TransDesc = textBoxDescription.Text;
            transTypes.Add(transType);
            TransactionRepo.EditTrans(transTypes, 'A');
            ResetUI();
        }

        private void comboBoxTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
                CheckIfButtonEnabled();
        }

        private void CheckIfButtonEnabled()
        {
            if(textBoxDescription.Text.Trim() != ""
                && textBoxAmount.Text.Trim() != ""
                && comboBoxAcct.Text.Trim() != ""
                && comboBoxTransType.Text.Trim() != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIfButtonEnabled();
        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            CheckIfButtonEnabled();
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            CheckIfButtonEnabled();
        }
    }
}
