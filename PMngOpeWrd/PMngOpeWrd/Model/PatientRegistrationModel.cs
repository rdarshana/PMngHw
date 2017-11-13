using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Data.SqlClient;
using System.Data;

namespace PMngOpeWrd.Model
{
    public class PatientRegistrationModel : IPatientRegistrationModel
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;Integrated Security=true;");

        public DataTable GetAllPatientData()
        {
            if(sqlCon.State== ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllPatientData", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public DataTable GetPatientById(string patientId)
        {
            if(sqlCon.State ==ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetPatientById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@PatientId", patientId);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public bool InsertPatientData(dynamic patient)
        {

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand("PatientRegistration", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PatientId", patient.patientId == "" ? null : patient.patientId);
            sqlCmd.Parameters.AddWithValue("@FirstName", patient.firstName);
            sqlCmd.Parameters.AddWithValue("@LastName", patient.lastName);
            sqlCmd.Parameters.AddWithValue("@NIC", patient.NIC);
            sqlCmd.Parameters.AddWithValue("@Address", patient.address);
            sqlCmd.Parameters.AddWithValue("@MobilePhone", patient.mobilePhone);
            sqlCmd.Parameters.AddWithValue("@LandPhone", patient.landPhone);
            sqlCmd.Parameters.AddWithValue("@Email", patient.email);
            sqlCmd.Parameters.AddWithValue("@Gender", patient.gender);
            sqlCmd.Parameters.AddWithValue("@MaritalStatus", patient.maritalStatus);
            sqlCmd.Parameters.AddWithValue("@EmergencyContact", patient.emergencyContact);
            sqlCmd.Parameters.AddWithValue("@DateOfBirth", patient.dateOfBirth);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        }
    }
}