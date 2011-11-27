using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace FacebookLogin
{
	public partial class callback : System.Web.UI.Page
	{
		//TODO: paste your facebook-app key here!!
        public const string FaceBookAppKey = "138943712879163";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.Cookies["fbs_" + FaceBookAppKey] == null) return; //ERROR! No cookie returned from Facebook!!

			string cookie = Request.Cookies["fbs_" + FaceBookAppKey].Value;
			cookie = cookie.Replace("\"", ""); //fixing stupid Facebook bug...
			NameValueCollection facebookValues = HttpUtility.ParseQueryString(cookie);

			//let's send an http-request to facebook using the token from the cookie
			//and parse the JSON response
			string json = GetFacebookUserJSON(facebookValues["uid"], facebookValues["access_token"]);
			Hashtable jsonHash = (Hashtable)JSON.JsonDecode(json);

			//ok, let's actually read some data from FB response
			string facebookName = jsonHash["name"] as string;
			string firstName = jsonHash["first_name"] as string;
			string lastName = jsonHash["last_name"] as string;
			string facebookId = jsonHash["id"] as string;
			string email = jsonHash["email"] as string; //because we explicitly requested email (see default.aspx fb-button)

			Response.Write("Welcome, " + facebookName);
		}

		/// <summary>
		/// sends http-request to Facebook and returns the response string
		/// </summary>
		private static string GetFacebookUserJSON(string userid, string access_token)
		{
			string url = string.Format("https://graph.facebook.com/{0}?access_token={1}&fields=email,name,first_name,last_name,link", userid, access_token);

			WebClient wc = new WebClient();
			Stream data = wc.OpenRead(url);
			StreamReader reader = new StreamReader(data);
			string s = reader.ReadToEnd();
			data.Close();
			reader.Close();

			return s;
		}
	}
}