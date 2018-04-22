using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
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

        internal bool UpdatePostSurgery(int surgeryId, string note, string status)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                SqlCommand sqlCmd = new SqlCommand("UpdateSurgeruStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurgeryId", surgeryId);
                sqlCmd.Parameters.AddWithValue("@Note", note);
                sqlCmd.Parameters.AddWithValue("@Status", status);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
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
                sqlCmd.Parameters.AddWithValue("@IsNewSurgery", surgery.IsNewSurgery);

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

        internal bool IsValidTheaterSelection(string surgeryDateFrom, string surgeryDateTo, string theatorId, int surgeryId, string isNewSurgery)
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
            sqlDa.SelectCommand.Parameters.AddWithValue("@IsNewSurgery", isNewSurgery);
            sqlDa.SelectCommand.Parameters.AddWithValue("@SurgeryId", surgeryId);
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

        internal DataTable GetAllSurgeryApprovalData(string userType,string searchColumn, string searchValue)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllSurgeryPendingAprovalData", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure; 
            sqlDa.SelectCommand.Parameters.AddWithValue("@userType", userType);
            sqlDa.SelectCommand.Parameters.AddWithValue("@SearchColumn", searchColumn);
            sqlDa.SelectCommand.Parameters.AddWithValue("@SearchValue", searchValue);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        //internal DataTable GetSurgeryBySearchKey(string searchColumn, string searchValue)
        //{
        //    throw new NotImplementedException();

        //}

        internal DataTable GetSurgeryDetailsBySurgeryId(int surgeryId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetSurgeryDetailsBySurgeryId", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@SurgeryId", surgeryId);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        internal dynamic GetSurgeryApprovalStatusById(int surgeryId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("GetSurgeryApprovalStatusById", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@SurgeryId", surgeryId);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            string status = string.Empty;
            dynamic surgeryDetails = new ExpandoObject();

            if (reader.Read())
            {
                surgeryDetails.SurgeonApproval = Convert.ToString(reader["SurgeonApproval"]);
                surgeryDetails.AnesthetistApproval = Convert.ToString(reader["AnesthetistApproval"]);
                surgeryDetails.DirectorApproval = Convert.ToString(reader["DirectorApproval"]);
                surgeryDetails.PatientId = Convert.ToString(reader["PatientId"]);
            }

            return surgeryDetails;
        }


        internal bool SubmitSurgeonApproval(int surgeryId, string surgeonApproval, string surgeonDescription, string approver)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                SqlCommand sqlCmd = new SqlCommand("AddSurgeonApproval", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurgeryId", surgeryId);
                sqlCmd.Parameters.AddWithValue("@SurgeonApproval", surgeonApproval);
                sqlCmd.Parameters.AddWithValue("@SurgeonDescription", surgeonDescription);
                sqlCmd.Parameters.AddWithValue("@Approver", approver);
                
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        internal bool SubmitAnesthesiaApproval(int surgeryId, string anesthetistApproval, string modeOfAnesthesia, string anesthetistProblem, string approver)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                SqlCommand sqlCmd = new SqlCommand("AddAnesthesiaApproval", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurgeryId", surgeryId);
                sqlCmd.Parameters.AddWithValue("@AnesthetistApproval", anesthetistApproval);
                sqlCmd.Parameters.AddWithValue("@ModeOfAnesthesia", modeOfAnesthesia);
                sqlCmd.Parameters.AddWithValue("@AnesthetistProblem", anesthetistProblem);
                sqlCmd.Parameters.AddWithValue("@Approver", approver);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        internal bool SubmitDirecctorApproval(int surgeryId, string directorApproval, string directorDescription, string approver)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                SqlCommand sqlCmd = new SqlCommand("AddDirecctorApproval", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurgeryId", surgeryId);
                sqlCmd.Parameters.AddWithValue("@DirectorApproval", directorApproval);
                sqlCmd.Parameters.AddWithValue("@DirectorDescription", directorDescription);
                sqlCmd.Parameters.AddWithValue("@Approver", approver);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}