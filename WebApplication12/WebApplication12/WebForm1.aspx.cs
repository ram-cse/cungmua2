using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication12
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region Varaibles
        string connectionString = "server=(local);database=StudentManagementForProfessional;Integrated Security=True;";
        SqlConnection sqlConnection = null;
        SqlDataAdapter sqlDataAdapter = null;
        SqlCommand sqlCommand = null;
        string commandText = "";
        CommandType commandType = CommandType.Text;
        string reportFolder = @"D:\C#\WebApplication12\WebApplication12\";
        
        #endregion Varaibles

        #region GetDataTable
        DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    commandText = "select * from Students";
                    sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    sqlDataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {

            }
            return dataTable;
        }
        DataTable GetDataTable(string parameterName, object
             parameterObject)
        {
            DataTable dataTable = new DataTable();
            try
            {
                sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterObject);
                sqlCommand.CommandType = commandType;
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {

            }
            return dataTable;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GridView1.DataSource = GetDataTable();
                GridView1.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = GetDataTable();
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = GetDataTable(); ;
                CrystalReport3 reportDocument = new CrystalReport3();reportDocument.Load(@"D:\C#\WebApplication12\WebApplication12\CrystalReport3.rpt");
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
    }
}