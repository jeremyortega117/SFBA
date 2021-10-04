using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    class TransactionRepo
    {
        internal static Dictionary<int, TransModel> Trans;
        internal static Dictionary<int, TransTypeModel> TransTypes;


        /// <summary>
        /// Retrieve account types previously created available.
        /// </summary>
        #region Retrieve Account Types
        internal static void PrepareTransTypes()
        {
            string SQL = "SELECT * FROM TRANS_TYPE WITH(NOLOCK) ORDER BY TRANS_DESC";
            SqlCommand Command = new SqlCommand(SQL, DBClass.DB);
            SqlDataReader Reader = Command.ExecuteReader();
            TransTypes = new Dictionary<int, TransTypeModel>();
            if (Reader != null)
            {
                while (Reader.Read())
                {
                    TransTypeModel transType = new TransTypeModel();
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
        internal static void EditTransType(List<TransTypeModel> TransTypes, char editType)
        {
            foreach (TransTypeModel transType in TransTypes)
            {
                string SQL = $"EXECUTE proc_TRANS_TYPE_EDITOR @TRANS_TYPE_KEY, @TRANS_TYPE, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, DBClass.DB);
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
            SqlCommand Command = new SqlCommand(SQL, DBClass.DB);
            SqlDataReader Reader = Command.ExecuteReader();
            Trans = new Dictionary<int, TransModel>();
            if (Reader != null)
            {
                while (Reader.Read())
                {
                    TransModel trans = new TransModel();
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
            var Accounts = BankAccountRepo.Accounts;
            foreach (int Key in Accounts.Keys)
            {
                string acctType = BankAccountRepo.AccountTypes[Accounts[Key].AcctTypeKey].AcctType;
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
        internal static void EditTrans(List<TransModel> Trans, char editType)
        {
            foreach (TransModel trans in Trans)
            {
                string SQL = $"EXECUTE proc_TRANS_EDITOR @TRANS_KEY, @TRANS_TYPE_KEY, @ACC_KEY, @AMOUNT, @TRANS_DESC, @TRANS_DATE, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, DBClass.DB);
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
