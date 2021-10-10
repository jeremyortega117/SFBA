using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class ModelFrequency
    {
        public int FreqKey { get; set; }
        public char FreqType { get; set; } // 'd', 'w', 'm', 'y' {daily, weekly, monthly, yearly}
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}
