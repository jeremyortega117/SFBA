using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ListViewRepoBills
    {

        internal static Dictionary<string, decimal> BillsSummary;
        internal static Chart chart;
        internal static int paycheckCount = 0;

        public ListViewRepoBills(ListView lview, List<string> BillHeaderList)
        {
            ListViewHeadersClass prepHeader = new ListViewHeadersClass();
            prepHeader.PrepareListViewHeaders(lview, BillHeaderList);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public ListViewRepoBills(ListView lview, List<string> BillHeaderList, Chart Chart)
        {
            chart = Chart;
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

            bool[] boolArr = new bool[RepoBills.Bills.Count];


            DateTime startDateOfBillPayments = DateTime.MinValue;

            BillsSummary = new Dictionary<string, decimal>();
            paycheckCount = 0;

            while (date < billTo)
            {
                if(date.Day == 1 || date.Day == 15)
                {
                    paycheckCount++;
                }

                int billKeyIndex = 0;
                foreach (int key in RepoBills.Bills.Keys)
                {
                    char freq = Bills[key].BillType;
                    if (!boolArr[billKeyIndex] && freq == 'p')
                    {
                        boolArr[billKeyIndex] = true;
                        Bills[key].Remaining = Bills[key].Total;
                        startDateOfBillPayments = Bills[key].BillStartDate;
                        while (startDateOfBillPayments < date && Bills[key].Remaining > 0)
                        {
                            if (BillDateHasBeenFound(Bills[key], startDateOfBillPayments))
                            {
                                Bills[key].Remaining -= Bills[key].Amount;
                            }
                            startDateOfBillPayments = startDateOfBillPayments.AddDays(1);
                        }
                        if (Bills[key].Remaining <= 0)
                        {
                            continue;
                        }
                    }
                    billKeyIndex++;
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
                        string desc = Bills[key].BillDesc.ToString();
                        decimal amount = Bills[key].Amount;
                        if (!BillsSummary.ContainsKey(desc))
                        {
                            BillsSummary.Add(desc, amount);
                        }
                        else
                        {
                            BillsSummary[desc] += amount;
                        }

                        List<string> billHeaders = new List<string>();
                        billHeaders.Add(date.ToString("yyyy/MM/dd"));
                        billHeaders.Add(amount.ToString());
                        billHeaders.Add(desc);
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

            BuildPieChart();

            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }



        private void BuildPieChart()
        {
            List<string> names = new List<string>();

            foreach (var trans in BillsSummary)
            {
                names.Add(trans.Key + " " + string.Format("{0:C}", trans.Value));
            }

            chart.Series[0].ChartType = SeriesChartType.Pie;
            chart.Series[0].Points.DataBindXY(names, BillsSummary.Values);
            chart.Legends[0].Enabled = true;
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;

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
