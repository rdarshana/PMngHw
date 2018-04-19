using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Model
{
    public class SurgeryListModel
    {
        //database connection string
        SqlConnection sqlCon = new SqlConnection(@"Data Source=RDARSHANA;Initial Catalog=PntMngOpeWrd;MultipleActiveResultSets=true;Integrated Security=true;");

        internal DataTable GetAllSurgeryApprovalData(dynamic filterData)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("GetPatientSurgeryList", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@SearchColumn", filterData.searchColumn);
            sqlDa.SelectCommand.Parameters.AddWithValue("@SearchValue", filterData.searchValue);
            sqlDa.SelectCommand.Parameters.AddWithValue("@Doctor", filterData.doctor);
            sqlDa.SelectCommand.Parameters.AddWithValue("@SurgeryFrom", filterData.surgeryFrom);
            sqlDa.SelectCommand.Parameters.AddWithValue("@SurgeryTo", filterData.surgeryTo);
            sqlDa.SelectCommand.Parameters.AddWithValue("@AdmissionFrom", filterData.admissionFrom);
            sqlDa.SelectCommand.Parameters.AddWithValue("@AdmissionTo", filterData.admissionTo);
            sqlDa.SelectCommand.Parameters.AddWithValue("@SurgeryStatus", filterData.surgeryStatus);

            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable);
            sqlCon.Close();
            return dataTable;
        }
    }
}