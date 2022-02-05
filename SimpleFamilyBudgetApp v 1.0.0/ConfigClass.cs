using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal static class ConfigClass
    {
        internal static Regex RegexMoney = new Regex(@"^[$]?[+-]?[0-9]{1,3}(?:[0-9]*(?:[.,][0-9]{2})?|(?:,[0-9]{3})*(?:\.[0-9]{2})?|(?:\.[0-9]{4})*(?:,[0-9]{2})?)$");

        internal static double CheckIfDouble(string doubleCheck, out double amount, TextBox textBoxAmount)
        {
            amount = double.MinValue;
            if (doubleCheck.Trim() != "")
            {
                if (RegexMoney.IsMatch(doubleCheck))
                {
                    amount = Convert.ToDouble(doubleCheck);
                }
                else
                {
                    MessageBox.Show("Please enter a dollar amount.");
                    textBoxAmount.Text = "";
                }
            }
            return amount;
        }
    }

    
}
