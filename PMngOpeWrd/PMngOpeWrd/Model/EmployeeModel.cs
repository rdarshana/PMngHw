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

        public DataTable GetAllEmployeeData()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllEmployeeData", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public DataTable GetEmployeeById(string employeeId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetEmployeeById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public DataTable GetEmployeeBySearchKey(string columnName, string searchValue)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetEmployeeBySearchKey", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ColumnName", columnName);
            sqlDa.SelectCommand.Parameters.AddWithValue("@SearchValue", searchValue);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

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

            string guid = userGuid.ToString();

            // Hash the password together with unique user Guid
            string hashedPassword = Common.Security.HashSHA1(employee.password + guid);

            SqlCommand sqlCmd = new SqlCommand("EmployeeRegistration", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            sqlCmd.Parameters.AddWithValue("@EmployeeType", employee.employeeType);
            sqlCmd.Parameters.AddWithValue("@IsNewEmployee", employee.isNewEmployee);
            sqlCmd.Parameters.AddWithValue("@Password", hashedPassword);
            sqlCmd.Parameters.AddWithValue("@UserGuid", guid); 
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