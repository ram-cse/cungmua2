using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThichThiMua
{
    public partial class Home : System.Web.UI.Page
    {
        string connectionString = @"server=muachung.mssql.somee.com;database=muachung;uid=hongquan;pwd=hongquanis";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
                ShowProvinces();
            }
           
        }
        #region ShowData
        private void ShowData()
        {
            DataProvider dataProvider = new DataProvider();
            dataProvider.CommmadText = "udsProducts";
            dataProvider.CommandType = CommandType.StoredProcedure;
            DataList1.DataSource = dataProvider.GetDataTable();
            DataList1.DataBind();
        }
        string ProductId = "";
        string ProductName = "";
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("HiddenField1");
            HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("HiddenField2");
            //Label label = (Label)e.Item.FindControl("Label1");
            //label.Text = hiddenField.Value;
            
            ProductId = hiddenField1.Value;
            ProductName = hiddenField2.Value;
            ShowDetails();
            ShowInformation();
            
        }
#endregion
        #region ShowInformation
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

                DataList3.DataSource = dataTable;
                DataList3.DataBind();
            }
        }
#endregion
        #region ShowDetails
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
                for (int i = 1; i < 6 ; i++ )
                {
                    DataRow dataRow = dataTable.NewRow();
                    string path = Convert.ToString(i);
                    dataRow["ImagePath"] = @"images\"+ ProductName + @"\" + ProductName  + path + ".jpg";
                        
                    dataTable.Rows.Add(dataRow);
                }
            }
            DataList2.DataSource = dataTable;
            DataList2.DataBind();
        }
#endregion
        #region ShowProvinces
        private void ShowProvinces()
        {
            DataProvider dataProvider = new DataProvider();
            dataProvider.CommmadText = "udsProvinces";
            dataProvider.CommandType = CommandType.StoredProcedure;
            DropDownList1.DataSource = dataProvider.GetDataTable();
            DropDownList1.DataTextField = "ProvinceName";
            DropDownList1.DataValueField = "ProvinceId";
            DropDownList1.DataBind();  
        }
#endregion

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            
        }




        
        protected void DataList3_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            DataListItem item = e.Item;
            string id = ((HiddenField)item.FindControl("HiddenField3")).Value;
            string price = ((HiddenField)item.FindControl("HiddenField4")).Value;

            addItemToCart(id, price);
            
        }
        
        private void addItemToCart(string id, string price )
        {
            DataTable dataTable = null;

            if (Session["Cart"] == null)
            {
                dataTable = new DataTable();

                dataTable.Columns.Add("Id");
               // dataTable.Columns.Add("Title");
                
                dataTable.Columns.Add("Price");
                dataTable.Columns.Add("Quantity");
                dataTable.Columns.Add("Amount");
                

                Session["Cart"] = dataTable;
            }
            else
            {
                dataTable = (DataTable)Session["Cart"];

            }
            //we have table with 5 columns

            if (!IsExist(dataTable, id, 1))
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow["Id"] = id;
                
                
                dataRow["Price"] = price;
                dataRow["Quantity"] = "1";
                dataRow["Amount"] = price;
                

                dataTable.Rows.Add(dataRow);
            }
        }
        bool IsExist(DataTable dataTable, string id, int quantity)
        {
            bool exist = false;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["Id"].ToString() == id)
                {
                    dataRow["Quantity"] = Convert.ToInt32(dataRow["Quantity"]) + quantity;
                    dataRow["Amount"] = Convert.ToInt32(dataRow["Quantity"]) * Convert.ToInt32(dataRow["Price"]);
                    exist = true;

                    break;
                }
            }
            return exist;
        }

        protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
        {

        }
    }
}