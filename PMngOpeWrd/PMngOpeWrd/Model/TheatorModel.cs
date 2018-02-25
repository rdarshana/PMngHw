using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Model
{
    public class TheatorModel : ITheatorModel
    {
        //database connection string
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;MultipleActiveResultSets=true;Integrated Security=true;");

        public DataTable GetAllTheatorData()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllTheaterData", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public string GetNextTheatorId()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }


            SqlCommand sqlCmd = new SqlCommand("GetNextTheaterId", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            return null;
        }

        public DataTable GetTheatorById(string theatorId)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetTheaterById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@TheaterId", theatorId);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public bool RegisterTheator(dynamic theator)
        {
            if(sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand("TheatorRegistration", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TheatorId", theator.theatorId);
            sqlCmd.Parameters.AddWithValue("@Description", theator.description);
            sqlCmd.Parameters.AddWithValue("@IsActive", theator.isActive);
            sqlCmd.Parameters.AddWithValue("@IsNewTheator", theator.isNewTheator);

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        }
    }
}