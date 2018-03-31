using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PMngOpeWrd.Model;

namespace PMngOpeWrd.Model
{
    public class PatientExaminationModel: IPatientExaminationModel
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;Integrated Security=true;");
        public DataTable GetPatientHistoryById(string patientId)
        {

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetPatientHistoryById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@PatientId", patientId);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        internal bool AddPatientExamination(dynamic patient)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand("AddPatientExamination", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
            sqlCmd.Parameters.AddWithValue("@EmployeeId", patient.EmployeeId);
            sqlCmd.Parameters.AddWithValue("@Complain", patient.Complain);
            sqlCmd.Parameters.AddWithValue("@Examination", patient.Examination);
            sqlCmd.Parameters.AddWithValue("@Diagnosis", patient.Diagnosis);
            sqlCmd.Parameters.AddWithValue("@Drugs", patient.Drugs);
            sqlCmd.Parameters.AddWithValue("@IsNewExamine", patient.IsNewExamine);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        }
    }
}