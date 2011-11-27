using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication22
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = "server=.;database=Report;Integrated Security=True";
        
        SqlCommand sqlCommand = null;
        SqlDataAdapter sqlDataAdapter = null;
        DataTable dataTable = null;
        string commandText = "udsTimer";
        public double seconds;

        DataTable GetDataTable()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable();
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            seconds = (GetEndTime() - GetStartTime()).TotalSeconds;
        }

        private DateTime GetStartTime()
        {
            return DateTime.Now;
        }

        private DateTime GetEndTime()
        {
            
            return new DateTime(2010, 5, 06, 8, 10, 0);
        }
    }
}