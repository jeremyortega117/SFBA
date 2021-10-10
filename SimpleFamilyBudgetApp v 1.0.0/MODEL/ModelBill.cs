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
        public string DillDesc { get; set; }
        public string BillType { get; set; }
        public int AccKey { get; set; }
        public int FreqKey { get; set; }
        public decimal Amount { get; set; }
    }
}
