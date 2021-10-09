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
    public partial class BillEditor : Form
    {
        internal static Dictionary<char, string> BillTypes = new Dictionary<char, string>();
        internal static string C = "Continuous", T = "Timefreame (\"start - end time\")", P = "Pay To Own";
        internal static char billChar = '-';
        internal static decimal billAmount = 0;
        public BillEditor()
        {
            InitializeComponent();
            BillTypes.Add('c', C);
            BillTypes.Add('t', T);
            BillTypes.Add('p', P);
            foreach (var billType in BillTypes)
            {
                comboBox1.Items.Add(billType.Value);
            }
            JustDisableEverything();
            
        }

        private void JustDisableEverything()
        {
            textBoxAmount.Enabled = false;
            dateTimePickerFromDate.Enabled = false;
            dateTimePickerToDate.Enabled = false;
            checkBoxFriday.Enabled = false;
            checkBoxMonday.Enabled = false;
            checkBoxSaturday.Enabled = false;
            checkBoxSunday.Enabled = false;
            checkBoxThursday.Enabled = false;
            checkBoxTuesday.Enabled = false;
            checkBoxWednesday.Enabled = false;
            radioButtonDaily.Enabled = false;
            radioButtonMonthly.Enabled = false;
            radioButtonWeekly.Enabled = false;
            radioButtonYearly.Enabled = false;
            buttonInsertNewBill.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string billType = comboBox1.Text.Trim();
            if (billType != "")
            {
                JustDisableEverything();
                billChar = getCharFromString(billType);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAmount.Text.Trim() != "")
            {
                decimal amount = 0;
                if(Decimal.TryParse(textBoxAmount.Text, out amount))
                {
                    billAmount = amount;
                }
                else
                {
                    MessageBox.Show("Please Enter a dollar amount and try again.");
                    textBoxAmount.Text = "";
                }
            }
        }

        private char getCharFromString(string text)
        {
            EnableFrequency();
            textBoxAmount.Enabled = true;
            if (C == text)
            {
                return 'c';
            }
            if (T == text)
            {
                EnableFromEndDate();
                return 't';
            }
            if (P == text)
            {
                EnableFromEndDate();
                return 'p';
            }
            return '-';
        }

        private void EnableFromEndDate()
        {
            dateTimePickerFromDate.Enabled = true;
            dateTimePickerToDate.Enabled = true;
        }

        private void EnableFrequency()
        {
            radioButtonDaily.Enabled = true;
            radioButtonMonthly.Enabled = true;
            radioButtonWeekly.Enabled = true;
            radioButtonYearly.Enabled = true;
            checkBoxWednesday.Enabled = true;
            checkBoxTuesday.Enabled = true;
            checkBoxThursday.Enabled = true;
            checkBoxSunday.Enabled = true;
            checkBoxSaturday.Enabled = true;
            checkBoxMonday.Enabled = true;
            checkBoxFriday.Enabled = true;
        }

        private void buttonInsertNewBill_Click(object sender, EventArgs e)
        {

        }
    }
}
