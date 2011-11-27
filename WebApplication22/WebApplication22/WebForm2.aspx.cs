using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication22
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string time = "";
        public double seconds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                DataList1.DataSource = GetDataTable();
                DataList1.DataBind();
                DataList2.DataSource = GetDataTable();
                DataList2.DataBind();
            }
           // seconds = (GetEndTime() - GetStartTime()).TotalSeconds;
            Label label = (Label)DataList2.Items[0].FindControl("Label2");
            Button2.Attributes.Add("onclick", "alert('" + label.ClientID + "')");
        }
        string connectionString = "server=.;database=Report;Integrated Security=True";
        DataTable GetDataTable()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("select Time, id from Test", sqlConnection);
                //sqlCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        DateTime dateTime ;
        protected void Button1_Click(object sender, EventArgs e)
        {
            connectionString = "server=.;database=Report;Integrated Security=True";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string commandText = "insert into Test(Time) values(@Time)";
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Time", txtCalendar.Text);
                    int i = sqlCommand.ExecuteNonQuery();
                    Label1.Text = i.ToString();
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
            //DataTable dataTable = GetDataTable();
            //DataRow dataRow = dataTable.Rows[14];
            //dateTime = Convert.ToDateTime(dataRow["Time"]);
            //seconds = (GetEndTime() - GetStartTime()).TotalSeconds;
        }

        private DateTime GetStartTime()
        {
            return DateTime.Now;
        }

        private DateTime GetEndTime()
        {
            return dateTime;
        }
        
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            dateTime = new DateTime();
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenField1");
            dateTime = DateTime.Parse(hiddenField.Value);
            seconds = (GetEndTime() - GetStartTime()).TotalSeconds;
        }
        Label label2;
        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
             label2 = (Label)e.Item.FindControl("Label2");
        }
    }
}