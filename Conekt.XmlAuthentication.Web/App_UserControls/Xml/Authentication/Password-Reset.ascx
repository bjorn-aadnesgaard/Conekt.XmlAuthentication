<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Password-Reset.ascx.cs" Inherits="Conekt.XmlAuthentication.Web.App_UserControls.Xml.Authentication.Password_Reset" %>

<div class="container login">
	<div class="panel panel-default reset">

		<div class="panel-heading">
			<h3 class="panel-title">Recover your <%= Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName %> password</h3>
		</div>
		
		<div class="panel-body">
			
			<%--Alert--%>
			<div class="alert" style="display: none;">
				<button type="button" class="close" data-hide="alert">&times;</button>
				<div></div>
			</div>

			<div class="row">
				<div class="col-md-4">
					<div class="form-group">
						<label>Email</label>
						<input class="form-control email" id="email" type="email" />
					</div>
				</div>
			</div>

			<%--Commands--%>
			<div class="row">
				<div class="col-md-4">
					<input class="btn btn-default btn-primary" type="submit" value="Send Password" data-loading-text="Sending" onclick="xmlauth.passwordReset(); return false;" />
					<a href="/#!/login" onclick="xmlauth.load('login');">Cancel</a>
				</div>
			</div>
		</div>

	</div>
</div>