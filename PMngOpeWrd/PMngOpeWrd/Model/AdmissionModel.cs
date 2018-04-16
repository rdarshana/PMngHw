using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Model
{
    public class AdmissionModel
    {
        //database connection string
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;MultipleActiveResultSets=true;Integrated Security=true;");

        internal DataTable GetAllWardDataWithType()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllWardDataWithType", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        internal int GetAvailableBeds(string selectedWard)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("GetAvailableBedsByWardNo", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@SelectedWard", selectedWard);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            int availableBeds = 0;

            if (reader.Read())
            {

                availableBeds = Convert.ToInt32(reader["AvailableBeds"]);
            }

            return availableBeds;
        }

        internal DataTable GetAdmissionDetailById(int admissionId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetPatientAdmissionById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@AdmissionId", admissionId);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        internal dynamic GetPatientAdmissionStatus(string patientId, int admissionId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("GetPatientAdmissionStatus", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PatientId", patientId);
            sqlCmd.Parameters.AddWithValue("@AdmissionId", admissionId);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            string status = string.Empty;
            dynamic surgeryDetails = new ExpandoObject();

            if (reader.Read())
            {
                surgeryDetails.Id = Convert.ToInt32(reader["AdmissionId"]);
                surgeryDetails.WardNo = Convert.ToString(reader["WardNo"]);
                surgeryDetails.status = Convert.ToString(reader["AdmissionStatus"]);
                surgeryDetails.AdmissionDescription = Convert.ToString(reader["AdmissionDescription"]);
                surgeryDetails.DischargeDescription= Convert.ToString(reader["DischargeDescription"]);
            }

            return surgeryDetails;
        }

        internal bool AdmitPatient(dynamic surgery)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand("PatientWardAdmission", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@AdmissionId", surgery.AdmissionId);
            sqlCmd.Parameters.AddWithValue("@WardNo", surgery.WardNo);
            sqlCmd.Parameters.AddWithValue("@PatientId", surgery.PatientId);
            sqlCmd.Parameters.AddWithValue("@AdmissionDescription", surgery.AdmissionDescription);
            sqlCmd.Parameters.AddWithValue("@AdmittedBy", surgery.AdmittedBy);
            sqlCmd.Parameters.AddWithValue("@DischargeDescription", surgery.DischargeDescription);
            sqlCmd.Parameters.AddWithValue("@IsNewAdmission", surgery.IsNewAdmission);
            sqlCmd.Parameters.AddWithValue("@AdmissionStatus", surgery.AdmissionStatus);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        }

        internal string GetIsPatientAdmitForSurgery(string patientId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("GetIsPatientAdmitForSurgery", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@patientId", patientId);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            string wardNo = string.Empty;

            if (reader.Read())
            {
                wardNo = Convert.ToString(reader["WardNo"]);
            }

            return wardNo;
        }
    }
}