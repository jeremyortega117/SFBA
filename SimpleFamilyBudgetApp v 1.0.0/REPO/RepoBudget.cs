﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public class RepoBudget
    {

        internal static Dictionary<int, ModelBudget> BudgetByID;
        internal static Dictionary<string, double> BudgetByString;

        internal static Dictionary<string, ModelBudgetTotals> BudgetTotalsByID;

        /// <summary>
        /// Retrieve account types previously created available.
        /// </summary>
        #region Retrieve Account Types
        internal static void PrepareBudgetPlan()
        {
            BudgetByID = new Dictionary<int, ModelBudget>();
            BudgetByString = new Dictionary<string, double>();
            string SQL = "SELECT * FROM BUDGET WITH(NOLOCK) ORDER BY TRANS_DESC";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader();
                if (Reader != null)
                {
                    while (Reader.Read())
                    {
                        ModelBudget Budget = new ModelBudget();
                        Budget.ID = Convert.ToInt32(Reader["TRANS_TYPE_KEY"]);
                        Budget.TRANS_DESC = Convert.ToString(Reader["TRANS_DESC"]);
                        Budget.AcctKey = Convert.ToInt32(Reader["ACCT_KEY"]);
                        Budget.BudgetAmount = Convert.ToDouble(Reader["BUDGET_AMT"]);
                        BudgetByID.Add(Budget.ID, Budget);
                        if (!BudgetByString.ContainsKey(Budget.TRANS_DESC))
                            BudgetByString.Add(Budget.TRANS_DESC, Budget.BudgetAmount);
                        else
                            BudgetByString[Budget.TRANS_DESC] += Budget.BudgetAmount;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: retrieving Trans Type Information. " + ex.Message);
            }
            Command.Dispose();
            Reader.Close();
        }
        #endregion



        /// <summary>
        /// Retrieve account types previously created available.
        /// </summary>
        #region Retrieve Account Types
        internal static void PrepareBudgetData()
        {
            BudgetTotalsByID = new Dictionary<string, ModelBudgetTotals>();

            List<string> TransDescs = new List<string>();

            foreach (string transDesc in RepoTransaction.MapTransTypesByIncluded)
                TransDescs.Add($"'{transDesc}'");

            StringBuilder Builder = new StringBuilder();
            Builder.AppendLine("select");
            Builder.AppendLine("    TT.TRANS_DESC");
            Builder.AppendLine("	,SUM(T.AMOUNT) as [Amount]");
            Builder.AppendLine("	,TT.TRANS_SIGN");
            Builder.AppendLine("from");
            Builder.AppendLine("    TRANSACTIONS T with(nolock)");
            Builder.AppendLine("    JOIN TRANS_TYPE TT with(nolock) on TT.TRANS_TYPE_KEY = T.TRANS_TYPE_KEY");
            Builder.AppendLine("WHERE");
            Builder.AppendLine($"    TT.TRANS_DESC in ({string.Join(",", TransDescs)})");
            Builder.AppendLine("group by");
            Builder.AppendLine("    TT.TRANS_DESC, TT.TRANS_SIGN");
            Builder.AppendLine("order by");
            Builder.AppendLine("    TT.TRANS_DESC");
            string SQL = Builder.ToString();
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader();
                if (Reader != null)
                {
                    while (Reader.Read())
                    {
                        ModelBudgetTotals Budget = new ModelBudgetTotals();
                        Budget.TransDesc = Convert.ToString(Reader["TRANS_DESC"]);
                        Budget.Amount = Convert.ToDouble(Reader["AMOUNT"]);
                        Budget.posNeg = Reader["TRANS_SIGN"].ToString();
                        BudgetTotalsByID.Add(Budget.TransDesc, Budget);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: retrieving Trans Type Information. " + ex.Message);
            }
            Command.Dispose();
            Reader.Close();
        }
        #endregion




        /// <summary>
        /// Add New Account Type
        /// </summary>
        internal static void EditTransMap(List<ModelMapExpenseTypes> Maps, char editType)
        {
            foreach (ModelMapExpenseTypes map in Maps)
            {
                string SQL = $"EXECUTE proc_MAP_EXPENSE_TYPES @MAP_ID, @ORIG_VAL, @NEW_VALUE, @COLOR, @INCLUDE_EXPENSE, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter MapId = new SqlParameter("@MAP_ID", map.MapId);
                SqlParameter origVal = new SqlParameter("@ORIG_VAL", map.OrigVal);
                SqlParameter NewVal = new SqlParameter("@NEW_VALUE", map.NewVal);
                SqlParameter color = new SqlParameter("@COLOR", map.ColorValue);
                SqlParameter IncludeExpense = new SqlParameter("@INCLUDE_EXPENSE", map.IncludeExpense);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);
                parameters.Add(MapId);
                parameters.Add(origVal);
                parameters.Add(NewVal);
                parameters.Add(color);
                parameters.Add(IncludeExpense);
                parameters.Add(editTypeParam);
                Command.Parameters.AddRange(parameters.ToArray());
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: Adding/Editing Mapping ExpenseType Type: '{map.OrigVal}' to '{map.NewVal}'. " + ex.Message);
                }
                Command.Dispose();
            }

        }
    }
}