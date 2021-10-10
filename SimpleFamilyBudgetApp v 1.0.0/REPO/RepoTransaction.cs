using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    class RepoTransaction
    {
        internal static Dictionary<int, ModelTrans> Trans;
        internal static Dictionary<int, ModelTransType> TransTypes;


        /// <summary>
        /// Retrieve account types previously created available.
        /// </summary>
        #region Retrieve Account Types
        internal static void PrepareTransTypes()
        {
            string SQL = "SELECT * FROM TRANS_TYPE WITH(NOLOCK) ORDER BY TRANS_DESC";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = Command.ExecuteReader();
            TransTypes = new Dictionary<int, ModelTransType>();
            if (Reader != null)
            {
                while (Reader.Read())
                {
                    ModelTransType transType = new ModelTransType();
                    transType.TransTypeKey = Convert.ToInt32(Reader["TRANS_TYPE_KEY"]);
                    transType.TransDesc = Reader["TRANS_DESC"].ToString();
                    TransTypes.Add(transType.TransTypeKey, transType);
                }
            }
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
                string SQL = $"EXECUTE proc_TRANS_TYPE_EDITOR @TRANS_TYPE_KEY, @TRANS_TYPE, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter TransTypeKey = new SqlParameter("@TRANS_TYPE_KEY", transType.TransTypeKey);
                SqlParameter TransType = new SqlParameter("@TRANS_TYPE", transType.TransDesc);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);
                parameters.Add(TransTypeKey);
                parameters.Add(TransType);
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
            }
        }





        /// <summary>
        /// Grab data from database.
        /// </summary>
        internal static void PrepareTransData()
        {
            string SQL = "SELECT * FROM TRANSACTIONS WITH(NOLOCK) ORDER BY TRANS_DATE DESC";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = Command.ExecuteReader();
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
            Reader.Close();
        }

        internal static void RemoveAllTransactionsAssociatedWithUserKey(int userKey)
        {
            string SQL = "DELETE FROM TRANSACTION WHERE USER_KEY = @USER_KEY";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter UserKey = new SqlParameter("@USER_KEY", userKey);
            parameters.Add(UserKey);
            Command.Parameters.AddRange(parameters.ToArray());
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Deleting transactions tied to user: '{RepoUserEditor.users[userKey].userName}'. " + ex.Message);
            }
        }

        internal static void PrepareTransDataWithFilters(List<string> Accts, List<string> ExpenseTypes)
        {
            List<int> AcctKeys = new List<int>();
            List<int> ExpenseTypeKeys = new List<int>();

            foreach (string acct in Accts)
            {
                AcctKeys.Add(GetAcctKeyFromSelected(acct));
            }
            foreach (string expenseType in ExpenseTypes)
            {
                ExpenseTypeKeys.Add(GetTransTypeKeyFromSelected(expenseType));
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
            SqlDataReader Reader = Command.ExecuteReader();
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
            foreach (ModelTrans trans in Trans)
            {
                string SQL = $"EXECUTE proc_TRANS_EDITOR @TRANS_KEY, @TRANS_TYPE_KEY, @ACC_KEY, @AMOUNT, @TRANS_DESC, @TRANS_DATE, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter TransKey = new SqlParameter("@TRANS_KEY", trans.TransKey);
                SqlParameter TransTypeKey = new SqlParameter("@TRANS_TYPE_KEY", trans.TransTypeKey);
                SqlParameter Acctkey = new SqlParameter("@ACC_KEY", trans.AcctKey);
                SqlParameter Amount = new SqlParameter("@AMOUNT", trans.Amount);
                SqlParameter TransDesc = new SqlParameter("@TRANS_DESC", trans.TransDesc);
                SqlParameter TransDate = new SqlParameter("@TRANS_DATE", trans.TransDate);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);
                parameters.Add(TransKey);
                parameters.Add(TransTypeKey);
                parameters.Add(Acctkey);
                parameters.Add(Amount);
                parameters.Add(TransDesc);
                parameters.Add(TransDate);
                parameters.Add(editTypeParam);
                Command.Parameters.AddRange(parameters.ToArray());
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: editing Transaction '{trans.Amount}' amount for '{trans.TransDesc}' on {trans.TransDate}. " + ex.Message);
                }
            }
        }
    }
}
