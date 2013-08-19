using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Conekt.XmlAuthentication.Web
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (FormsAuthentication.RequireSSL && !Request.IsSecureConnection)
			{
				string url = Request.Url.ToString().Replace("http", "https");
				Response.Redirect(url);
			}
		}
	}
}