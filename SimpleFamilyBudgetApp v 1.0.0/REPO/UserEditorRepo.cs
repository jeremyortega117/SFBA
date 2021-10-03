using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    internal class UserEditorRepo
    {
        internal static Dictionary<int, UserEditorModel> users;


        /// <summary>
        /// Grab data from database.
        /// </summary>
        internal static void PrepareUserEditorData()
        {
            string SQL = "SELECT * FROM USERS WITH(NOLOCK)";
            SqlCommand Command = new SqlCommand(SQL, DBClass.DB);
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader != null)
            {
                users = new Dictionary<int, UserEditorModel>();
                while (Reader.Read())
                {
                    UserEditorModel user = new UserEditorModel();
                    user.UserKey = Convert.ToInt32(Reader["USER_KEY"]);
                    user.FirstName = Reader["FNAME"].ToString();
                    user.LastName = Reader["LNAME"].ToString();
                    user.MiddleInitial = Convert.ToChar(Reader["MI"]);
                    user.userName = Reader["USERNAME"].ToString();
                    user.UserPass = Reader["USER_PASS"].ToString();
                    users.Add(user.UserKey,user);
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
        internal static void EditUser(List<UserEditorModel> users, char editType)
        {
            foreach (UserEditorModel user in users) {
                string SQL = $"EXECUTE proc_USER_EDITOR @USER_KEY, @USER_FNAME, @MI, @USER_LNAME, @USER_NAME, @USER_PASS, @EDIT_TYPE";
                SqlCommand Command = new SqlCommand(SQL, DBClass.DB);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter user_key = new SqlParameter("@USER_KEY", user.UserKey);
                SqlParameter fName = new SqlParameter("@USER_FNAME",user.FirstName);
                SqlParameter MI = new SqlParameter("@MI", user.MiddleInitial);
                SqlParameter lName = new SqlParameter("@USER_LNAME", user.LastName);
                SqlParameter userName = new SqlParameter("@USER_NAME", user.userName);
                SqlParameter userPass = new SqlParameter("@USER_PASS", user.UserPass);
                SqlParameter editTypeParam = new SqlParameter("@EDIT_TYPE", editType);
                user_key.SqlDbType = SqlDbType.Int;
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
            }
        }

        internal static object RetrieveUserKeyFromName(string text)
        {
            foreach (UserEditorModel user in users.Values)
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