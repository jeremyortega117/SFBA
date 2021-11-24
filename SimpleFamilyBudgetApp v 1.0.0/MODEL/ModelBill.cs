using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ModelBill
    {
        public int BillKey { get; set; }
        public DateTime BillStartDate { get; set; }
        public DateTime BillEndDate { get; set; }
        public string BillDesc { get; set; }
        public char BillType { get; set; }
        public int AccKey { get; set; }
        public int FreqKey { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
        public decimal Remaining { get; set; }
        public decimal Interest { get; set; }
        public decimal TotalInterest { get; set; }

        public ModelFrequency Frequency = new ModelFrequency();
    }
}
