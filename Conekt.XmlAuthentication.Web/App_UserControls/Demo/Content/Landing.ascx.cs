using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Conekt.XmlAuthentication.Web.App_UserControls.Demo.Content
{
	public partial class Landing : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//Register javascript
			Page.ClientScript.RegisterStartupScript(this.GetType(), "GetReadMe", "$(function () { $('.readme').html('<div style=\"text-align: center; padding-bottom: 20px;\"><img src=\"/assets/styles/images/loading.gif\" /></div>').load('http://markdown.io/_rawhtml/https://raw.github.com/bjorn-aadnesgaard/Conekt.XmlAuthentication/master/README.md', function() {}); });", true); 
		}
	}
}