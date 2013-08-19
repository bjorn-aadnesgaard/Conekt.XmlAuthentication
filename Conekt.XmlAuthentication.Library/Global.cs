using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace Conekt.XmlAuthentication.Library
{
	public class Utilities
	{
		public static string RenderControlToHtml(string ControlToRender)
		{
			//Load control
			Page page = new Page();
			UserControl ctl = (UserControl)page.LoadControl(ControlToRender);
			page.Controls.Add(ctl);

			StringWriter writer = new StringWriter();
			HttpContext.Current.Server.Execute(page, writer, false);

			return writer.ToString();
		}
	}

	public class Enums
	{
		public enum Status
		{
			Error,
			Success
		}
	}

	public class Messaging
	{
		public class Result
		{
			public Enums.Status Status { get; set; }
			public string Message { get; set; }
		}
	}
}
