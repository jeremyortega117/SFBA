using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class DBClass
    {
        internal static SqlConnection DB;
        internal static void PrepareConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DB = new SqlConnection(connectionString);
            DB.Open();
        }
    }
}