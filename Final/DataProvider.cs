using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Final
{
    public class DataProvider
    {
        private string connectionString = @"server=(local);database=CungMua;Integrated Security=True";
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
                sqlCommand.CommandType = CommandType.StoredProcedure;
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
