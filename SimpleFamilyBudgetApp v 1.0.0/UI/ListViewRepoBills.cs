using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepoBills
    {


        public ListViewRepoBills(ListView lview, List<string> BillHeaderList)
        {
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lview, BillHeaderList);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        internal static List<string> BillHeaderList = new List<string>() 
        { 
            "BK", 
            "Start Date", 
            "End Date", 
            "Bill Description", 
            "Amount", 
            "Total",
            "Remaining",
            "Bill Type", 
            "Account", 
            "Frequency", 
            "Mon", 
            "Tues", 
            "Wed", 
            "Thur", 
            "Fri", 
            "Sat", 
            "Sun" 
        };


        internal void AddDataToListView(ListView lview)
        {
            var Bills = RepoBills.Bills;
            lview.Items.Clear();
            foreach (int key in Bills.Keys)
            {
                List<string> billHeaders = new List<string>();

                billHeaders.Add(Bills[key].BillKey.ToString());
                billHeaders.Add(Bills[key].BillStartDate.ToString("MM/dd/yyyy"));
                billHeaders.Add(Bills[key].BillEndDate.ToString("MM/dd/yyyy"));
                billHeaders.Add(Bills[key].BillDesc.ToString());
                billHeaders.Add(Bills[key].Amount.ToString());
                billHeaders.Add(Bills[key].Total.ToString());
                billHeaders.Add(Bills[key].Remaining.ToString());
                billHeaders.Add(Bills[key].BillType.ToString());

                var acct = RepoBankAccount.Accounts[Bills[key].AccKey];
                var acctType = RepoBankAccount.AccountTypes[acct.AcctTypeKey];
                billHeaders.Add($"{acct.BankName}, {acct.AcctLastFour}, {acctType.AcctType}");

                billHeaders.Add(Bills[key].Frequency.FreqType.ToString());
                billHeaders.Add(Bills[key].Frequency.Monday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Tuesday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Wednesday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Thursday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Friday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Saturday ? "X" : "");
                billHeaders.Add(Bills[key].Frequency.Sunday ? "X" : "");


                ListViewItem lvi = new ListViewItem(billHeaders.ToArray());
                lview.Items.Add(lvi);
            }
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }



        internal static List<string> BillCycleHeaderList = new List<string>()
        {
            "Bill Date",
            "Amount Due",
            "Bill Description",
            "Amount Left ",
            "Account",
        };

        internal void AddDataToCycleListView(ListView lview, DateTime billFrom, DateTime billTo)
        {
            List<string[]> DataFormats = new List<string[]>();

            var Bills = RepoBills.Bills;

            lview.Items.Clear();
            DateTime date = billFrom;
            DateTime startDateOfBillPayments = DateTime.MinValue;

            while (date < billTo)
            {
                foreach (int key in RepoBills.Bills.Keys)
                {
                    char freq = Bills[key].BillType;

                    if (startDateOfBillPayments == DateTime.MinValue && freq == 'p')
                    {
                        Bills[key].Remaining = Bills[key].Total;
                        startDateOfBillPayments = Bills[key].BillStartDate;
                        while (startDateOfBillPayments < date && Bills[key].Remaining > 0)
                        {
                            Bills[key].Remaining -= Bills[key].Amount;
                            startDateOfBillPayments.AddDays(1);
                        }
                        if(Bills[key].Remaining <= 0)
                        {
                            continue;
                        }
                    }

                    if ((freq == 't' && (date < billFrom || date > billTo)) || (freq == 'p' && (date < Bills[key].BillStartDate || date > Bills[key].BillEndDate)))
                    {
                        continue;
                    }
                    else if(freq == 'p' && Bills[key].Remaining <= 0)
                    {
                        continue;
                    }

                    if (BillDateHasBeenFound(Bills[key], date))
                    {
                        List<string> billHeaders = new List<string>();
                        billHeaders.Add(date.ToString("yyyy/MM/dd"));
                        billHeaders.Add(Bills[key].Amount.ToString());
                        billHeaders.Add(Bills[key].BillDesc.ToString());
                        if (freq != 'p')
                        {
                            billHeaders.Add("-");
                        }
                        else
                        {
                            billHeaders.Add(Bills[key].Remaining.ToString());
                        }

                        var acct = RepoBankAccount.Accounts[Bills[key].AccKey];
                        var acctType = RepoBankAccount.AccountTypes[acct.AcctTypeKey];
                        billHeaders.Add($"{acct.BankName}, {acct.AcctLastFour}, {acctType.AcctType}");

                        DataFormats.Add(billHeaders.ToArray());
                        if(freq == 'p')
                        {
                            Bills[key].Remaining -= Bills[key].Amount;
                        }
                    }
                }
                date = date.AddDays(1);
            }

            foreach (string[] arr in DataFormats)
            {
                ListViewItem lvi = new ListViewItem(arr);
                lview.Items.Add(lvi);
            }

            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        /// <summary>
        /// Find out if the date has been found.
        /// </summary>
        /// <returns></returns>
        private bool BillDateHasBeenFound(ModelBill modelBill, DateTime date)
        {
            DateTime fromDate = modelBill.BillStartDate;

            char c = modelBill.BillType;

            char freq = modelBill.Frequency.FreqType;
            bool M, T, W, TH, F, S, Su;
            M = modelBill.Frequency.Monday;
            T = modelBill.Frequency.Tuesday;
            W = modelBill.Frequency.Wednesday;
            TH = modelBill.Frequency.Thursday;
            F = modelBill.Frequency.Friday;
            S = modelBill.Frequency.Saturday;
            Su = modelBill.Frequency.Sunday;


            if (freq == 'm')
            {
                if (fromDate.Day == date.Day)
                {
                    return true;
                }
            }
            else if (freq == 'w')
            {
                if (date.DayOfWeek == DayOfWeek.Monday && M)
                {
                    return true;
                }
                if (date.DayOfWeek == DayOfWeek.Tuesday && T)
                {
                    return true;
                }
                if (date.DayOfWeek == DayOfWeek.Wednesday && W)
                {
                    return true;
                }
                if (date.DayOfWeek == DayOfWeek.Thursday && TH)
                {
                    return true;
                }
                if (date.DayOfWeek == DayOfWeek.Friday && F)
                {
                    return true;
                }
                if (date.DayOfWeek == DayOfWeek.Saturday && S)
                {
                    return true;
                }
                if (date.DayOfWeek == DayOfWeek.Sunday && Su)
                {
                    return true;
                }
            }
            else if( freq == 'd')
            {
                return true;
            }
            else if (freq == 'y')
            {
                if (fromDate.Day == date.Day && fromDate.Month == date.Month)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
