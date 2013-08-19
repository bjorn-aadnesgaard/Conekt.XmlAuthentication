using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conekt.XmlAuthentication.Configuration
{
	public class Settings : ConfigurationElement
	{
		[ConfigurationProperty("applicationName", IsRequired = false)]
		public string ApplicationName
		{
			get { return (string)this["applicationName"]; }
		}

		[ConfigurationProperty("allowRegistration", IsRequired = false)]
		public bool AllowRegistration
		{
			get { return (bool)this["allowRegistration"]; }
		}

		[ConfigurationProperty("passwordChangeUrl", IsRequired = false)]
		public string PasswordChangeUrl
		{
			get { return (string)this["passwordChangeUrl"]; }
		}

		[ConfigurationProperty("passwordResetUrl", IsRequired = false)]
		public string PasswordResetUrl
		{
			get { return (string)this["passwordResetUrl"]; }
		}

		[ConfigurationProperty("loginUrl", IsRequired = false)]
		public string LoginUrl
		{
			get { return (string)this["loginUrl"]; }
		}

		[ConfigurationProperty("verificationRequired", IsRequired = false)]
		public bool VerificationRequired
		{
			get { return (bool)this["verificationRequired"]; }
		}
	}
}
