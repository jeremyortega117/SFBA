using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public class ModelBankAccount
    {
        public int AcctKey { get; set; }
        public int AcctTypeKey { get; set; }
        public int UserKey { get; set; }
        public double Balance { get; set; }
        public string BankName { get; set; }
        public string AcctLastFour { get; set; }
        public int InterestFreq { get; set; }
        public double InterestPercent { get; set; }
    }

    public class ModelAccountType
    {
        public int AcctTypeKey { get; set; }
        public string AcctType { get; set; }
    }
}
