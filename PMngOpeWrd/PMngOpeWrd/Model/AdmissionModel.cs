using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        internal string GetPatientAdmissionStatus(string patientId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("GetPatientAdmissionStatus", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PatientId", patientId);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            string status = string.Empty;

            if (reader.Read())
            {
                status = Convert.ToString(reader["AdmissionStatus"]);
            }

            return status;
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
    }
}