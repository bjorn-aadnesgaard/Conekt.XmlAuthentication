//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources.Xml {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Authentication {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Authentication() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Xml.Authentication", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Username and password do not match&lt;/strong&gt;. Please try again..
        /// </summary>
        internal static string Authenticate_Error_IncorrectPassword {
            get {
                return ResourceManager.GetString("Authenticate_Error_IncorrectPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Username not found&lt;/strong&gt;. Please try again..
        /// </summary>
        internal static string Authenticate_Error_IncorrectUsername {
            get {
                return ResourceManager.GetString("Authenticate_Error_IncorrectUsername", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are now &lt;strong&gt;logged in&lt;/strong&gt;..
        /// </summary>
        internal static string Authenticate_Success_LogIn {
            get {
                return ResourceManager.GetString("Authenticate_Success_LogIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are now &lt;strong&gt;logged out&lt;/strong&gt;..
        /// </summary>
        internal static string Authenticate_Success_LogOut {
            get {
                return ResourceManager.GetString("Authenticate_Success_LogOut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Thank you for registering with &lt;a href=&quot;{0}&quot;&gt;{1}&lt;/a&gt;. This email confirms your registration.&lt;/p&gt;
        ///
        ///&lt;p&gt;Your account information is:&lt;/p&gt;
        ///
        ///&lt;p&gt;
        ///Username: {2}&lt;br/&gt;
        ///Password: {3} 
        ///&lt;/p&gt;
        ///
        ///&lt;p&gt;
        ///Please note that your password is not displayed security reasons.
        ///&lt;/p&gt;.
        /// </summary>
        internal static string Email_Body_AccountCreated {
            get {
                return ResourceManager.GetString("Email_Body_AccountCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;div style=&quot;font-size:85%&quot;&gt;
        ///&lt;p&gt;
        ///This message was intended for: {0}. If you have received this email in error, please delete it immediately.&lt;br/&gt;
        ///This email message was auto-generated. Please do not respond.
        ///&lt;/p&gt;
        ///&lt;/div.
        /// </summary>
        internal static string Email_Body_Footer {
            get {
                return ResourceManager.GetString("Email_Body_Footer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;A request has been made to reset your account password.&lt;/p&gt;
        ///
        ///&lt;p&gt;Click the following link to reset your password:&lt;/p&gt;
        ///
        ///&lt;p&gt;
        ///----------------------------------&lt;br/&gt;
        ///{0}&lt;br/&gt;
        ///----------------------------------
        ///&lt;/p&gt;
        ///
        ///&lt;p&gt;If you are having trouble clicking the above link, copy and paste it in to your browser window.&lt;/p&gt;
        ///
        ///&lt;p&gt;&lt;strong&gt;Just a reminder&lt;/strong&gt;&lt;/p&gt;
        ///
        ///&lt;ul&gt;
        ///	&lt;li&gt;Never share your password with anyone.&lt;/li&gt;
        ///	&lt;li&gt;Create passwords that are hard to guess and don&apos;t use personal information. B [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Email_Body_PasswordReset {
            get {
                return ResourceManager.GetString("Email_Body_PasswordReset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;div style=&quot;margin:0;padding:0;font-family:Arial,Helvetica,sans-serif;font-weight:normal;font-size:13px;line-height:21px;color:#434343;width:590px;&quot;&gt;
        ///	{0}
        ///&lt;/div&gt;.
        /// </summary>
        internal static string Email_Body_Wrapper {
            get {
                return ResourceManager.GetString("Email_Body_Wrapper", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to {0}.
        /// </summary>
        internal static string Email_Subject_AccountCreated {
            get {
                return ResourceManager.GetString("Email_Subject_AccountCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password Reset.
        /// </summary>
        internal static string Email_Subject_PasswordReset {
            get {
                return ResourceManager.GetString("Email_Subject_PasswordReset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Feature not yet implemented&lt;/strong&gt;. {0}.
        /// </summary>
        internal static string Global_Feature_NotImplemented {
            get {
                return ResourceManager.GetString("Global_Feature_NotImplemented", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Email not found&lt;/strong&gt;. Please try again..
        /// </summary>
        internal static string PasswordReset_Error_IncorrectUsername {
            get {
                return ResourceManager.GetString("PasswordReset_Error_IncorrectUsername", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Error&lt;/strong&gt;. A password is required..
        /// </summary>
        internal static string PasswordReset_Error_PasswordBlank {
            get {
                return ResourceManager.GetString("PasswordReset_Error_PasswordBlank", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Reset link has expired&lt;/strong&gt;. Use the &lt;a href=&quot;{0}&quot;&gt;password recovery tool&lt;/a&gt; to generate a new link. The password reset link is valid for 2 hours when issued..
        /// </summary>
        internal static string PasswordReset_Error_TokenExpired {
            get {
                return ResourceManager.GetString("PasswordReset_Error_TokenExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Invalid reset link&lt;/strong&gt;. Please check the link sent to your email address. Be sure to click or copy and paste the entire link in to your browser..
        /// </summary>
        internal static string PasswordReset_Error_TokenInvalid {
            get {
                return ResourceManager.GetString("PasswordReset_Error_TokenInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A password reset link has been sent to &lt;strong&gt;{0}&lt;/strong&gt;. Please check your email..
        /// </summary>
        internal static string PasswordReset_Success_EmailSent {
            get {
                return ResourceManager.GetString("PasswordReset_Success_EmailSent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Success&lt;/strong&gt;. Your password has been updated..
        /// </summary>
        internal static string PasswordReset_Success_PasswordUpdated {
            get {
                return ResourceManager.GetString("PasswordReset_Success_PasswordUpdated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Invalid email address&lt;/strong&gt;. Please make sure your email address is valid..
        /// </summary>
        internal static string Registration_Error_EmailInvalid {
            get {
                return ResourceManager.GetString("Registration_Error_EmailInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;An email address is required&lt;/strong&gt;. Please enter an email address..
        /// </summary>
        internal static string Registration_Error_EmailRequired {
            get {
                return ResourceManager.GetString("Registration_Error_EmailRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;This email address is already registered&lt;/strong&gt;. If this is your email address use the &lt;a href=&quot;{0}&quot; onclick=&quot;{1}&quot;&gt;password recovery&lt;/a&gt; tool to reset your password..
        /// </summary>
        internal static string Registration_Error_EmailUsed {
            get {
                return ResourceManager.GetString("Registration_Error_EmailUsed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;A password is required&lt;/strong&gt;. Please enter a password..
        /// </summary>
        internal static string Registration_Error_PasswordRequired {
            get {
                return ResourceManager.GetString("Registration_Error_PasswordRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Error&lt;/strong&gt;. Sorry, account registrations are not permitted..
        /// </summary>
        internal static string Registration_Error_RegistrationDisabled {
            get {
                return ResourceManager.GetString("Registration_Error_RegistrationDisabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Success&lt;/strong&gt;. Your account has been created and you are now logged in..
        /// </summary>
        internal static string Registration_Success_RegisteredLoggedIn {
            get {
                return ResourceManager.GetString("Registration_Success_RegisteredLoggedIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Your account has been created&lt;/strong&gt;. To finalize your account setup, please check your email and follow the email verification intructions..
        /// </summary>
        internal static string Registration_Success_RegisteredVerify {
            get {
                return ResourceManager.GetString("Registration_Success_RegisteredVerify", resourceCulture);
            }
        }
    }
}