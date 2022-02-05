using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public partial class InvestmentInterestCalculator : Form
    {

        internal static double InitialAmount = 0;
        internal static double Total = 0;
        internal static double rate = 0;
        internal static DateTime date = DateTime.MinValue;
        internal static int months = 0;
        internal static bool DontChangeCheck = false;
        internal static int years = 0;
        internal static double runningPrinciple = 0;
        depositRate depRate = new depositRate();
        enum depositRate
        {
            OneTime
            ,Monthly
        }

        public InvestmentInterestCalculator()
        {
            InitializeComponent();
            DontChangeCheck = true;
            radioButtonMonthly.Checked = false;
            radioButtonYearly.Checked = true;
            DontChangeCheck = false;
        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            double amount;
            ConfigClass.CheckIfDouble(textBoxAmount.Text, out amount, textBoxAmount);
            if (amount != double.MinValue)
                InitialAmount = amount;
        }

        private void percentAnually_TextChanged(object sender, EventArgs e)
        {
            double amount;
            ConfigClass.CheckIfDouble(textRatePercent.Text, out amount, textRatePercent);
            if (amount != double.MinValue)
                rate = amount/100;
        }

        private void radioButtonYearly_CheckedChanged(object sender, EventArgs e)
        {
            if (!DontChangeCheck)
            {
                if(radioButtonYearly.Checked == true && textRatePercent.Text.Trim() != "")
                {
                    depRate = depositRate.OneTime;
                }
                else
                {
                    depRate = depositRate.Monthly;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private bool Calculatable()
        {
            bool compoundFrequency = false;
            bool rate = false;
            if (textBoxAmount.Text == "")
            {
                InitialAmount = 0;
            }
            if (!string.IsNullOrEmpty(textRatePercent.Text))
            {
                rate = true;
            }
            if (!string.IsNullOrEmpty(numericUpDown1.Value.ToString()))
            {
                compoundFrequency = true;
            }
            if (!string.IsNullOrEmpty(numericUpDown2.Value.ToString()))
            {
                compoundFrequency = true;
            }
            return compoundFrequency && rate;
        }

        private void MonthInterestRate(int totalMonths)
        {
            for (int i = 0; i < totalMonths; i++) {
                if (depRate == depositRate.OneTime)
                {
                    InitialAmount = InitialAmount + (InitialAmount * (rate / 12));
                }
                else if (depRate == depositRate.Monthly)
                {
                    runningPrinciple = runningPrinciple + Convert.ToDouble(textBoxAmount.Text);
                    InitialAmount = Convert.ToDouble(textBoxAmount.Text) + InitialAmount + (InitialAmount * (rate / 12));
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
                numericUpDown1.Value = 0;
            
            years = Convert.ToInt32(numericUpDown1.Value);

            FigureTotal();
        }

        private void FigureTotal()
        {
            InitialAmount = Convert.ToDouble(textBoxAmount.Text);
            runningPrinciple = Convert.ToDouble(textBoxAmount.Text);

            for (int i = 0; i < years; i++) 
                MonthInterestRate(12);
            
            if(months > 0)
                MonthInterestRate(months);

            textBoxPrinciple.Text = runningPrinciple.ToString("0.000");
            textBoxTotal.Text = InitialAmount.ToString("0.000");
            labelNet.Text = (InitialAmount - runningPrinciple).ToString("C3", CultureInfo.CurrentCulture);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value < 0)
                numericUpDown2.Value = 0;

            months = Convert.ToInt32(numericUpDown2.Value);

            FigureTotal();
        }

        private void radioButtonMonthly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrinciple_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
