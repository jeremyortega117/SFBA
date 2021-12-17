using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ModelTrans
    {
        public int TransKey { get; set; }
        public int TransTypeKey { get; set; }
        public int AcctKey { get; set; }
        public double Amount { get; set; }
        public string TransDesc { get; set; }
        public DateTime TransDate { get; set; }
    }

    internal class ModelTransType
    {
        public int TransTypeKey { get; set; }
        public string TransDesc { get; set; }
        public char TransSign { get; set; }
    }

    internal class ModelMapExpenseTypes
    {
        public int MapId { get; set; }
        public string OrigVal { get; set; }
        public string NewVal { get; set; }
        public string ColorValue { get; set; }
        public bool IncludeExpense { get; set; }
        public string TransDesc { get; set; }
        public char TransSign { get; set; }
        public int TransTypeKey { get; set; }
    }
}
