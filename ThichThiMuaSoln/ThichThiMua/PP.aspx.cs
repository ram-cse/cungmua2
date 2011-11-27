using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThichThiMua
{
    public partial class PP : System.Web.UI.Page
    {
        private bool PayPalReturnRequest = false;

        /// <summary>
        /// Our ever so complicated ORDER DATA. Hey this is supposed to be 
        /// a quick demo and skeleton, so I kept it as simple as possible.
        /// The article shows a more complex environment!
        /// </summary>
        protected decimal OrderAmount = 0.00M;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PayPal"] != null)
                this.HandlePayPalReturn();  

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                this.OrderAmount = decimal.Parse(this.txtOrderAmount.Text);
            }
            catch
            {
                this.ShowError("Invalid Order Amount. Get a grip.");
                return;
            }


            // *** Dumb ass data simulation - this should only be set once the order is Validated!
            this.Session["OrderAmount"] = this.OrderAmount;


            // *** Handle PayPal Processing seperately from ProcessCard() since it requires
            // *** passing off to another page on the PayPal Site.
            // *** This request will return to this page Cancel or Success querystring
            //if (this.txtCCType.SelectedValue == "PP" && !this.PayPalReturnRequest)
                this.HandlePayPalRedirection(); // this will end this request!



            // *** TODO:  Save your order etc.



            // *** Show the confirmation page - don't transfer so they can refresh without error
            Response.Redirect("Confirmation.aspx");
        }

        private void HandlePayPalRedirection()
        {

            // *** Set a flag so we know we redirected
            Session["PayPal_Redirected"] = "True";

            // *** Save any values you might need when you return here
            Session["PayPal_OrderAmount"] = this.OrderAmount;  // already saved above

            //			Session["PayPal_HeardFrom"] = this.txtHeardFrom.Text;
            //			Session["PayPal_ToolUsed"] = this.txtToolUsed.Text;

            PayPalHelper PayPal = new PayPalHelper();
            PayPal.PayPalBaseUrl = Configuration.PayPalUrl;
            PayPal.AccountEmail = Configuration.AccountEmail;
            PayPal.Amount = this.OrderAmount;


            //PayPal.LogoUrl = "https://www.west-wind.com/images/wwtoollogo_text.gif";

            PayPal.ItemName = "West Wind Web Store Invoice #" + new Guid().GetHashCode().ToString("x");

            // *** Have paypal return back to this URL
            PayPal.SuccessUrl = Request.Url + "?PayPal=Success";
            PayPal.CancelUrl = Request.Url + "?PayPal=Cancel";

            Response.Redirect(PayPal.GetSubmitUrl());

            return;
        }

        /// <summary>
        /// Handles the return processing from a PayPal Request.
        /// Looks at the PayPal Querystring variable
        /// </summary>
        private void HandlePayPalReturn()
        {
            string Result = Request.QueryString["PayPal"];
            string Redir = (string)Session["PayPal_Redirected"];

            // *** Only do this if we are redirected!
            if (Redir == "True")
            {
                Session.Remove("PayPal_Redirected");

                // *** Set flag so we know not to go TO PayPal again
                this.PayPalReturnRequest = true;

                // *** Retrieve saved Page content
                this.txtOrderAmount.Text = ((decimal)Session["PayPal_OrderAmount"]).ToString();
               // this.txtCCType.SelectedValue = "PP";

                //				this.txtNotes.Text = (string) Session["PayPal_Notes"];
                //				this.txtHeardFrom.Text = (string) Session["PayPal_HeardFrom"];
                //				this.txtToolUsed.Text = (string) Session["PayPal_ToolUsed"];

                if (Result == "Cancel")
                {
                    this.ShowError("PayPal Payment Processing Failed");
                }
                else
                {
                    // *** We returned successfully - simulate button click to save the order
                    this.btnSubmit_Click(this, EventArgs.Empty);
                }
            }
        }




        void ShowError(string ErrorMessage)
        {
            this.lblErrorMessage.Text = ErrorMessage + "<p>";
        }
    }
}