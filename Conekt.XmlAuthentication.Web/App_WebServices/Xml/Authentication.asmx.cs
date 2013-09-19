using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using Conekt.XmlAuthentication.Library;

//TODO: Move to Library
//Ref http://msdn.microsoft.com/en-us/library/1b1y85bh(v=vs.71).aspx
namespace Conekt.XmlAuthentication.Web.App_WebServices.Xml
{
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService]
	public class Authentication : System.Web.Services.WebService
	{
		#region Authenticate Methods
		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public Messaging.Result Login(string email, string password)
		{
			Messaging.Result result = new Messaging.Result();

			if (string.IsNullOrEmpty(email))
			{
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.Authenticate_Error_IncorrectUsername;
				return result;
			}

			if (string.IsNullOrEmpty(password))
			{
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.Authenticate_Error_IncorrectPassword;
				return result;
			}

			DataSet ds = new DataSet();
			FileStream fs = new FileStream(Server.MapPath("~/App_Data/Xml/Authentication/Users.xml"), FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader(fs);
			ds.ReadXml(reader);
			fs.Close();

			string cmd = "Email='" + email + "'";
			DataTable users = ds.Tables[0];
			DataRow[] matches = users.Select(cmd);

			if (matches != null && matches.Length > 0)
			{
				DataRow row = matches[0];
				string salt = (string)row["Salt"];
				string pass = BCrypt.Net.BCrypt.HashPassword(password, salt);
				string hash = (string)row["Password"];

				if (BCrypt.Net.BCrypt.Verify(password, hash))
				{
					//If a password match is found, set the authentication and login information.
					//Create the authentication ticket
					//Ref http://www.hanselman.com/blog/AccessingTheASPNETFormsAuthenticationTimeoutValue.aspx
					//Ref http://forums.asp.net/t/1177741.aspx
					FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, email, DateTime.Now, DateTime.Now.AddMinutes(FormsAuthentication.Timeout.Minutes), false, "");
					string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
					HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
					authCookie.Secure = FormsAuthentication.RequireSSL;
					HttpContext.Current.Response.Cookies.Add(authCookie);

					//Create the auth cookie
					FormsAuthentication.SetAuthCookie(email, false);

					//Set roles
					//string roles = row["Roles"].ToString();
					//HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(email, "Forms"), roles.Split(';'));

					//Set result object properties
					result.Status = Enums.Status.Success;
					result.Message = Resources.Xml.Authentication.Authenticate_Success_LogIn;
				}
				else
				{
					//Tell the user if no password match is found. It is good security practice give no hints about what parts of the logon credentials are invalid.
					result.Status = Enums.Status.Error;
					result.Message = Resources.Xml.Authentication.Authenticate_Error_IncorrectPassword;
				}
			}
			else
			{
				//If no name matches were found, return error message.
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.Authenticate_Error_IncorrectUsername;
			}

			return result;
		}

		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public void Logout()
		{
			FormsAuthentication.SignOut();
		}

		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public Messaging.Result PasswordReset(string email)
		{
			Messaging.Result result = new Messaging.Result();
			email = email.Trim();

			if(string.IsNullOrEmpty(email))
			{
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.PasswordReset_Error_IncorrectUsername;
				return result;
			}

			DataSet ds = new DataSet();
			string file = string.Empty;

			//Check that the user email exists
			file = "~/App_Data/Xml/Authentication/Users.xml";
			FileStream fs = new FileStream(Server.MapPath(file), FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader(fs);
			ds.ReadXml(reader);
			fs.Close();

			string cmd = "Email='" + email + "'";
			DataTable users = ds.Tables[0];
			DataRow[] matches = users.Select(cmd);

			if (matches.Length == 0)
			{
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.PasswordReset_Error_IncorrectUsername;
				return result;
			}
			
			//Empty the dataset
			ds.Reset();

			//Get the request xml data
			file = "~/App_Data/Xml/Authentication/PasswordReset.xml";
			fs = new FileStream(Server.MapPath(file), FileMode.Open, FileAccess.Read);
			reader = new StreamReader(fs);
			ds.ReadXml(reader);
			fs.Close();

			//Create reset request
			string token = Guid.NewGuid().ToString();
			DataRow request = ds.Tables[0].NewRow();
			request["Email"] = email;
			request["Token"] = token;
			request["DateRequested"] = DateTime.UtcNow;
			request["DateExpires"] = DateTime.UtcNow.AddHours(2);
			ds.Tables[0].Rows.Add(request);
			ds.AcceptChanges();

			fs = new FileStream(Server.MapPath(file), FileMode.Create, FileAccess.Write | FileAccess.Read);
			StreamWriter writer = new StreamWriter(fs);
			ds.WriteXml(writer);
			writer.Close();
			fs.Close();

			//Send email
			string resetUrl = (FormsAuthentication.RequireSSL ? "https://" : "http://") + Context.Request.Url.Host + (Context.Request.Url.Port != 80 && Context.Request.Url.Port != 443 ? ":" + Context.Request.Url.Port : string.Empty) + VirtualPathUtility.ToAbsolute(Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.PasswordChangeUrl) + "?email=" + email + "&token=" + token;
			MailMessage msg = new MailMessage()
			{
				Subject = string.Format(Resources.Xml.Authentication.Email_Subject_PasswordReset, Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName),
				Body = string.Format(Resources.Xml.Authentication.Email_Body_PasswordReset, resetUrl)
			};
			msg.To.Add(new MailAddress(email));
			CreateMail(msg);

			//Set result values
			result.Status = Enums.Status.Success;
			result.Message = string.Format(Resources.Xml.Authentication.PasswordReset_Success_EmailSent, email);

			return result;
		}

		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public Messaging.Result PasswordChange(string email, string token = "", string oldPassword = "", string newPassword = "")
		{
			Messaging.Result result = new Messaging.Result();

			if (string.IsNullOrEmpty(newPassword.Trim()))
			{
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.PasswordReset_Error_PasswordBlank;
				return result;
			}

			//Check if this is a password reset
			if(!string.IsNullOrEmpty(token.Trim()))
			{
				//Check if the token is valid
				if(IsValidToken(token))
				{
					//Inititate the password reset
					string userFile = HttpContext.Current.Server.MapPath("~/App_Data/Xml/Authentication/Users.xml");
					XDocument xdoc = XDocument.Load(userFile);

					var user = (from el in xdoc.Descendants("User")
								where (string)el.Element("Email") == email
								select el).SingleOrDefault();

					if(user != null)
					{
						//Create new salt and password hash.
						string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
						string hash = BCrypt.Net.BCrypt.HashPassword(newPassword, salt);

						//Set values
						user.SetElementValue("Salt", salt);
						user.SetElementValue("Password", hash);

						//Save file
						xdoc.Save(userFile);

						//Set result
						result.Status = Enums.Status.Success;
						result.Message = Resources.Xml.Authentication.PasswordReset_Success_PasswordUpdated;

						//Delete the reset request
						string resetFile = HttpContext.Current.Server.MapPath("~/App_Data/Xml/Authentication/PasswordReset.xml");
						xdoc = XDocument.Load(resetFile);

						var request = (from el in xdoc.Descendants("Request")
									   where (string)el.Element("Token") == token
									   select el).SingleOrDefault();

						request.Remove();
						xdoc.Save(resetFile);						
					}
				}
				else
				{
					//No request found
					result.Status = Enums.Status.Error;
					result.Message = Resources.Xml.Authentication.PasswordReset_Error_TokenInvalid;
				}
			}

			//TODO: Add password update

			return result;
		}
		#endregion

		#region Account Methods
		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public Messaging.Result AccountCreate(string email, string password)
		{
			Messaging.Result result = new Messaging.Result();

			//Check if the site is set to allow registrations
			if(!Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.AllowRegistration)
			{
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.Registration_Error_RegistrationDisabled;
				return result;
			}

			//Check for email value
			if(string.IsNullOrEmpty(email.Trim()))
			{
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.Registration_Error_EmailRequired;
				return result;
			}

			//Check if email is valid
			string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
			Match match = Regex.Match(email.Trim(), pattern, RegexOptions.IgnoreCase);

			if (!match.Success)
			{
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.Registration_Error_EmailInvalid;
				return result;
			}

			//Check for password value
			if (string.IsNullOrEmpty(password.Trim()))
			{
				result.Status = Enums.Status.Error;
				result.Message = Resources.Xml.Authentication.Registration_Error_PasswordRequired;
				return result;
			}

			//Create the account
			DataSet ds = new DataSet();
			string file = "~/App_Data/Xml/Authentication/Users.xml";

			FileStream fs = new FileStream(Server.MapPath(file), FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader(fs);
			ds.ReadXml(reader);
			fs.Close();

			//Check if user exists
			string cmd = "Email='" + email + "'";
			DataTable users = ds.Tables[0];
			DataRow[] matches = users.Select(cmd);

			if (matches.Length > 0)
			{
				//Email found, return error
				result.Status = Enums.Status.Error;
				result.Message = string.Format(
											Resources.Xml.Authentication.Registration_Error_EmailUsed,
											VirtualPathUtility.ToAbsolute(Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.PasswordResetUrl),
											"xmlauth.load('reset')"
											);
				return result;
			}

			string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
			string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
			string token = Guid.NewGuid().ToString();
			DataRow newUser = ds.Tables[0].NewRow();
			newUser["Email"] = email;
			newUser["Password"] = hash;
			newUser["Salt"] = salt;
			newUser["DateCreated"] = DateTime.UtcNow;
			newUser["Verified"] = false;
			newUser["Token"] = token;
			newUser["DateVerified"] = "";
			newUser["Roles"] = "";
			ds.Tables[0].Rows.Add(newUser);
			ds.AcceptChanges();

			fs = new FileStream(Server.MapPath(file), FileMode.Create, FileAccess.Write | FileAccess.Read);
			StreamWriter writer = new StreamWriter(fs);
			ds.WriteXml(writer);
			writer.Close();
			fs.Close();

			//Create email
			MailMessage msg = new MailMessage()
			{
				Subject = string.Format(Resources.Xml.Authentication.Email_Subject_AccountCreated, Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName),
				Body = string.Format(
					Resources.Xml.Authentication.Email_Body_AccountCreated,
					Context.Request.Url.AbsoluteUri,
					Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName,
					email,
					"**********"
					)
			};
			msg.To.Add(new MailAddress(email));

			//TODO: Finalize email verification
			if(Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.VerificationRequired)
			{
				//Set result message
				result.Status = Enums.Status.Success;
				result.Message = string.Format(Resources.Xml.Authentication.Global_Feature_NotImplemented, "The account has been created but the email verification feature has not been implemented. Please set the XmlAuth web.config property 'verificationRequired' to false to remove this message.");

				//Send email
				CreateMail(msg);
			}
			else
			{
				//Set result message
				result.Status = Enums.Status.Success;
				result.Message = Resources.Xml.Authentication.Registration_Success_RegisteredLoggedIn;
				
				//Send email
				CreateMail(msg);
			}

			return result;
		}
		#endregion

		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
		public bool IsAuthenticated()
		{
			return User.Identity.IsAuthenticated;
		}

		//TODO: Move global class
		public bool IsValidToken(string token)
		{
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
			if (request == null)
				return false;

			//Check if the request has expired.
			if (request.DateExpires < DateTime.UtcNow)
				return false;

			return true;
		}

		public void CreateMail(MailMessage msg)
		{
			Mail.Send(msg, Resources.Xml.Authentication.Email_Body_Wrapper, Resources.Xml.Authentication.Email_Body_Footer);
		}

		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public string Load(string content)
		{
			string url = "~/app_usercontrols/";
			string extension = ".ascx";

			switch (content)
			{
				case "change":
					url += "xml/authentication/password-change" + extension;
					break;
				
				case "create":
					url += "xml/authentication/account-create" + extension;
					break;

				case "default":
					url += "demo/content/landing" + extension;
					break;
				
				case "login":
					url += "xml/authentication/login" + extension;
					break;

				case "reset":
					url += "xml/authentication/password-reset" + extension;
					break;

				default:
					url += content + extension;
					break;
			}

			return Conekt.XmlAuthentication.Library.Utilities.RenderControlToHtml(url);
		}
	}
}