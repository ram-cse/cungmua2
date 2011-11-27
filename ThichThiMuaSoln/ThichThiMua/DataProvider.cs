using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace ThichThiMua
{
    public class DataProvider
    {
        private string connectionString = @"server=muachung.mssql.somee.com;database=muachung;uid=hongquan;pwd=hongquanis";
        private string commmadText = "";

        public string CommmadText
        {
            set { commmadText = value; }
        }
        CommandType commandType = CommandType.Text;

        public CommandType CommandType
        {
            set { commandType = value; }
        }
        private string errorMessage = "";

        public string ErrorMessage
        {
            get { return errorMessage; }
        }
        DataTable dataTable = null;
        internal DataTable GetDataTable()
        {
            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(commmadText, sqlConnection);
                dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
            }
            return dataTable;
        }
        internal DataTable GetDataTable(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(commmadText, sqlConnection);
                //sqlCommand.Parameters.AddWithValue();
                dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
            }
            return dataTable;

        }
        
    }
}