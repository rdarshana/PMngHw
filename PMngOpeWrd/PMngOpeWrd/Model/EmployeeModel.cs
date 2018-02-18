using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Model
{
    public class EmployeeModel : IEmployeeModel
    {
        //database connection string
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;MultipleActiveResultSets=true;Integrated Security=true;");


        public string GetNextEmployeeId(string employeeType)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand("GetNextEmployeeId", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@EmployeeType", employeeType);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            int empoloyeeRowCount = 0;
            string employeeId = string.Empty;
            string employeeIdPrefix = "EMP";
            if (reader.Read())
            {
                empoloyeeRowCount = reader.GetInt32(0);
                employeeId = employeeIdPrefix + "-" + (empoloyeeRowCount + 1);
                return employeeId;
            }
            return null;
        }

        public bool RegisterEmployee(dynamic employee)
        {
            Guid userGuid = System.Guid.NewGuid();

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            // Hash the password together with our unique userGuid
            string hashedPassword = Common.Security.HashSHA1(employee.password + userGuid.ToString());


            SqlCommand sqlCmd = new SqlCommand("EmployeeRegistration", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@EmployeeId", employee.patientId);
            sqlCmd.Parameters.AddWithValue("@EmployeeType", employee.employeeType);
            sqlCmd.Parameters.AddWithValue("@IsNewEmployee", employee.isNewEmployee);
            sqlCmd.Parameters.AddWithValue("@Password", hashedPassword);
            sqlCmd.Parameters.AddWithValue("@FirstName", employee.firstName);
            sqlCmd.Parameters.AddWithValue("@LastName", employee.lastName);
            sqlCmd.Parameters.AddWithValue("@NIC", employee.NIC);
            sqlCmd.Parameters.AddWithValue("@Address", employee.address);
            sqlCmd.Parameters.AddWithValue("@MobilePhone", employee.mobilePhone);
            sqlCmd.Parameters.AddWithValue("@LandPhone", employee.landPhone);
            sqlCmd.Parameters.AddWithValue("@Email", employee.email);
            sqlCmd.Parameters.AddWithValue("@IsActive", employee.isActive);
 
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        }
    }
}