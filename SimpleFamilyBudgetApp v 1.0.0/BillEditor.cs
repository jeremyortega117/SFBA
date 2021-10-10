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
        internal static decimal billTotal = 0;
        internal static bool ignore = true;

        public BillEditor()
        {
            InitializeComponent();
            PrepComboBox();
            JustDisableEverything();
            ignore = true;
            radioButtonMonthly.Checked = true;
            checkBoxMonday.Checked = true;
            ignore = false;
        }

        private void PrepComboBox()
        {
            BillTypes.Add('c', C);
            BillTypes.Add('t', T);
            BillTypes.Add('p', P);
            foreach (var billType in BillTypes)
            {
                comboBoxBillType.Items.Add(billType.Value);
            }

            foreach(int Key in RepoBankAccount.Accounts.Keys)
            {
                var account = RepoBankAccount.Accounts[Key];
                string acc = $"{account.BankName}, {account.AcctLastFour}, {RepoBankAccount.AccountTypes[account.AcctTypeKey].AcctType}";
                comboBoxAccount.Items.Add(acc);
            }
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
            textBoxPayOffTotal.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string billType = comboBoxBillType.Text.Trim();
            if (billType != "")
            {
                JustDisableEverything();
                billChar = getCharFromString(billType);
                if (billChar == 'p')
                {
                    textBoxPayOffTotal.Enabled = true;
                    dateTimePickerFromDate.Enabled = false;
                    dateTimePickerToDate.Enabled = false;
                    CheckIfEnableCreate();
                }
                else
                {
                    dateTimePickerFromDate.Enabled = true;
                    if(billChar != 'c')
                        dateTimePickerToDate.Enabled = true;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAmount.Text.Trim() != "")
            {
                string billType = comboBoxBillType.Text.Trim();
                decimal amount = 0;
                if(Decimal.TryParse(textBoxAmount.Text, out amount))
                {
                    billAmount = amount;
                    billChar = getCharFromString(billType);
                    if (billChar == 'p')
                    {
                        PredictDates();
                        CheckIfEnableCreate();
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a dollar amount and try again.");
                    textBoxAmount.Text = "";
                    billAmount = 0;
                }
            }
        }

        private void textBoxPayOffTotal_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPayOffTotal.Text.Trim() != "")
            {
                decimal amount;
                if (decimal.TryParse(textBoxPayOffTotal.Text, out amount))
                {
                    billTotal = amount;
                }
                else
                {
                    MessageBox.Show("Please Enter a dollar amount and try again.");
                    textBoxPayOffTotal.Text = "";
                    billTotal = 0;
                }
            }
            PredictDates();
        }

        private void PredictDates()
        {
            if(billTotal > billAmount && billAmount > 0)
            {
                int interval = Convert.ToInt32(Math.Floor(billTotal / billAmount));
                decimal remainder = billTotal % billAmount;
                if (remainder != 0)
                {
                    interval++;
                }
                DateTime dates = dateTimePickerFromDate.Value;


                if (radioButtonMonthly.Checked)
                {
                    dateTimePickerToDate.Value = dates.AddMonths(interval);
                }

                else if (radioButtonYearly.Checked)
                {
                    dateTimePickerToDate.Value = dates.AddYears(interval);
                }

                else if (radioButtonDaily.Checked) 
                {
                    dateTimePickerToDate.Value = dates.AddDays(interval);
                }

                else
                {
                    if (checkBoxFriday.Checked
                        || checkBoxMonday.Checked
                        || checkBoxTuesday.Checked
                        || checkBoxWednesday.Checked
                        || checkBoxThursday.Checked
                        || checkBoxSaturday.Checked
                        || checkBoxSunday.Checked)
                    {
                        int countdown = interval;
                        DateTime day = dates;
                        while (countdown > 0)
                        {
                            day = day.AddDays(1);
                            if (checkBoxFriday.Checked && day.DayOfWeek == DayOfWeek.Friday)
                            {
                                countdown--;
                            }
                            else if (checkBoxSaturday.Checked && day.DayOfWeek == DayOfWeek.Saturday)
                            {
                                countdown--;
                            }
                            else if (checkBoxSunday.Checked && day.DayOfWeek == DayOfWeek.Sunday)
                            {
                                countdown--;
                            }
                            else if (checkBoxMonday.Checked && day.DayOfWeek == DayOfWeek.Monday)
                            {
                                countdown--;
                            }
                            else if (checkBoxTuesday.Checked && day.DayOfWeek == DayOfWeek.Tuesday)
                            {
                                countdown--;
                            }
                            else if (checkBoxWednesday.Checked && day.DayOfWeek == DayOfWeek.Wednesday)
                            {
                                countdown--;
                            }
                            else if(checkBoxThursday.Checked && day.DayOfWeek == DayOfWeek.Thursday)
                            {
                                countdown--;
                            }
                        }
                        dateTimePickerToDate.Value = day;
                    }
                    else
                    {
                        MessageBox.Show("Please check at least one day of the week if you are paying weekly before trying again.");
                    }
                }
            }
            CheckIfEnableCreate();
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
            CheckIfEnableCreate();
        }

        private void radioButtonMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMonthly.Checked && !ignore)
            {
                radioButtonFreqChanged();
                PredictDates();
            }
        }

        private void radioButtonWeekly_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeekly.Checked && !ignore)
            {
                radioButtonFreqChanged();
                PredictDates();
            }
        }

        private void radioButtonDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDaily.Checked && !ignore)
            {
                radioButtonFreqChanged();
                PredictDates();
            }
        }

        private void radioButtonYearly_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonYearly.Checked && !ignore)
            {
                radioButtonFreqChanged();
                PredictDates();
            }
        }

        private void radioButtonFreqChanged()
        {
            if (radioButtonDaily.Checked)
            {
                EnableDaysOfWeek(false);
            }
            else if (radioButtonMonthly.Checked)
            {
                EnableDaysOfWeek(false);
            }
            else if (radioButtonWeekly.Checked)
            {
                EnableDaysOfWeek(true);
            }
            else if (radioButtonYearly.Checked)
            {
                EnableDaysOfWeek(false);
            }
        }

        private void EnableFrequency()
        {
            radioButtonDaily.Enabled = true;
            radioButtonMonthly.Enabled = true;
            radioButtonWeekly.Enabled = true;
            radioButtonYearly.Enabled = true;
            EnableDaysOfWeek(true);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIfEnableCreate();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxMonday_CheckedChanged(object sender, EventArgs e)
        {
            PredictDates();
        }

        private void checkBoxWednesday_CheckedChanged(object sender, EventArgs e)
        {
            PredictDates();
        }

        private void checkBoxFriday_CheckedChanged(object sender, EventArgs e)
        {
            PredictDates();
        }

        private void checkBoxSunday_CheckedChanged(object sender, EventArgs e)
        {
            PredictDates();
        }

        private void checkBoxTuesday_CheckedChanged(object sender, EventArgs e)
        {
            PredictDates();
        }

        private void checkBoxThursday_CheckedChanged(object sender, EventArgs e)
        {
            PredictDates();
        }

        private void checkBoxSaturday_CheckedChanged(object sender, EventArgs e)
        {
            PredictDates();
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            CheckIfEnableCreate();
        }

        private void CheckIfEnableCreate()
        {
            char c = getCharFromString(comboBoxBillType.Text);
            if(c == 'c')
            {
                if (comboBoxAccount.Text.Trim() != ""
                    && textBoxAmount.Text.Trim() != ""
                    && FrequencyFound()
                    && textBoxDescription.Text.Trim() != ""
                    )
                {
                    buttonInsertNewBill.Enabled = true;
                    return;
                }
            }
            else if (c == 't')
            {
                if (comboBoxAccount.Text.Trim() != ""
                    && textBoxAmount.Text.Trim() != ""
                    && FrequencyFound()
                    && datesWork()
                    && textBoxDescription.Text.Trim() != ""
                    )
                {
                    buttonInsertNewBill.Enabled = true;
                    return;
                }
            }
            else if (c == 'p')
            {
                if (comboBoxAccount.Text.Trim() != ""
                    && textBoxAmount.Text.Trim() != ""
                    && textBoxPayOffTotal.Text.Trim() != ""
                    && FrequencyFound()
                    && datesWork()
                    && textBoxDescription.Text.Trim() != ""
                    )
                {
                    buttonInsertNewBill.Enabled = true;
                    return;
                }
            }
            buttonInsertNewBill.Enabled = false;
        }

        private bool datesWork()
        {
            return dateTimePickerFromDate.Value < dateTimePickerToDate.Value;
        }

        private bool FrequencyFound()
        {
            if(radioButtonDaily.Checked
               || radioButtonMonthly.Checked
               || radioButtonYearly.Checked
               || (radioButtonWeekly.Checked && (checkBoxFriday.Checked
                                                || checkBoxMonday.Checked
                                                || checkBoxSaturday.Checked
                                                || checkBoxSunday.Checked
                                                || checkBoxThursday.Checked
                                                || checkBoxTuesday.Checked
                                                || checkBoxWednesday.Checked)))
            {
                return true;
            }
            return false;
        }

        private void EnableDaysOfWeek(bool trueFalse)
        {
            checkBoxWednesday.Enabled = trueFalse;
            checkBoxTuesday.Enabled = trueFalse;
            checkBoxThursday.Enabled = trueFalse;
            checkBoxSunday.Enabled = trueFalse;
            checkBoxSaturday.Enabled = trueFalse;
            checkBoxMonday.Enabled = trueFalse;
            checkBoxFriday.Enabled = trueFalse;

        }

        private void buttonInsertNewBill_Click(object sender, EventArgs e)
        {

        }
    }
}
