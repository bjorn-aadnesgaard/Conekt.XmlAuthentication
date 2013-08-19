using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Conekt.XmlAuthentication.Configuration;

namespace Conekt.XmlAuthentication.Library
{
	public class Mail
	{
		public static void Send(MailMessage msg, string wrapper = "", string footer = "")
		{
			SmtpClient smtp = new SmtpClient();
			msg.IsBodyHtml = true;

			//Set the from data
			msg.From = new MailAddress(ConfigurationManager.GetConfiguration().Settings.ApplicationName + " Support<" + msg.From + ">");

			//Add global footer
			if (!string.IsNullOrEmpty(footer.Trim()))
				msg.Body += string.Format(footer, msg.To);

			//Add HTML Wrapper
			if (!string.IsNullOrEmpty(wrapper.Trim()))
				msg.Body = string.Format(wrapper, msg.Body);

			//Send message
			smtp.Send(msg);
		}
	}
}