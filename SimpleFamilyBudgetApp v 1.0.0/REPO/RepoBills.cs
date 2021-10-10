using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class RepoBills
    {
        internal static Dictionary<int, ModelBill> Bills;


        /// <summary>
        /// Grab data from database.
        /// </summary>
        internal static void PrepareBillEditorData()
        {
            StringBuilder Builder = new StringBuilder();
            Builder.AppendLine("SELECT ");
            Builder.AppendLine("	F.FREQ_KEY, ");
            Builder.AppendLine("	F.FREQ_TYPE, ");
            Builder.AppendLine("	F.MONDAY, ");
            Builder.AppendLine("	F.TUESDAY, ");
            Builder.AppendLine("	F.WEDNESDAY, ");
            Builder.AppendLine("	F.THURSDAY, ");
            Builder.AppendLine("	F.FRIDAY, ");
            Builder.AppendLine("	F.SATURDAY, ");
            Builder.AppendLine("	F.SUNDAY,");
            Builder.AppendLine("	B.BILL_KEY, ");
            Builder.AppendLine("	B.BILL_START_DATE, ");
            Builder.AppendLine("	B.BILL_END_DATE, ");
            Builder.AppendLine("	B.BILL_DESC, ");
            Builder.AppendLine("	B.BILL_TYPE, ");
            Builder.AppendLine("	B.ACC_KEY, ");
            Builder.AppendLine("	B.AMOUNT,");
            Builder.AppendLine("	ISNULL(B.TOTAL, 0) as [TOTAL]");
            Builder.AppendLine("FROM ");
            Builder.AppendLine("	BILL B WITH(NOLOCK)");
            Builder.AppendLine("	JOIN FREQUENCY F WITH(NOLOCK) on F.FREQ_KEY = B.FREQ_KEY");
            string SQL = Builder.ToString();
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader();
                if (Reader != null)
                {
                    Bills = new Dictionary<int, ModelBill>();
                    while (Reader.Read())
                    {
                        ModelBill bill = new ModelBill();
                        bill.FreqKey = Convert.ToInt32(Reader["FREQ_KEY"]);
                        bill.BillKey = Convert.ToInt32(Reader["BILL_KEY"]);
                        bill.BillStartDate = Convert.ToDateTime(Reader["BILL_START_DATE"]);
                        bill.BillEndDate = Convert.ToDateTime(Reader["BILL_END_DATE"]);
                        bill.BillDesc = Reader["BILL_DESC"].ToString();
                        bill.BillType = Convert.ToChar(Reader["BILL_TYPE"]);
                        bill.AccKey = Convert.ToInt32(Reader["ACC_KEY"]);
                        bill.Amount = Convert.ToDecimal(Reader["AMOUNT"]);
                        bill.Total = Convert.ToDecimal(Reader["TOTAL"]);
                        bill.Frequency = RepoFrequency.Freqs[bill.FreqKey];
                        Bills.Add(bill.BillKey, bill);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Grabbing user data. " + ex.Message);
            }
            Command.Dispose();
            Reader.Close();
        }




        /// <summary>
        /// Edit User Record.
        /// 'A' : Add
        /// 'D' : Delete
        /// 'U' : Update
        /// </summary>
        /// <param name="users"></param>
        internal static void EditBill(List<ModelBill> Bills, char editType)
        {
            foreach (ModelBill Bill in Bills)
            {

                Bill.FreqKey = Bill.Frequency.FreqKey = RepoFrequency.AddFrequency(Bill.Frequency);

                StringBuilder Builder = new StringBuilder();
                Builder.AppendLine("EXECUTE proc_BILL_EDITOR");
                Builder.AppendLine("	@BILL_KEY ");
                Builder.AppendLine("	,@BILL_START_DATE ");
                Builder.AppendLine("	,@BILL_END_DATE ");
                Builder.AppendLine("	,@BILL_DESC ");
                Builder.AppendLine("	,@BILL_TYPE ");
                Builder.AppendLine("	,@AMOUNT ");
                Builder.AppendLine("	,@TOTAL ");
                Builder.AppendLine("	,@ACC_KEY ");
                Builder.AppendLine("	,@FREQ_KEY");
                Builder.AppendLine("	,@EDIT_TYPE");
                string SQL = Builder.ToString();

                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter billkey = new SqlParameter("@BILL_KEY", Bill.BillKey);
                SqlParameter startDate = new SqlParameter("@BILL_START_DATE", Bill.BillStartDate);
                SqlParameter endDate = new SqlParameter("@BILL_END_DATE", Bill.BillEndDate);
                SqlParameter billDesc = new SqlParameter("@BILL_DESC", Bill.BillDesc);
                SqlParameter billType = new SqlParameter("@BILL_TYPE", Bill.BillType);
                SqlParameter Amount = new SqlParameter("@AMOUNT", Bill.Amount);
                SqlParameter Total = new SqlParameter("@TOTAL", Bill.Total);
                SqlParameter AccKey = new SqlParameter("@ACC_KEY", Bill.AccKey);
                SqlParameter freq = new SqlParameter("@FREQ_KEY", Bill.FreqKey);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);

                parameters.Add(billkey);
                parameters.Add(startDate);
                parameters.Add(endDate);
                parameters.Add(billDesc);
                parameters.Add(billType);
                parameters.Add(Amount);
                parameters.Add(Total);
                parameters.Add(AccKey);
                parameters.Add(freq);
                parameters.Add(editTypeParam);

                Command.Parameters.AddRange(parameters.ToArray());

                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: editing Bill. " + ex.Message);
                }
                Command.Dispose();
            }
        }
    }
}
