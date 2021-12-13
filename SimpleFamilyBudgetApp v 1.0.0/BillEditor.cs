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
        internal static ListViewRepoBills lvue;
        internal static int BillKey = 0;

        public BillEditor()
        {
            InitializeComponent();
            JustDisableEverything();
            ignore = true;
            radioButtonMonthly.Checked = true;
            checkBoxMonday.Checked = true;
            ignore = false;
            radioButtonNewDescription.Checked = true;
            comboBoxDescription.Enabled = false;
            radioButtonDailyInt.Enabled = false;
            radioButtonMonthlyInt.Checked = true;
            radioButtonMonthlyInt.Enabled = false;
            textBoxPercent.Text = "";
            textBoxPercent.Enabled = false;
            PrepareListViewData();
            PrepComboBox();
        }

        private void PrepareListViewData()
        {
            listViewExistingBills.Clear();
            lvue = new ListViewRepoBills(listViewExistingBills, ListViewRepoBills.BillHeaderList);
            lvue.AddDataToListView(listViewExistingBills);
        }

        private void PrepComboBox()
        {
            BillTypes.Clear();
            BillTypes.Add('c', C);
            BillTypes.Add('t', T);
            BillTypes.Add('p', P);

            comboBoxBillType.Items.Clear();
            foreach (var billType in BillTypes)
            {
                comboBoxBillType.Items.Add(billType.Value);
            }

            comboBoxAccount.Items.Clear();
            foreach (int Key in RepoBankAccount.Accounts.Keys)
            {
                var account = RepoBankAccount.Accounts[Key];
                string acc = $"{account.BankName}, {account.AcctLastFour}, {RepoBankAccount.AccountTypes[account.AcctTypeKey].AcctType}";
                comboBoxAccount.Items.Add(acc);
            }

            comboBoxDescription.Items.Clear();
            HashSet<string> BillDescriptions = new HashSet<string>();
            foreach (int billKey in RepoBills.Bills.Keys)
            {
                string desc = RepoBills.Bills[billKey].BillDesc.Trim();
                if (!BillDescriptions.Contains(desc))
                {
                    comboBoxDescription.Items.Add(desc);
                    BillDescriptions.Add(desc);
                }
            }

        }

        private void JustDisableEverything()
        {
            textBoxAmount.Enabled = false;
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
            if(comboBoxBillType.Text == "Pay To Own")
            {
                radioButtonDailyInt.Enabled = true;
                radioButtonMonthlyInt.Enabled = true;
                textBoxPercent.Enabled = true;
            }
            else
            {
                radioButtonDailyInt.Enabled = false;
                radioButtonMonthlyInt.Enabled = false;
                textBoxPercent.Enabled = false;
            }

            string billType = comboBoxBillType.Text.Trim();
            if (billType != "")
            {
                JustDisableEverything();
                billChar = getCharFromString(billType);
                textBoxAmount.Enabled = true;
                if (billChar == 'p')
                {
                    textBoxPayOffTotal.Enabled = true;
                    dateTimePickerToDate.Enabled = false;
                }
                else
                {
                    dateTimePickerFromDate.Enabled = true;
                    if(billChar != 'c')
                        dateTimePickerToDate.Enabled = true;
                }
                EnableRadioFrequencyButtons();
                if (radioButtonWeekly.Checked)
                {
                    radioButtonFreqChanged();
                }
                CheckIfEnableCreate();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAmount.Text.Trim() != "")
            {
                string billType = comboBoxBillType.Text.Trim();
                decimal amount;
                string strAmt = textBoxAmount.Text;
                if (strAmt.StartsWith("$"))
                {
                    strAmt = strAmt.Substring(1);
                }
                if (strAmt.StartsWith("+") || strAmt.StartsWith("-"))
                {
                    strAmt = strAmt.Substring(1);
                }
                strAmt = strAmt.Replace("$", "").Replace("(", "").Replace(")", "");
                strAmt = ConfigClass.RegexMoney.IsMatch(strAmt) ? strAmt.Replace(",", "").Replace("+","").Replace("-","") : "0";
                if (decimal.TryParse(strAmt, out amount))
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
                int interval = 0;
                decimal remainder = 0;
                decimal totalIntPotential = 0;
                if (comboBoxBillType.Text == "Pay To Own" && textBoxPercent.Text.Trim() != "")
                {
                    if (radioButtonMonthlyInt.Checked)
                    {
                        decimal principle, interest, intRate = Convert.ToDecimal(textBoxPercent.Text.Trim()) / 100 / 12;
                        interest = billTotal * intRate;
                        principle = billAmount - interest;
                        decimal RemainingBalance = billTotal - principle;
                        if (principle <= 0)
                        {
                            labelTotalIntPaid.Text = "";
                            labelNextIntPercAmt.Text = "";
                            labellabelNextPrincPayAmt.Text = "";
                            return;
                        }
                        totalIntPotential += interest;
                        labellabelNextPrincPayAmt.Text = string.Format("{0:C}", principle);
                        labelNextIntPercAmt.Text = string.Format("{0:C}", interest); 
                        while (RemainingBalance >= 0)
                        {
                            interest = RemainingBalance * intRate;
                            principle = billAmount - interest;
                            RemainingBalance -= principle;
                            totalIntPotential += interest;
                            interval++;
                        }
                        labelTotalIntPaid.Text = string.Format("{0:C}", totalIntPotential);
                    }
                    #region temp
                    //else
                    //{
                    //    decimal principle, interest, intRate = Convert.ToDecimal(textBoxPercent.Text.Trim()) / 100 / 365;
                    //    interest = billTotal * intRate;
                    //    principle = billAmount/ Convert.ToDecimal(30.25) - interest;
                    //    decimal RemainingBalance = billTotal - (interest + principle);
                    //    if (principle <= 0)
                    //    {
                    //        labelTotalIntPaid.Text = "";
                    //        labelNextIntPercAmt.Text = "";
                    //        labellabelNextPrincPayAmt.Text = "";
                    //        return;
                    //    }
                    //    totalIntPotential += interest;
                    //    bool firstThirty = true;
                    //    decimal runningInt = 0;
                    //    decimal runningPrinc = 0;
                    //    while (RemainingBalance >= 0)
                    //    {
                    //        interest = Convert.ToDecimal((RemainingBalance * intRate)/Convert.ToDecimal(30.25));
                    //        principle = (billAmount/Convert.ToDecimal(30.25)) - (interest);
                    //        RemainingBalance -= (interest + principle);
                    //        totalIntPotential += interest;
                    //        if (interval % 30 == 0)
                    //        {
                    //            if (firstThirty && interval != 0)
                    //            {
                    //                decimal interestAmt = (runningInt + interest) * Convert.ToDecimal(30.25);
                    //                labellabelNextPrincPayAmt.Text = string.Format("{0:C}", billAmount - interestAmt);
                    //                labelNextIntPercAmt.Text = string.Format("{0:C}", interestAmt);
                    //                firstThirty = false;
                    //            }
                    //            interval++;
                    //        }
                    //        else if (firstThirty)
                    //        {
                    //            runningInt += interest;
                    //            runningPrinc += principle;
                    //        }
                    //    }
                    //    totalIntPotential *= 30;
                    //    labelTotalIntPaid.Text = string.Format("{0:C}", totalIntPotential);
                    //}
                    #endregion
                    decimal newTotal = billTotal + totalIntPotential;
                    TotalPlusInterest.Text = string.Format("{0:C}", newTotal);
                    remainder = newTotal / billAmount;
                }
                else
                {
                    interval = Convert.ToInt32(Math.Floor(billTotal / billAmount));
                    remainder = billTotal % billAmount;
                    labelTotalIntPaid.Text = "";
                    TotalPlusInterest.Text = "";
                }
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
            if (C == text)
            {
                return 'c';
            }
            else if (T == text)
            {
                return 't';
            }
            else if (P == text)
            {
                return 'p';
            }
            else
            {
                return '-';
            }
        }

        private void EnableFromEndDate()
        {
            dateTimePickerFromDate.Enabled = true;
            dateTimePickerToDate.Enabled = true;
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

        private void EnableRadioFrequencyButtons()
        {

            radioButtonWeekly.Enabled = true;
            radioButtonYearly.Enabled = true;
            radioButtonDaily.Enabled = true;
            radioButtonMonthly.Enabled = true;
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
            if(comboBoxBillType.Text.Trim() == "")
            {
                return;
            }
            char c = getCharFromString(comboBoxBillType.Text);
            if(c == 'c')
            {
                if (comboBoxAccount.Text.Trim() != ""
                    && textBoxAmount.Text.Trim() != ""
                    && FrequencyFound()
                    && textBoxDescriptionFilled()
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
                    && textBoxDescriptionFilled()
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
                    && textBoxDescriptionFilled()
                    )
                {
                    buttonInsertNewBill.Enabled = true;
                    return;
                }
            }
            buttonInsertNewBill.Enabled = false;
        }

        private bool textBoxDescriptionFilled()
        {
            if (radioButtonNewDescription.Checked && textBoxDescription.Text.Trim() != "")
            {
                return true;
            }
            if(radioButtonUseExistingDescription.Checked && comboBoxDescription.Text.Trim() != "")
            {
                return true;
            }
            return false;
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

        private void dateTimePickerFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxBillType.Text.Trim() != "") {
                char c = getCharFromString(comboBoxBillType.Text);
                if (c != 't' && c != '-') {
                    radioButtonFreqChanged();
                    PredictDates();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CheckIfEnableCreate();
        }

        private void BillEditor_Load(object sender, EventArgs e)
        {

        }

        private void radioButtonNewDescription_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDescription.Enabled = true;
            comboBoxDescription.Enabled = false;
            CheckIfEnableCreate();
        }

        private void radioButtonUseExistingDescription_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDescription.Enabled = false;
            comboBoxDescription.Enabled = true;
            CheckIfEnableCreate();
        }

        private void radioButtonMonthlyInt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMonthlyInt.Checked && textBoxAmount.Text.Trim() != "")
            {
                //decimal temp = Convert.ToDecimal(textBoxAmount.Text) * 30;
                //textBoxAmount.Text = temp.ToString("0.00");
                //radioButtonMonthly.Checked = true;
                PredictDates();
            }
        }

        private void radioButtonDailyInt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDailyInt.Checked && textBoxAmount.Text.Trim() != "")
            {
                //decimal temp = Convert.ToDecimal(textBoxAmount.Text) / 30;
                //textBoxAmount.Text = temp.ToString("0.00");
                //radioButtonDaily.Checked = true;
                PredictDates();
            }
        }

        private void textBoxPercent_TextChanged(object sender, EventArgs e)
        {
            PredictDates();
        }


        /// <summary>
        /// Add Bill.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsertNewBill_Click(object sender, EventArgs e)
        {
            List<ModelBill> Bills = PrepareDataForDatabase();
            RepoBills.EditBill(Bills, 'A');
            UpdateAfterDataBaseInsertion();
        }

        private void UpdateAfterDataBaseInsertion()
        {
            clearText();
            JustDisableEverything();
            RepoFrequency.PrepareFrequencyData();
            RepoBills.PrepareBillEditorData();
            PrepareListViewData();
        }

        private List<ModelBill> PrepareDataForDatabase()
        {

            List<ModelBill> Bills = new List<ModelBill>();
            ModelBill Bill = new ModelBill();
            if (BillKey != 0)
            {
                Bill.BillKey = BillKey;
            }
            string strAmount = textBoxAmount.Text;
            Bill.Frequency = getCharFromRadioButtonFreq(new ModelFrequency());
            Bill.AccKey = RepoTransaction.GetAcctKeyFromSelected(comboBoxAccount.Text);
            Bill.Amount = billAmount != 0 ? billAmount : Convert.ToDecimal(strAmount);
            Bill.Total = billTotal != 0 ? billTotal : billAmount;
            Bill.BillStartDate = dateTimePickerFromDate.Value;
            Bill.Interest = textBoxPercent.Text.Trim() != "" ? Convert.ToDecimal(textBoxPercent.Text) : 0;
            Bill.BillEndDate = dateTimePickerToDate.Value;
            if (radioButtonNewDescription.Checked && textBoxDescription.Text.Trim() != "")
            {
                Bill.BillDesc = textBoxDescription.Text.Trim();
            }
            else if (radioButtonUseExistingDescription.Checked)
            {
                Bill.BillDesc = comboBoxDescription.Text.Trim();
            }
            Bill.BillType = getCharFromString(comboBoxBillType.Text);
            Bills.Add(Bill);
            return Bills;
        }

        private void listViewExistingBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearText();
            if (listViewExistingBills.SelectedItems.Count > 1)
            {
                buttonInsertNewBill.Enabled = false;
                buttonUpdate.Enabled = false;
                buttonDelete.Enabled = true;
            }
            else if (listViewExistingBills.SelectedItems.Count == 1)
            {
                FillDataInEditor();
                buttonDelete.Enabled = true;
                buttonUpdate.Enabled = true;
            }
            else if (listViewExistingBills.SelectedItems.Count == 0)
            {
                buttonUpdate.Enabled = false;
                buttonDelete.Enabled = false;
            }
        }

        private void FillDataInEditor()
        {
            BillKey = Convert.ToInt32(listViewExistingBills.SelectedItems[0].SubItems[0].Text);
            dateTimePickerFromDate.Value = Convert.ToDateTime(listViewExistingBills.SelectedItems[0].SubItems[1].Text);
            dateTimePickerToDate.Value = Convert.ToDateTime(listViewExistingBills.SelectedItems[0].SubItems[2].Text);
            char bType = Convert.ToChar(listViewExistingBills.SelectedItems[0].SubItems[8].Text);
            string billType = "";
            if(RepoBills.BillTypes.ContainsKey(bType))
            {
                billType = RepoBills.BillTypes[bType];
            }
            comboBoxBillType.Text = billType;
            comboBoxAccount.Text = listViewExistingBills.SelectedItems[0].SubItems[9].Text;
            textBoxAmount.Text = listViewExistingBills.SelectedItems[0].SubItems[4].Text;
            textBoxPayOffTotal.Text = listViewExistingBills.SelectedItems[0].SubItems[5].Text;
            textBoxPercent.Text = listViewExistingBills.SelectedItems[0].SubItems[6].Text;
            radioButtonUseExistingDescription.Checked = true; 
            comboBoxDescription.Text = listViewExistingBills.SelectedItems[0].SubItems[3].Text;
            int freqKey = -1;
            if (RepoBills.Bills.ContainsKey(BillKey)) {
                freqKey = RepoBills.Bills[BillKey].FreqKey;
            }
            ModelFrequency freq = null;
            char freqType = 'm';
            if (RepoFrequency.Freqs.ContainsKey(freqKey)) 
            {
                freq = RepoFrequency.Freqs[freqKey];
                freqType = freq.FreqType;
                if(freqType == 'd')
                {
                    radioButtonDaily.Checked = true;
                }
                else if (freqType == 'w')
                {
                    radioButtonWeekly.Checked = true;
                    checkBoxMonday.Checked = Convert.ToBoolean(listViewExistingBills.SelectedItems[0].SubItems[11].Text);
                    checkBoxTuesday.Checked = Convert.ToBoolean(listViewExistingBills.SelectedItems[0].SubItems[12].Text);
                    checkBoxWednesday.Checked = Convert.ToBoolean(listViewExistingBills.SelectedItems[0].SubItems[13].Text);
                    checkBoxThursday.Checked = Convert.ToBoolean(listViewExistingBills.SelectedItems[0].SubItems[14].Text);
                    checkBoxFriday.Checked = Convert.ToBoolean(listViewExistingBills.SelectedItems[0].SubItems[15].Text);
                    checkBoxSaturday.Checked = Convert.ToBoolean(listViewExistingBills.SelectedItems[0].SubItems[16].Text);
                    checkBoxSunday.Checked = Convert.ToBoolean(listViewExistingBills.SelectedItems[0].SubItems[17].Text);
                }
                else if(freqType == 'm')
                {
                    radioButtonMonthly.Checked = true;
                }
                else if (freqType == 'y')
                {
                    radioButtonYearly.Checked = true;
                }
            }
            PredictDates();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            List<ModelBill> Bills = PrepareDataForDatabase();
            RepoBills.EditBill(Bills, 'U');
            UpdateAfterDataBaseInsertion();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            List<ModelBill> Bills = PrepareDataForDatabase();
            RepoBills.EditBill(Bills, 'D');
            UpdateAfterDataBaseInsertion();
        }

        private void clearText()
        {
            comboBoxAccount.Text = "";
            comboBoxBillType.Text = "";
            comboBoxDescription.Text = "";
            textBoxAmount.Text = "";
            textBoxDescription.Text = "";
            textBoxPayOffTotal.Text = "";
            textBoxPercent.Text = "";
            dateTimePickerFromDate.Value = DateTime.Now;
            dateTimePickerFromDate.Value = DateTime.Now;
        }

        private ModelFrequency getCharFromRadioButtonFreq(ModelFrequency freq)
        {
            if (radioButtonWeekly.Checked)
            {
                freq.FreqType = 'w';
                freq.Monday = checkBoxMonday.Checked;
                freq.Tuesday = checkBoxTuesday.Checked;
                freq.Wednesday = checkBoxWednesday.Checked;
                freq.Thursday = checkBoxThursday.Checked;
                freq.Friday = checkBoxFriday.Checked;
                freq.Saturday = checkBoxSaturday.Checked;
                freq.Sunday = checkBoxSunday.Checked;
            }

            if (radioButtonDaily.Checked)
            {
                freq.FreqType = 'r';
            }
            if (radioButtonMonthly.Checked)
            {
                freq.FreqType = 'm';
            }
            if (radioButtonYearly.Checked)
            {
                freq.FreqType = 'y';
            }
            return freq;
        }
    }
}
