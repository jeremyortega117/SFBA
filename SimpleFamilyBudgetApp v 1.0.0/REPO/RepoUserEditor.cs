using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class RepoUserEditor
    {
        internal static Dictionary<int, ModelUserEditor> users;


        /// <summary>
        /// Grab data from database.
        /// </summary>
        internal static void PrepareUserEditorData()
        {
            StringBuilder Builder = new StringBuilder();
            Builder.AppendLine("SELECT");
            Builder.AppendLine("    USER_KEY");
            Builder.AppendLine("    ,FNAME");
            Builder.AppendLine("    ,LNAME");
            Builder.AppendLine("    ,MI");
            Builder.AppendLine("    ,USERNAME");
            Builder.AppendLine("    ,CONVERT(VARCHAR(100), USER_PASS) AS [USER_PASS]");
            Builder.AppendLine("FROM USERS WITH(NOLOCK) ORDER BY LNAME, FNAME");
            string SQL = Builder.ToString();
            SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader();
                if (Reader != null)
                {
                    users = new Dictionary<int, ModelUserEditor>();
                    while (Reader.Read())
                    {
                        ModelUserEditor user = new ModelUserEditor();
                        user.UserKey = Convert.ToInt32(Reader["USER_KEY"]);
                        user.FirstName = Reader["FNAME"].ToString();
                        user.LastName = Reader["LNAME"].ToString();
                        user.MiddleInitial = Convert.ToChar(Reader["MI"]);
                        user.userName = Reader["USERNAME"].ToString();
                        user.UserPass = Reader["USER_PASS"].ToString();
                        users.Add(user.UserKey, user);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Grabbing user data. "+ex.Message);
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
        internal static void EditUser(List<ModelUserEditor> users, char editType)
        {
            foreach (ModelUserEditor user in users) {
                string SQL = $"EXECUTE proc_USER_EDITOR @USER_KEY, @USER_FNAME, @MI, @USER_LNAME, @USER_NAME, @USER_PASS, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, RepoDBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter user_key = new SqlParameter("@USER_KEY", user.UserKey);
                SqlParameter fName = new SqlParameter("@USER_FNAME",user.FirstName);
                SqlParameter MI = new SqlParameter("@MI", user.MiddleInitial);
                SqlParameter lName = new SqlParameter("@USER_LNAME", user.LastName);
                SqlParameter userName = new SqlParameter("@USER_NAME", user.userName);
                SqlParameter userPass = new SqlParameter("@USER_PASS", user.UserPass);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);
                parameters.Add(user_key);
                parameters.Add(fName);
                parameters.Add(MI);
                parameters.Add(lName);
                parameters.Add(userName);
                parameters.Add(userPass);
                parameters.Add(editTypeParam);
                Command.Parameters.AddRange(parameters.ToArray());
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: editing User '{user.userName}'. " + ex.Message);
                }
                Command.Dispose();
            }
        }

        internal static int RetrieveUserKeyFromName(string text)
        {
            foreach (ModelUserEditor user in users.Values)
            {
                string userCombonation = $"{user.LastName}, {user.FirstName} {user.MiddleInitial} : {user.userName}.";
                if(userCombonation == text)
                {
                    return user.UserKey;
                }
            }
            return -1;
        }
    }
}