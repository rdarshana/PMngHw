using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Model
{
    public class WardModel : IWardModel
    {
        //database connection string
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;MultipleActiveResultSets=true;Integrated Security=true;");


        public DataTable GetAllWardData()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllWardData", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public string GetNextWardId()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }


            SqlCommand sqlCmd = new SqlCommand("GetNextWardNo", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            return null;
        }

        public DataTable GetWardById(string wardNo)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetWardById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@WardNo", wardNo);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }

        public bool RegisterWard(dynamic ward)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand("WardRegistration", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@WardNo", ward.wardNo);
            sqlCmd.Parameters.AddWithValue("@Owner", ward.owner);
            sqlCmd.Parameters.AddWithValue("@WardType", ward.wardType);
            sqlCmd.Parameters.AddWithValue("@NoOfBeds", ward.noOfBeds);
            sqlCmd.Parameters.AddWithValue("@IsActive", ward.isActive);
            sqlCmd.Parameters.AddWithValue("@IsNewWard", ward.isNewWard);

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        }

        public DataTable LoadWardOwners()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllWardOwners", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }
    }
}