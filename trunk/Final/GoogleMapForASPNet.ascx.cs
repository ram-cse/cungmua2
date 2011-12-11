using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class GoogleMapForASPNet : System.Web.UI.UserControl
    {
        public delegate void PushpinMovedHandler(string pID);
        public event PushpinMovedHandler PushpinMoved;
        // The method which fires the Event

        public void OnPushpinMoved(string pID)
        {
            // Check if there are any Subscribers
            if (PushpinMoved != null)
            {
                // Call the Event
                GoogleMapObject = (GoogleObject)System.Web.HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
                PushpinMoved(pID);
            }
        }


        #region Properties

        GoogleObject _googlemapobject = new GoogleObject();
        public GoogleObject GoogleMapObject
        {
            get { return _googlemapobject; }
            set { _googlemapobject = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Console.Write(hidEventName.Value);
        //Console.Write(hidEventValue.Value);
        //Fire event for Pushpin Move
        if (hidEventName.Value == "PushpinMoved")
        {
            //Set event name to blank string, so on next postback same event doesn't fire again.
            hidEventName.Value = "";
            OnPushpinMoved(hidEventValue.Value);
        }
        if (!IsPostBack)
        {
            Session["GOOGLE_MAP_OBJECT"] = GoogleMapObject;
        }
        else
        {
            GoogleMapObject = (GoogleObject)Session["GOOGLE_MAP_OBJECT"];
        }
    }
        }
    }
