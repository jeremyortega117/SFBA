using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class HTMLLogic
    {

        internal static void runHTML(WebBrowser wb)
        {
            string path = @"C:\Users\JPOje\source\repos\SFBA\SimpleFamilyBudgetApp v 1.0.0\WEB_BROWSER\PieChart.html";

            string html = File.ReadAllText(path);

            wb.DocumentText = "0";
            wb.Document.OpenNew(true);
            wb.Document.Write(html);
            wb.Refresh();
        }
    }
}
