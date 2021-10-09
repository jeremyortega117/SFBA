using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public class RepoBankAccount
    {
        internal static Dictionary<int, ModelBankAccount> Accounts;
        internal static Dictionary<int, ModelAccountType> AccountTypes;


        /// <summary>
        /// Retrieve account types previously created available.
        /// </summary>
        #region Retrieve Account Types
        internal static void PrepareAccountTypes()
        {
            string SQL = "SELECT * FROM ACCOUNT_TYPE WITH(NOLOCK) ORDER BY ACC_TYPE";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = Command.ExecuteReader();
            AccountTypes = new Dictionary<int, ModelAccountType>();
            if (Reader != null)
            {
                while (Reader.Read())
                {
                    ModelAccountType acctType = new ModelAccountType();
                    acctType.AcctTypeKey = Convert.ToInt32(Reader["ACC_TYPE_KEY"]);
                    acctType.AcctType = Reader["ACC_TYPE"].ToString();
                    AccountTypes.Add(acctType.AcctTypeKey, acctType);
                }
            }
            Reader.Close();
        }
        #endregion

        /// <summary>
        /// Add New Account Type
        /// </summary>
        internal static void EditAccountType(List<ModelAccountType> AcctTypes, char editType)
        {
            foreach (ModelAccountType acctType in AcctTypes)
            {
                string SQL = $"EXECUTE proc_ACCT_TYPE_EDITOR @ACC_TYPE_KEY, @ACC_TYPE, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter AccTypeKey = new SqlParameter("@ACC_TYPE_KEY", acctType.AcctTypeKey);
                SqlParameter AcctType = new SqlParameter("@ACC_TYPE", acctType.AcctType);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);
                parameters.Add(AccTypeKey);
                parameters.Add(AcctType);
                parameters.Add(editTypeParam);
                Command.Parameters.AddRange(parameters.ToArray());
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: Adding/Editing Account Type: '{acctType.AcctType}'. " + ex.Message);
                }
            }
        }

        internal static int RetrieveAcctTypeKeyFromName(string acctType)
        {
            foreach(int Key in AccountTypes.Keys)
            {
                ModelAccountType at = AccountTypes[Key];
                if(at.AcctType == acctType)
                {
                    return Key;
                }
            }
            return -1;
        }





        /// <summary>
        /// Grab data from database.
        /// </summary>
        internal static void PrepareAcctEditorData()
        {
            string SQL = "SELECT * FROM ACCOUNT WITH(NOLOCK) ORDER BY BANK_NAME, ACC_LAST_FOUR";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = Command.ExecuteReader();
            Accounts = new Dictionary<int, ModelBankAccount>();
            if (Reader != null)
            {
                while (Reader.Read())
                {
                    ModelBankAccount acct = new ModelBankAccount();
                    acct.AcctKey = Convert.ToInt32(Reader["ACC_KEY"]);
                    acct.AcctTypeKey = Convert.ToInt32(Reader["ACC_TYPE_KEY"]);
                    acct.UserKey = Convert.ToInt32(Reader["USER_KEY"]);
                    acct.Balance = Convert.ToDouble(Reader["BAL"]);
                    acct.BankName = Reader["BANK_NAME"].ToString();
                    acct.AcctLastFour = Reader["ACC_LAST_FOUR"].ToString();
                    acct.InterestFreq = Convert.ToInt32(Reader["INT_FREQ_DAYS"]);
                    acct.InterestPercent = Convert.ToDouble(Reader["INT_PERC"]);
                    Accounts.Add(acct.AcctKey, acct);
                }
            }
            Reader.Close();
        }

        /// <summary>
        /// Edit User Record.
        /// 'A' : Add
        /// 'D' : Delete
        /// 'U' : Update
        /// </summary>
        /// <param name="users"></param>
        internal static void EditAccts(List<ModelBankAccount> Accounts, char editType)
        {
            foreach (ModelBankAccount account in Accounts)
            {
                string SQL = $"EXECUTE proc_ACCT_EDITOR @ACC_KEY, @ACC_TYPE_KEY, @USER_KEY, @BAL, @BANK_NAME, @ACC_LAST_FOUR, @INT_FREQ_DAYS, @INT_PERC, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter Acctkey = new SqlParameter("@ACC_KEY", account.AcctKey);
                SqlParameter AccTypeKey = new SqlParameter("@ACC_TYPE_KEY", account.AcctTypeKey);
                SqlParameter UserKey = new SqlParameter("@USER_KEY", account.UserKey);
                SqlParameter Bal = new SqlParameter("@BAL", account.Balance);
                SqlParameter BankName = new SqlParameter("@BANK_NAME", account.BankName);
                SqlParameter AcctLastFour = new SqlParameter("@ACC_LAST_FOUR", account.AcctLastFour);
                SqlParameter IntFreq = new SqlParameter("@INT_FREQ_DAYS", account.InterestFreq);
                SqlParameter IntPerc = new SqlParameter("@INT_PERC", account.InterestPercent);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);
                parameters.Add(Acctkey);
                parameters.Add(AccTypeKey);
                parameters.Add(UserKey);
                parameters.Add(Bal);
                parameters.Add(BankName);
                parameters.Add(AcctLastFour);
                parameters.Add(IntFreq);
                parameters.Add(IntPerc);
                parameters.Add(editTypeParam);
                Command.Parameters.AddRange(parameters.ToArray());
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: editing Account '{account.BankName}' ''{account.AcctLastFour}'. " + ex.Message);
                }
            }
        }
    }
}
