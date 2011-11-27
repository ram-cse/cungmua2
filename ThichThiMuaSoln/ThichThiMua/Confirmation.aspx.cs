using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThichThiMua
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlForm frmConfirmation;

        public object InvPk;

        /// <summary>
        /// Our ever so complicated ORDER DATA. Hey this is supposed to be 
        /// a quick demo and skeleton, so I kept it as simple as possible.
        /// The article shows a more complex environment!
        /// </summary>
        protected decimal OrderAmount
        {
            get
            {
                if (this._Amount != -1.11M)
                    return this._Amount;

                try
                {
                    this._Amount = (decimal)Session["OrderAmount"];
                }
                catch { this._Amount = 0.00M; }

                return this._Amount;
            }
        }
        private decimal _Amount = -1.11M;
        protected void Page_Load(object sender, EventArgs e)
        {
            // *** TODO: Put your order finalization code here. up invoice or whatever
            //			 Display a full invoice, Email Confirmations etc. etc.
            // *** We'll simulate with a Session variable in the OrderAmoutn Property above
            //     the ASPX page simply displays the final order amount.

            // *** If Order Amount was never set we can't confirm
            if (this.OrderAmount == 0.00M)
                Response.Redirect("OrderForm.aspx");


            // *** Throw away the key
            Session.Remove("OrderAmount");

        }


    }
}