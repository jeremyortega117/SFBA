﻿using System;
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
    }
}