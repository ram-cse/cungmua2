using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication12
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "server=(local);database=StudentManagementForProfessional;Integrated Security=True;";
            SqlConnection sqlConnection = null;
            SqlDataAdapter sqlDataAdapter = null;
            SqlCommand sqlCommand = null;
            string commandText = "";
            CommandType commandType = CommandType.Text;
            string reportFolder = @"D:\C#\WebApplication12\WebApplication12\";
            DataTable dataTable = new DataTable();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    commandText = "select * from Provinces";
                    sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    sqlDataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            CrystalReport4 reportDocument = new CrystalReport4(); reportDocument.Load(@"D:\C#\WebApplication12\WebApplication12\CrystalReport4.rpt");
            reportDocument.SetDataSource(dataTable);
            CrystalReportViewer1.ReportSource = reportDocument;
            CrystalReportViewer1.DataBind();

            CrystalReportViewer1.RefreshReport();
        }
    }
}