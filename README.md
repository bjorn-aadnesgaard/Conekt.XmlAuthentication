# ASP.NET XML Authentication

## Overview

Custom authentication for ASP.NET using XML.

This basic authentication system provides a platform to create and authenticate users.

A web forms demo is available at [http://conekt-xmlauth.azurewebsites.net/](http://conekt-xmlauth.azurewebsites.net/).

## Installation

### Assets

While styling is optional, a reference to the XMLAuthentication script is required. The script can be found under the ```Conekt.XmlAuthentication.Web/Assets/Scripts/``` folder.

### Data

The storage path for the authentication data files is ```ProjectPath/App_Data/XML/Authentication/```. Included in the demo project are XML template files for storing users and password reset requests.

### Resources

Email templates and alert messages are stored within the XML.Authentication.resx file found under the ```Conekt.XmlAuthentication.Web/App_GlobalResources/``` folder.

### Templates

Web form templates have been created and included in the demo project and can be found under the ```Conekt.XmlAuthentication.Web/App_UserControls/Xml/Authentication``` folder.

The templates included are:

* Create Account
* Login
* Change Password
* Reset Password

### Web Services / AJAX

The authentication system is designed to make use of ajax through ASP.NET web services. The web service file (Authentication.asmx) is located under the ```Conekt.XmlAuthentication.Web/App_WebServices/Xml/``` folder.

### Web.config

Your web.config must include the following properties in order to work correctly. Be sure to set the blank properties with your settings


	<configSections>
		<section name="xmlauth" type="Conekt.XmlAuthentication.Configuration.ConfigurationManager, Conekt.XmlAuthentication.Configuration" />
	</configSections>
	<system.web>
		<authentication mode="Forms">
			<forms timeout="15" loginUrl="" name="" slidingExpiration="false" protection="All" requireSSL="false" />
		</authentication>
	</system.web>
	<system.net>
		<mailSettings>
			<smtp from="">
				<network host="" enableSsl="false" userName="" password="" port="587" />
			</smtp>
		</mailSettings>
	</system.net>
	<xmlauth>
		<settings applicationName="" allowRegistration="true" verificationRequired="false" loginUrl="" passwordResetUrl="" passwordChangeUrl="" />
	</xmlauth>


## Browser Support

The included demo project uses Bootstrap 3.0.0 RC2 and is optimized for use with mobile devices, IE9+, Firefox and Chrome.

## Futures

* MVC demo project/site
* jQuery client side validation
* Roles
* User management structure

Created and maintained by [Bjorn Aadnesgaard](http://conekted.com) 

