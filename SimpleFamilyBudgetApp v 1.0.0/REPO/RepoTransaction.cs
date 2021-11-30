using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    class RepoTransaction
    {
        internal static HashSet<string> MapTransNew;
        internal static HashSet<string> MapTransOrig;
        internal static Dictionary<int, ModelMapExpenseTypes> MapTransTypesByKey;
        internal static Dictionary<string, string> MapTransTypes;
        internal static Dictionary<int, ModelTrans> Trans;
        internal static Dictionary<int, ModelTransType> TransTypes;
        internal static Dictionary<DateTime, List<ModelTrans>> compareTransByDate;
        internal static bool IgnoreDups = false;
        internal static char editBal = 'Y';



        /// <summary>
        /// Retrieve account types previously created available.
        /// </summary>
        #region Retrieve Account Types
        internal static void PrepareTransMap()
        {
            string SQL = "SELECT * FROM MAP_EXPENSE_TYPES WITH(NOLOCK) ORDER BY ORIG_VAL";
            MapTransOrig = new HashSet<string>();
            MapTransNew = new HashSet<string>();
            MapTransTypes = new Dictionary<string, string>();
            MapTransTypesByKey = new Dictionary<int, ModelMapExpenseTypes>();
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader();
                if (Reader != null)
                {
                    while (Reader.Read())
                    {
                        ModelMapExpenseTypes mapTo = new ModelMapExpenseTypes();
                        mapTo.MapId = Convert.ToInt32(Reader["MAP_ID"]);
                        mapTo.OrigVal = Reader["ORIG_VAL"].ToString();
                        mapTo.NewVal = Reader["NEW_VALUE"].ToString();

                        if (!MapTransTypesByKey.ContainsKey(mapTo.MapId))
                        {
                            MapTransTypesByKey.Add(mapTo.MapId, mapTo);
                        }

                        if (!MapTransTypes.ContainsKey(mapTo.OrigVal) && mapTo.OrigVal != "")
                        {
                            MapTransTypes.Add(mapTo.OrigVal, mapTo.NewVal);
                        }

                        if (!MapTransOrig.Contains(mapTo.OrigVal) && mapTo.OrigVal != "")
                        {
                            MapTransOrig.Add(mapTo.OrigVal);
                        }

                        if (!MapTransNew.Contains(mapTo.NewVal))
                        {
                            MapTransNew.Add(mapTo.NewVal);
                        }

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
                string SQL = $"EXECUTE proc_MAP_EXPENSE_TYPES @MAP_ID, @ORIG_VAL, @NEW_VALUE, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter MapId = new SqlParameter("@MAP_ID", map.MapId);
                SqlParameter origVal = new SqlParameter("@ORIG_VAL", map.OrigVal);
                SqlParameter NewVal = new SqlParameter("@NEW_VALUE", map.NewVal);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);
                parameters.Add(MapId);
                parameters.Add(origVal);
                parameters.Add(NewVal);
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



        /// <summary>
        /// Retrieve account types previously created available.
        /// </summary>
        #region Retrieve Account Types
        internal static void PrepareTransTypes()
        {
            string SQL = "SELECT * FROM TRANS_TYPE WITH(NOLOCK) ORDER BY TRANS_DESC";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader();
                TransTypes = new Dictionary<int, ModelTransType>();
                if (Reader != null)
                {
                    while (Reader.Read())
                    {
                        ModelTransType transType = new ModelTransType();
                        transType.TransTypeKey = Convert.ToInt32(Reader["TRANS_TYPE_KEY"]);
                        transType.TransDesc = Reader["TRANS_DESC"].ToString();
                        transType.TransSign = Convert.ToChar(Reader["TRANS_SIGN"]);
                        TransTypes.Add(transType.TransTypeKey, transType);
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
        internal static void EditTransType(List<ModelTransType> TransTypes, char editType)
        {
            foreach (ModelTransType transType in TransTypes)
            {
                string SQL = $"EXECUTE proc_TRANS_TYPE_EDITOR @TRANS_TYPE_KEY, @TRANS_TYPE, @TRANS_SIGN, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter TransTypeKey = new SqlParameter("@TRANS_TYPE_KEY", transType.TransTypeKey);
                SqlParameter TransType = new SqlParameter("@TRANS_TYPE", transType.TransDesc);
                SqlParameter TransSign = new SqlParameter("@TRANS_SIGN", transType.TransSign);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);
                parameters.Add(TransTypeKey);
                parameters.Add(TransType);
                parameters.Add(TransSign);
                parameters.Add(editTypeParam);
                Command.Parameters.AddRange(parameters.ToArray());
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: Adding/Editing Account Type: '{transType.TransDesc}'. " + ex.Message);
                }
                Command.Dispose();
            }
        }


        /// <summary>
        /// Grab data from database.
        /// </summary>
        internal static void PrepareTransData()
        {
            string SQL = "SELECT * FROM TRANSACTIONS WITH(NOLOCK) ORDER BY TRANS_DATE DESC";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader();
                Trans = new Dictionary<int, ModelTrans>();
                compareTransByDate = new Dictionary<DateTime, List<ModelTrans>>();
                if (Reader != null)
                {
                    while (Reader.Read())
                    {
                        ModelTrans trans = new ModelTrans();
                        trans.TransDate = Convert.ToDateTime(Reader["TRANS_DATE"]);
                        trans.TransDesc = Reader["TRANS_DESC"].ToString();
                        trans.TransKey = Convert.ToInt32(Reader["TRANS_KEY"]);
                        trans.Amount = Convert.ToDouble(Reader["AMOUNT"]);
                        trans.TransTypeKey = Convert.ToInt32(Reader["TRANS_TYPE_KEY"]);
                        trans.AcctKey = Convert.ToInt32(Reader["ACC_KEY"]);
                        if (!compareTransByDate.ContainsKey(trans.TransDate))
                        {
                            compareTransByDate.Add(trans.TransDate, new List<ModelTrans>());
                        }
                        compareTransByDate[trans.TransDate].Add(trans);
                        Trans.Add(trans.TransKey, trans);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: selecting transactions. " + ex.Message);
            }
            Command.Dispose();
            Reader.Close();
        }

        internal static void RemoveAllTransactionsAssociatedWithUserKey(int AcctKey)
        {
            string SQL = "DELETE FROM TRANSACTIONS WHERE ACC_KEY = @ACCT_KEY";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter UserKey = new SqlParameter("@ACCT_KEY", AcctKey);
            parameters.Add(UserKey);
            Command.Parameters.AddRange(parameters.ToArray());
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Deleting transactions tied to Account: '{RepoBankAccount.Accounts[AcctKey].AcctKey}'. " + ex.Message);
            }
            Command.Dispose();
        }

        internal static void PrepareTransDataWithFilters(List<string> Accts, List<string> ExpenseTypes)
        {
            List<int> AcctKeys = new List<int>();
            List<int> ExpenseTypeKeys = new List<int>();

            foreach (string acct in Accts)
            {
                int Key = GetAcctKeyFromSelected(acct);
                if (!AcctKeys.Contains(Key))
                {
                    AcctKeys.Add(Key);
                }
            }
            foreach (string expenseType in ExpenseTypes)
            {
                int Key = GetTransTypeKeyFromSelected(expenseType);
                if (!ExpenseTypeKeys.Contains(Key))
                {
                    ExpenseTypeKeys.Add(Key);
                }
            }

            if(AcctKeys.Count == 0 || ExpenseTypeKeys.Count == 0)
            {
                Trans = new Dictionary<int, ModelTrans>();
                return;
            }

            StringBuilder Builder = new StringBuilder();
            Builder.AppendLine("SELECT * ");
            Builder.AppendLine("FROM TRANSACTIONS WITH(NOLOCK)");
            if(AcctKeys.Count > 0)
                Builder.AppendLine($"WHERE ACC_KEY IN ({string.Join(",", AcctKeys.ToArray())})");
            if(ExpenseTypeKeys.Count > 0)
                Builder.AppendLine($"AND TRANS_TYPE_KEY IN ({string.Join(",", ExpenseTypeKeys.ToArray())})");
            if(AcctKeys.Count > 0 || ExpenseTypeKeys.Count > 0)
                Builder.AppendLine("ORDER BY TRANS_DATE DESC");
            string SQL = Builder.ToString();
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader();
                Trans = new Dictionary<int, ModelTrans>();
                if (Reader != null)
                {
                    while (Reader.Read())
                    {
                        ModelTrans trans = new ModelTrans();
                        trans.TransDate = Convert.ToDateTime(Reader["TRANS_DATE"]);
                        trans.TransDesc = Reader["TRANS_DESC"].ToString();
                        trans.TransKey = Convert.ToInt32(Reader["TRANS_KEY"]);
                        trans.Amount = Convert.ToDouble(Reader["AMOUNT"]);
                        trans.TransTypeKey = Convert.ToInt32(Reader["TRANS_TYPE_KEY"]);
                        trans.AcctKey = Convert.ToInt32(Reader["ACC_KEY"]);
                        Trans.Add(trans.TransKey, trans);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Retrieving filtered transactions. " + ex.Message);
            }
            Command.Dispose();
            Reader.Close();
        }

        internal static int GetTransTypeKeyFromSelected(string text)
        {
            foreach(int Key in TransTypes.Keys)
            {
                if(TransTypes[Key].TransDesc == text)
                {
                    return Key;
                }
            }
            return -1;
        }

        internal static int GetAcctKeyFromSelected(string text)
        {
            var Accounts = RepoBankAccount.Accounts;
            foreach (int Key in Accounts.Keys)
            {
                string acctType = RepoBankAccount.AccountTypes[Accounts[Key].AcctTypeKey].AcctType;
                if (text == $"{Accounts[Key].BankName}, {Accounts[Key].AcctLastFour}, {acctType}")
                {
                    return Key;
                }
            }
            return -1;
        }

       

        /// <summary>
        /// Edit User Record.
        /// 'A' : Add
        /// 'D' : Delete
        /// 'U' : Update
        /// </summary>
        /// <param name="users"></param>
        internal static void EditTrans(List<ModelTrans> Trans, char editType)
        {
            bool continueRegardlessDups = false;
            foreach (ModelTrans trans in Trans)
            {
                bool skip = false;
                if (compareTransByDate.ContainsKey(trans.TransDate) && !continueRegardlessDups && editType == 'A')
                {
                    foreach (ModelTrans mod in compareTransByDate[trans.TransDate])
                    {
                        if(mod.TransDesc == trans.TransDesc &&
                            mod.AcctKey == trans.AcctKey &&
                            mod.Amount == trans.Amount &&
                            mod.TransTypeKey == trans.TransTypeKey)
                        {
                            if (IgnoreDups)
                            {
                                skip = true;
                                break;
                            }

                            DialogResult dialogResult = MessageBox.Show($"Do you want to keep duplicate record? : ({mod.TransDate.ToString("MM/dd/yyyy")} '{TransTypes[mod.TransTypeKey].TransDesc}' on account '{RepoBankAccount.RetrieveAcctSummaryFromAcctKey(mod.AcctKey)}' for amount {string.Format("C:0",mod.Amount)})", "Duplicate", MessageBoxButtons.YesNo);

                            if (dialogResult == DialogResult.No && Trans.Count > 1)
                            {
                                DialogResult dialogResult2 = MessageBox.Show($"\"yes\" continue to check for duplicates : \"no\" don't notify any remaining duplicates : \"cancel\" stop importing file.", "Stop Importing File", MessageBoxButtons.YesNoCancel);
                                if (dialogResult2 == DialogResult.Abort)
                                {
                                    return;
                                }
                                else if(dialogResult2 == DialogResult.No)
                                {
                                    continueRegardlessDups = true;
                                    break;
                                }
                                else if (dialogResult2 == DialogResult.Yes)
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    if (skip)
                    {
                        continue;
                    }
                }


                string SQL = $"EXECUTE proc_TRANS_EDITOR @TRANS_KEY, @TRANS_TYPE_KEY, @ACC_KEY, @AMOUNT, @TRANS_DESC, @TRANS_DATE, @EDIT_TYPE, @EDIT_BAL";
                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                Command.Parameters.Add("@TRANS_KEY", SqlDbType.Int).Value = trans.TransKey;
                Command.Parameters.Add("@TRANS_TYPE_KEY", SqlDbType.Int).Value = trans.TransTypeKey;
                Command.Parameters.Add("@ACC_KEY", SqlDbType.Int).Value = trans.AcctKey;
                Command.Parameters.Add("@AMOUNT", SqlDbType.Money).Value = trans.Amount;
                Command.Parameters.Add("@TRANS_DESC", SqlDbType.Char).Value = trans.TransDesc;
                Command.Parameters.Add("@TRANS_DATE", SqlDbType.DateTime).Value = trans.TransDate;
                Command.Parameters.Add("@EDIT_TYPE", SqlDbType.Char).Value = editType;
                Command.Parameters.Add("@EDIT_BAL", SqlDbType.Char).Value = editBal;
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: editing Transaction '{trans.Amount}' amount for '{trans.TransDesc}' on {trans.TransDate}. " + ex.Message);
                }
                Command.Dispose();
            }
        }
    }
}
