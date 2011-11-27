using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security;
using System.Security.Cryptography;

namespace ThichThiMua
{
    public partial class PreOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cart"] == null)
            {
                //Literal1.Text = "Empty Cart";
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
        }

        //private void CalculateTotalAmount()
        //{
        //    int totalAmount = 0;
        //    for (int i = 0; i < GridView1.Rows.Count; i++)
        //    {
        //        totalAmount += Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
        //    }
        //    //Literal2.Text = "Tong cong: " + totalAmount.ToString();
        //}
        string total = "";
        private void CalculateTotal(GridView gridView)
        {
            GridViewRow gridViewRowFooter = gridView.FooterRow;
            gridViewRowFooter.Cells[3].Text = "Total: ";
            int amount = 0;
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                amount += Convert.ToInt32(gridViewRow.Cells[1].Text) * Convert.ToInt32(gridViewRow.Cells[2].Text);
            }
            gridViewRowFooter.Cells[3].Text += amount.ToString();
            total = amount.ToString();
        }

        #region thanh toan ngan luong  
        private void ThanhToanNganLuong() 
        { 
            PaymentController payment = new PaymentController(); 
            if (string.IsNullOrEmpty(Request.Form["submit"])) 
            { 
                //khai báo url trả về 
                string return_url = "http://muarebandat.somee.com/DatHangThanhCong.aspx?order_code=" + Session["OrderID"]; 
                //khai báo địa chỉ email nhận tiền 
                string receiver = "hoangvu809@gmail.com"; 
                //khai báo thông tin giao dịch 
                this.Response.Write("Kết quả thanh toán không hợp lệ"); 
                string transaction_info = ""; 
                //khai báo mã sản phẩm, mã đơn hàng, mã giỏ hàng 
                string order_code = "A0001";    //SecurityProvider.Encrypt(lblMaHoaDon.Text, true); 
                //khai báo tổng số tiền thanh toán 
                string price = "1000000";    //litTongThanhTien.Text; 
                //gửi thông tin giao dịch đến nganluong.vn 
 
                string url = payment.BuildCheckoutUrl(return_url, receiver, transaction_info, order_code, price); 
                Response.Redirect(url);  
            }  
            if (this.Request.QueryString["process"] == "complete") 
            { 
                //lấy thông tin giao dịch 
                string transaction_info = this.Request.QueryString["transaction_info"]; 
                //lấy mã sản phẩm, mã đơn hàng, giỏ hàng giao dịch 
                string order_code = this.Request.QueryString["order_code"]; 
                //lấy tổng số tiền thanh toán 
                string price = this.Request.QueryString["price"]; 
                //lấy mã giao dịch thanh toán tại nganluong.vn 
                string payment_id = this.Request.QueryString["payment_id"]; 
                //lấy loại giao dịch tại nganluong.vn (1=thanh toán ngay, 2=thanh toán tạm giữ) 
                string payment_type = this.Request.QueryString["payment_type"]; 
                //lấy thông tin chi tiết về lỗi trong quá trình thanh toán 
                string error_text = this.Request.QueryString["error_text"]; 
                //lấy mã kiểm tra tính hợp lệ của đầu vào 
                string secure_code = this.Request.QueryString["secure_code"]; 
                //xử lý đầu vào 
                bool veri = payment.VerifyPaymentUrl(transaction_info, order_code, price, payment_id, payment_type, error_text, secure_code); 
                if (veri == false) 
                { 
                    //tham số gửi về không hợp lệ, có sự can thiệp từ bên ngoài 
                    this.Response.Write("Kết quả thanh toán không hợp lệ"); 
                } 
                else 
                { 
                    if (!string.IsNullOrEmpty(error_text)) 
                    { 
                        //có lỗi trong quá trình thanh toán 
                        Response.Write("Có lỗi: " + error_text + "! Hãy thực hiện lại!"); 
                    } 
                    else 
                    { 
                        //thanh toán thành công 
                        this.Response.Write("Thanh toán thành công"); 
                    } 
 
                } 
        } 
    } 
    #endregion thanh toan ngan luong  

        protected void Button1_Click1(object sender, EventArgs e)
        {
            ThanhToanNganLuong(); 
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}