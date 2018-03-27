using PMngOpeWrd.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Model
{
    public class LoginModel
    {
        //database connection string
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;MultipleActiveResultSets=true;Integrated Security=true;");

        internal dynamic AuthenticateUser(dynamic login)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand("GetUserDetailsById", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@EmployeeId", login.userName);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            string userId = string.Empty;
            dynamic logedinUser = new ExpandoObject();

            if (reader.Read())
            {

                string dbUserType = Convert.ToString(reader["EmployeeType"]);
                string dbPassword = Convert.ToString(reader["Password"]);
                string dbUserGuid = Convert.ToString(reader["UserGuid"]);
                string dbUserName = Convert.ToString(reader["Name"]);

                string hashedPassword = Security.HashSHA1(login.password + dbUserGuid);

                // if its correct password the result of the hash is the same as in the database
                if (dbPassword == hashedPassword)
                {
                    // The password is correct
                    logedinUser.userType = dbUserType;
                    logedinUser.password = dbUserName;
                    logedinUser.valid = true;
                }
                else
                {
                    login.valid = false;
                }
            }

            return logedinUser;
        }
    }
}