using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Conekt.XmlAuthentication.Library;

namespace Conekt.XmlAuthentication.Web.App_UserControls.Xml.Authentication
{
	public partial class Password_Change : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//Check for reset token
			if(Request.QueryString["token"] != null)
			{
				Result = new Messaging.Result();

				HasToken = true;
				string token = Request.QueryString["token"];

				//TODO: Move to GetTokenRequest method and return requets object.
				//Check if token is valid
				XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Xml/Authentication/PasswordReset.xml"));
				var request =
					(from el in root.Elements("Request")
					 where (string)el.Element("Token") == token
					 select new
					 {
						 Email = (string)el.Element("Email"),
						 Token = (string)el.Element("Token"),
						 DateExpires = (DateTime)el.Element("DateExpires")
					 }).SingleOrDefault();

				//Check for a request
				if(request == null)
				{
					//No request found
					Result.Status = Enums.Status.Error;
					Result.Message = Resources.Xml.Authentication.PasswordReset_Error_TokenInvalid;
					IsValidToken = false;

					//Register javascript
					//Page.ClientScript.RegisterStartupScript(this.GetType(), "PasswordChange", "$(function () { $('.login .alert').show(); });", true);

					return;
				}

				//Check if the request has expired.
				if (request.DateExpires < DateTime.UtcNow)
				{
					Result.Status = Enums.Status.Error;
					Result.Message = string.Format(Resources.Xml.Authentication.PasswordReset_Error_TokenExpired, VirtualPathUtility.ToAbsolute(Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.PasswordResetUrl));
					IsValidToken = false;
					
					return;
				}

				Email = request.Email;
				Token = request.Token;
				IsValidToken = true;
			}
		}

		public Messaging.Result Result { get; set; }
		public bool HasToken { get; set; }
		public bool IsValidToken { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
	}
}