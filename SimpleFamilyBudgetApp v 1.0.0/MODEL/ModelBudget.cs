using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public class ModelBudget
    {
        public int ID { get; set; }
        public string TRANS_DESC { get; set; }
        public int AcctKey { get; set; }
        public double BudgetAmount { get; set; }
    }
    public class ModelBudgetTotals
    {
        public string TransDesc { get; set; }
        public double Amount { get; set; }
        public string NewVal { get; set; }
    }
}
