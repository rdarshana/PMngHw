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
        //database connection string
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;Integrated Security=true;");

        /// <summary>
        /// Delete patient by given Id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public bool DeletePatientBySelectedId(string patientId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand("DeletePatientById", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PatientId", patientId);
            sqlCmd.ExecuteNonQuery();

            return true;
        }

        /// <summary>
        /// Get all patient information
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// insert or update patient information
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public bool InsertPatientData(dynamic patient)
        {

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand("PatientRegistration", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PatientId", patient.patientId);
            sqlCmd.Parameters.AddWithValue("@FirstName", patient.firstName);
            sqlCmd.Parameters.AddWithValue("@LastName", patient.lastName);
            sqlCmd.Parameters.AddWithValue("@NIC", patient.NIC);
            sqlCmd.Parameters.AddWithValue("@Address", patient.address);
            sqlCmd.Parameters.AddWithValue("@MobilePhone", patient.mobilePhone);
            sqlCmd.Parameters.AddWithValue("@LandPhone", patient.landPhone);
            sqlCmd.Parameters.AddWithValue("@Email", patient.email);
            sqlCmd.Parameters.AddWithValue("@BloodGroup", patient.bloodGroup); 
            sqlCmd.Parameters.AddWithValue("@Gender", patient.gender);
            sqlCmd.Parameters.AddWithValue("@MaritalStatus", patient.maritalStatus);
            sqlCmd.Parameters.AddWithValue("@EmergencyContact", patient.emergencyContact);
            sqlCmd.Parameters.AddWithValue("@DateOfBirth", patient.dateOfBirth);
            sqlCmd.Parameters.AddWithValue("@GardianName", patient.gardianName);
            sqlCmd.Parameters.AddWithValue("@GardianAddress", patient.gardianAddress);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        }

        public string GetNextPatientId()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }


            SqlCommand sqlCmd = new SqlCommand("GetNextPatientId", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            return null;
            //SqlDataAdapter sqlDa = new SqlDataAdapter("GetNextPatientId", sqlCon);
            //sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            //DataTable dataTable = new DataTable();
            //sqlDa.Fill(dataTable);
            //sqlCon.Close();
            //return dataTable;
        }
    }
}