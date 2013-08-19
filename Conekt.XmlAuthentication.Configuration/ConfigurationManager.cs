using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conekt.XmlAuthentication.Configuration
{
	public class ConfigurationManager : ConfigurationSection
	{
		public static ConfigurationManager GetConfiguration()
		{
			ConfigurationManager configuration = (ConfigurationManager)System.Configuration.ConfigurationManager.GetSection("xmlauth");

			if (configuration != null)
				return configuration;

			return new ConfigurationManager();
		}

		[ConfigurationProperty("settings", IsRequired = false)]
		public Settings Settings
		{
			get { return (Settings)this["settings"]; }
		}
	}
}
