using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ThichThiMua
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cart"] == null)
            {
                Literal1.Text = "Sorry, your Shopping Cart is empty. Moi ban mua hang ";
            }
            else
            {
                if (!IsPostBack)
                {
                    DataTable dataTable = (DataTable)Session["Cart"];
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                    CalculateTotal(GridView1);                   
                } 
            }
            LoadJavaScript();
        }
        private void LoadJavaScript()
        {

            string javaScript = "function Amount(textBoxAmountId,textBoxQtyId, textBoxPriceId){";
            javaScript += "document.getElementById(textBoxAmountId).value =document.getElementById(textBoxQtyId).value*document.getElementById(textBoxPriceId).value;}";
            foreach (GridViewRow row in GridView1.Rows)
            {

                TextBox textBox1 = (TextBox)row.FindControl("TextBox1");
                TextBox textBox2 = (TextBox)row.FindControl("TextBox2");
                TextBox textBox3 = (TextBox)row.FindControl("TextBox3");

                textBox1.Attributes.Add("onblur", string.Format("Amount('{0}','{1}','{2}')", textBox3.ClientID, textBox1.ClientID, textBox2.ClientID));
                textBox2.Attributes.Add("onblur", string.Format("Amount('{0}','{1}','{2}')", textBox3.ClientID, textBox1.ClientID, textBox2.ClientID));

            }


            ClientScript.RegisterClientScriptBlock(this.GetType(), "SetAmount", javaScript, true);


        }
        //1. Quantity
        //2. Price
        //3. Amount
        private void CalculateTotal(GridView gridView)
        {
            GridViewRow gridViewRowFooter = gridView.FooterRow;
            gridViewRowFooter.Cells[2].Text = "Total: ";
            //int weight = 0;
            int amount = 0;
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                string quantity = ((TextBox)gridViewRow.FindControl("TextBox1")).Text;
                string price = ((TextBox)gridViewRow.FindControl("TextBox2")).Text;
                amount += Convert.ToInt32(price) * Convert.ToInt32(quantity);
            }
            gridViewRowFooter.Cells[2].Text = amount.ToString("#,###.00");
        }
    }
}