using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Model
{
    public class SurgeryModel
    {
        //database connection string
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;MultipleActiveResultSets=true;Integrated Security=true;");

        public DataTable LoadWardOwners()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetWardOwners", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public DataTable LoadWardsByDoctor(string employeeId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetWardsByDoctor", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public DataTable LoadAllTheaters()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllTheaters", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public bool RegisterSurgery(dynamic surgery)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                SqlCommand sqlCmd = new SqlCommand("SurgeryRegistration", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurgeryId", surgery.SurgeryId);
                sqlCmd.Parameters.AddWithValue("@DoctorId", surgery.DoctorId);
                sqlCmd.Parameters.AddWithValue("@AdmissionDate", Convert.ToDateTime(surgery.AdmissionDate));
                sqlCmd.Parameters.AddWithValue("@Description", surgery.Description);
                sqlCmd.Parameters.AddWithValue("@SurgeryStart", Convert.ToDateTime(surgery.SurgeryStart));
                sqlCmd.Parameters.AddWithValue("@SurgeryEnd", Convert.ToDateTime(surgery.SurgeryEnd));
                sqlCmd.Parameters.AddWithValue("@TheatorId", surgery.TheatorId);
                sqlCmd.Parameters.AddWithValue("@PatientId", surgery.PatientId);
                sqlCmd.Parameters.AddWithValue("@WardNo", surgery.WardNo);
                sqlCmd.Parameters.AddWithValue("@IsNewSurgery", true);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public DataTable GetReservedTheators(string surgeryDateFrom, string surgeryDateTo, string theatorId )
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            string fromDate = surgeryDateFrom.Split(' ')[0];
            string toDate = surgeryDateTo.Split(' ')[0];

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetTheatorsByDateRange", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@FromDate", fromDate);
            sqlDa.SelectCommand.Parameters.AddWithValue("@ToDate", toDate);
            sqlDa.SelectCommand.Parameters.AddWithValue("@TheatorId", theatorId);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        internal bool IsValidTheaterSelection(string surgeryDateFrom, string surgeryDateTo, string theatorId)
        {
            bool validTheatorSelection = false;
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetIsValidTheatorDateTimeRangne", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@FromDate", surgeryDateFrom);
            sqlDa.SelectCommand.Parameters.AddWithValue("@ToDate", surgeryDateTo);
            sqlDa.SelectCommand.Parameters.AddWithValue("@TheatorId", theatorId);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();

            if (dataTable.Rows.Count > 0)
            {
                validTheatorSelection = false;
            }
            else
            {
                validTheatorSelection = true;
            }
            return validTheatorSelection;
        }

        internal DataTable GetAllSurgeryApprovalData(string userType)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllSurgeryPendingAprovalData", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure; 
            sqlDa.SelectCommand.Parameters.AddWithValue("@userType", userType);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        internal DataTable GetSurgeryBySearchKey(string searchColumn, string searchValue)
        {
            throw new NotImplementedException();

        }
    }
}