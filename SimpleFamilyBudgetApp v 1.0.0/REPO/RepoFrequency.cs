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
    internal class RepoFrequency
    {
        internal static Dictionary<int, ModelFrequency> Freqs;

        /// <summary>
        /// Grab data from database.
        /// </summary>
        internal static void PrepareFrequencyData()
        {
            string SQL = "select * from FREQUENCY";
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            Freqs = new Dictionary<int, ModelFrequency>();
            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader();
                if (Reader != null)
                {
                    while (Reader.Read())
                    {
                        ModelFrequency freq = new ModelFrequency();
                        freq.FreqKey = Convert.ToInt32(Reader["FREQ_KEY"]);
                        freq.FreqType = Convert.ToChar(Reader["FREQ_TYPE"]);
                        freq.Monday = Convert.ToBoolean(Reader["MONDAY"]);
                        freq.Tuesday = Convert.ToBoolean(Reader["TUESDAY"]);
                        freq.Wednesday = Convert.ToBoolean(Reader["WEDNESDAY"]);
                        freq.Thursday = Convert.ToBoolean(Reader["THURSDAY"]);
                        freq.Friday = Convert.ToBoolean(Reader["FRIDAY"]);
                        freq.Saturday = Convert.ToBoolean(Reader["SATURDAY"]);
                        freq.Sunday = Convert.ToBoolean(Reader["SUNDAY"]);
                        Freqs.Add(freq.FreqKey, freq);
                    }
                    Reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Grabbing Frequency data. " + ex.Message);
            }
            Command.Dispose();
        }


        /// <summary>
        /// Frequency will be added and the Frequency Key Returned.
        /// </summary>
        /// <param name="users"></param>
        internal static int AddFrequency(ModelFrequency freq)
        {

            string SQL = $"EXECUTE proc_FREQUENCY_ADDR @FREQ_TYPE, @MONDAY, @TUESDAY, @WEDNESDAY, @THURSDAY, @FRIDAY, @SATURDAY, @SUNDAY, @FREQ_KEY OUT";

            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter freqType = new SqlParameter("@FREQ_TYPE", freq.FreqType);
            SqlParameter Mon = new SqlParameter("@MONDAY", freq.Monday);
            SqlParameter Tue = new SqlParameter("@TUESDAY", freq.Tuesday);
            SqlParameter Wed = new SqlParameter("@WEDNESDAY", freq.Wednesday);
            SqlParameter Thur = new SqlParameter("@THURSDAY", freq.Thursday);
            SqlParameter Fri = new SqlParameter("@FRIDAY",freq.Friday);
            SqlParameter Sat = new SqlParameter("@SATURDAY", freq.Saturday);
            SqlParameter Sun = new SqlParameter("@SUNDAY", freq.Sunday);
            SqlParameter freqKey = new SqlParameter("@FREQ_KEY", freq.FreqKey);
            parameters.Add(freqType);
            parameters.Add(Mon);
            parameters.Add(Tue);
            parameters.Add(Wed);
            parameters.Add(Thur);
            parameters.Add(Fri);
            parameters.Add(Sat);
            parameters.Add(Sun);

            freqKey.Direction = ParameterDirection.Output;
            parameters.Add(freqKey);
           
            Command.Parameters.AddRange(parameters.ToArray());
            int freqKeyRet = -1;
            try
            {
                Command.ExecuteNonQuery();
                freqKeyRet = Convert.ToInt32(Command.Parameters["@FREQ_KEY"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Adding Frequency. " + ex.Message);
            }
            Command.Dispose();
            return freqKeyRet;
        }
    }
}
