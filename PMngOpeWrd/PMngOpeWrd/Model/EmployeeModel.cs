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
            sqlCmd.Parameters.AddWithValue("@EmployeeType", employeeType);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            int empoloyeeRowCount = 0;
            string employeeId = string.Empty;
            string employeeIdPrefix = string.Empty;
            if (reader.Read())
            {
                empoloyeeRowCount = reader.GetInt32(0);

                switch (employeeType)
                {
                    case "doctor":
                        employeeIdPrefix = "DOC";
                        break;
                    case "anesthetist":
                        employeeIdPrefix = "ANE";
                        break;
                    case "director":
                        employeeIdPrefix = "DIR";
                        break;
                    case "mlt":
                        employeeIdPrefix = "MLT";
                        break;
                    default:
                        employeeIdPrefix = "Error";
                        break;
                }

                employeeId = employeeIdPrefix + "-" + (empoloyeeRowCount + 1);
                return employeeId;
                //return (reader.GetInt32(0)).ToString();
            }
            return null;
        }
    }
}