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
        internal static decimal Total = 0;

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
            "Interest",
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
                billHeaders.Add(Bills[key].Interest.ToString());
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
            "Principle",
            "Interest",
            "Account",
        };

        internal void AddDataToCycleListView(ListView lview, DateTime billFrom, DateTime billTo)
        {
            List<string[]> DataFormats = new List<string[]>();

            lview.Items.Clear();
            DateTime date = billFrom;

            BillsSummary = new Dictionary<string, decimal>();
            Total = 0;

            Dictionary<int, ModelBill> TempBillsTable = DuplicateBillValuesTemporarilyToWorkWith();

            if(TempBillsTable.Count <= 0)
            {
                return;
            }

            TimeSkipToBillStartDates(TempBillsTable);

            while (date < billTo)
            {

                UpdateTypicalIncomePayExpectations(date);

                foreach (int key in TempBillsTable.Keys)
                {
                    ModelBill Bill = TempBillsTable[key];

                    char billType = Bill.BillType;
                    if (TimeFrameDoesNotIncludeBill(billType, Bill, billFrom, billTo, date))
                    {
                        continue;
                    }

                    if (BillDateHasBeenFound(Bill, date))
                    {

                        decimal interest = 0, principle = 0;

                        char freq = Bill.Frequency.FreqType;
                        int interestDivisor = GetInterestDivisor(freq);


                        if(Bill.Interest != 0)
                            interest = GetInterestOnBill(Bill, interestDivisor);


                        principle = Bill.Amount - interest;


                        string desc = Bill.BillDesc.ToString();
                        UpdateBillTotalForPieChart(desc, Bill.Amount);


                        List<string> billHeaders = PrepareBillHeaderForMainBillListView(date, Bill, desc, billType, principle, interest);
                        DataFormats.Add(billHeaders.ToArray());


                        Bill.Total -= principle;
                        Total += principle;
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

        private void TimeSkipToBillStartDates(Dictionary<int, ModelBill> tempBillsTable)
        {
            throw new ArgumentException();
            // TODO: FOREACH ACCOUNT CHECK IF BILL LAST DAY IS LESS THAN START DATE OF BILL VIEW FIRST DAY
            //                             OR IF BILL FIRST DAY AFTER END DATE OF BILL VIEW LAST DAY
            //       IF SO : CONTINUE TO NEXT BILL

            // OTHERWISE:
            //      IF BILL START DATE IS BEFORE BILL VIEW START DATE
            //      THEN USE ALGORITHM TO CALULATE WHAT NEW INTEREST / PRINCIPLE / TOTAL WOULD BE UP TO BILLVIEW START DATE
        }

        private void UpdateTypicalIncomePayExpectations(DateTime date)
        {
            if(date.Day == 1 || date.Day == 15)
            {
                paycheckCount++;
            }
        }

        private List<string> PrepareBillHeaderForMainBillListView(DateTime date, ModelBill Bill, string desc, char billType, decimal principle, decimal interest)
        {
            List<string> billHeaders = new List<string>();
            billHeaders.Add(date.ToString("yyyy/MM/dd"));
            billHeaders.Add(string.Format("{0:C}", Bill.Amount));
            billHeaders.Add(desc);
            if (billType != 'p')
            {
                billHeaders.Add("-");
            }
            else
            {
                billHeaders.Add(string.Format("{0:C}", Bill.Total));
            }
            billHeaders.Add(string.Format("{0:C}", principle));
            billHeaders.Add(string.Format("{0:C}", interest));
            var acct = RepoBankAccount.Accounts[Bill.AccKey];
            var acctType = RepoBankAccount.AccountTypes[acct.AcctTypeKey];
            billHeaders.Add($"{acct.BankName}, {acct.AcctLastFour}, {acctType.AcctType}");
            return billHeaders;
        }

        private void UpdateBillTotalForPieChart(string desc, decimal amount)
        {

            if (!BillsSummary.ContainsKey(desc))
            {
                BillsSummary.Add(desc, amount);
            }
            else
            {
                BillsSummary[desc] += amount;
            }
        }

        private decimal GetInterestOnBill(ModelBill Bill, int interestDivisor)
        {
            decimal intRate = 0;
            intRate = Convert.ToDecimal(Bill.Interest) / 100;
            intRate /= interestDivisor;
            return Bill.Total * intRate;

        }

        private int GetInterestDivisor(char freq)
        {
            int interestDivisor = 0;
            if (freq == 'm') // Monthly
            {
                interestDivisor = 12;
            }
            else if (freq == 'd') // daily
            {
                interestDivisor = 365;
            }
            else if (freq == 'y') // yearly
            {
                interestDivisor = 1;
            }
            return interestDivisor;
        }

        private Dictionary<int, ModelBill> DuplicateBillValuesTemporarilyToWorkWith()
        {
             Dictionary<int, ModelBill> temp = new Dictionary<int, ModelBill>();
            foreach (int key in RepoBills.Bills.Keys)
            {
                if (!temp.ContainsKey(key))
                {
                    temp.Add(key, new ModelBill());
                }
                ModelBill tempBill = new ModelBill();
                var bill = RepoBills.Bills[key];
                tempBill.Total = bill.Total;
                tempBill.Amount = bill.Amount;
                tempBill.AccKey = bill.AccKey;
                tempBill.FreqKey = bill.FreqKey;
                tempBill.BillKey = bill.BillKey;
                tempBill.Interest = bill.Interest;
                tempBill.BillType = bill.BillType;
                tempBill.BillDesc = bill.BillDesc;
                tempBill.Remaining = bill.Remaining;
                tempBill.Frequency = bill.Frequency;
                tempBill.BillEndDate = bill.BillEndDate;
                tempBill.BillStartDate = bill.BillStartDate;
                temp[key] = tempBill;
            }
            return temp;
        }

        private bool TimeFrameDoesNotIncludeBill(char freq, ModelBill Bill, DateTime billFrom, DateTime billTo, DateTime date)
        {
            // Outside scope of 'Timeframe' or outside scope of 'Pay To Own'
            if((freq == 't' && (date < billFrom || date > billTo)) 
                || (freq == 'p' && (date < Bill.BillStartDate || date > Bill.BillEndDate))){
                return true;
            }
            return false;
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
