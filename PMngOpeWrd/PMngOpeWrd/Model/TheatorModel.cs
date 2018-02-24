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
            throw new NotImplementedException();
        }

        public string GetNextTheatorId()
        {
            throw new NotImplementedException();
        }

        public DataTable GetTheatorById(string theatorId)
        {
            throw new NotImplementedException();
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
            sqlCmd.Parameters.AddWithValue("@IsActive", theator.IsActive);
            sqlCmd.Parameters.AddWithValue("@IsNewTheator", theator.isNewTheator);

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        }
    }
}