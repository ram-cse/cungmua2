using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication12
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = GetDataTable(); ;
                CrystalReport4 reportDocument = new CrystalReport4(); 
                reportDocument.Load(@"D:\C#\WebApplication12\WebApplication12\CrystalReport4.rpt");
                reportDocument.SetDataSource(dataTable);
                CrystalReportViewer1.ReportSource = reportDocument;
                CrystalReportViewer1.DataBind();

                CrystalReportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        DataTable GetDataTable()
        {
            string connectionString = "server=(local);database=StudentManagementForProfessional;Integrated Security=True;";
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string commandText = "udsCountStudents";
                    CommandType commandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    sqlDataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {

            }
            return dataTable;
        }
    }
}