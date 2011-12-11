using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Final
{
    public partial class Home : System.Web.UI.Page
    {
        string connectionString = @"server=(local);database=CungMua;Integrated Security=True";
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ShowData();
                DataProvider dataProvider = new DataProvider();
                dataProvider.CommmadText = "udsProductRandom";
                dataProvider.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = dataProvider.GetDataTable();
                DataRow dataRow = dataTable.Rows[0];
                string ProductId = Convert.ToString(dataRow["ProductId"]);
                string ProductName = Convert.ToString(dataRow["ProductName"]);

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string commmadText = "udsProducts;2";
                    SqlCommand sqlCommand = new SqlCommand(commmadText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("ProductId", ProductId);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);

                    DataList2.DataSource = dataTable;
                    DataList2.DataBind();
                    dateTime = DateTime.Parse(dataRow["ExpirationDate"].ToString());
                    seconds = (GetEndTime() - GetStartTime()).TotalSeconds;
                }


                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string commmadText = "udsProducts;2";
                    SqlCommand sqlCommand = new SqlCommand(commmadText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("ProductId", ProductId);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    dataTable.Columns.Add("ImagePath");
                    for (int i = 1; i < 6; i++)
                    {
                        dataRow = dataTable.NewRow();
                        string path = Convert.ToString(i);
                        dataRow["ImagePath"] = @"images\" + ProductName + @"\" + ProductName + path + ".jpg";
                        dataTable.Rows.Add(dataRow);
                    }
                        DataList3.DataSource = dataTable;
                        DataList3.DataBind();
                 }
                


                //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
                //For samples to run properly, set GoogleAPIKey in Web.Config file.
                GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

                //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
                GoogleMapForASPNet1.GoogleMapObject.Width = "400px"; // You can also specify percentage(e.g. 80%) here
                GoogleMapForASPNet1.GoogleMapObject.Height = "300px";

                //Specify initial Zoom level.
                GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;

                //Specify Center Point for map. Map will be centered on this point.
                GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 10.758121, 106.657687);

                //Add pushpins for map. 
                //This should be done with intialization of GooglePoint class. 
                //ID is to identify a pushpin. It must be unique for each pin. Type is string.
                //Other properties latitude and longitude.

                //DataTable dataTable = GetDataTable();
                //DataRow dataRow = dataTable.Rows[0];
                //GooglePoint GP1 = new GooglePoint();
                //GP1.ID = "1";
                //GP1.Latitude = Convert.ToDouble(dataRow["Latitude"]);
                //GP1.Longitude = Convert.ToDouble(dataRow["Longtitude"]);
                //GP1.InfoHTML = Convert.ToString(dataRow["Address"]);
                //GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);
            }
        }
        #endregion

        #region GetDataTable
        DataTable GetDataTable()
        {
            DataTable dataTable = null;
            string connectionString = "server=.;database=CungMua;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("select * from Product", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
            }
            return dataTable;
        }
        #endregion

        #region ShowDataList1
        private void ShowData()
        {
            DataProvider dataProvider = new DataProvider();
            dataProvider.CommmadText = "udsProducts";
            dataProvider.CommandType = CommandType.StoredProcedure;
            DataList1.DataSource = dataProvider.GetDataTable();
            DataList1.DataBind();
        }
        #endregion

        string ProductId = "";
        string ProductName = "";
        DateTime dateTime;
        public double seconds;

        #region DataList1_ItemCommand
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("HiddenField1");
            HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("HiddenField2");
            dateTime = new DateTime();
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenField3");
            dateTime = DateTime.Parse(hiddenField.Value);
            seconds = (GetEndTime() - GetStartTime()).TotalSeconds;
            ProductId = hiddenField1.Value;
            ProductName = hiddenField2.Value;
            ShowDetails();
            ShowInformation();
        }
        #endregion

        #region ShowDataList2
        private void ShowInformation()
        {
            DataTable dataTable = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string commmadText = "udsProducts;2";
                SqlCommand sqlCommand = new SqlCommand(commmadText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("ProductId", ProductId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);

                DataList2.DataSource = dataTable;
                DataList2.DataBind();
            }
        }
        #endregion

        #region ShowDataList3
        private void ShowDetails()
        {

            DataTable dataTable = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string commmadText = "udsProducts;2";
                SqlCommand sqlCommand = new SqlCommand(commmadText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("ProductId", ProductId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);

                dataTable.Columns.Add("ImagePath"); 
                for (int i = 1; i < 6; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    string path = Convert.ToString(i);
                    dataRow["ImagePath"] = @"images\" + ProductName + @"\" + ProductName + path + ".jpg";

                    dataTable.Rows.Add(dataRow);
                }
            }
            DataList3.DataSource = dataTable;
            DataList3.DataBind();
        }
        #endregion

        private DateTime GetStartTime()
        {
            return DateTime.Now;
        }

        private DateTime GetEndTime()
        {
            return dateTime;
        }
    }
}