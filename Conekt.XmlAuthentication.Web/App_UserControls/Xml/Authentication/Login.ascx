<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Conekt.XmlAuthentication.Web.App_UserControls.Authentication.Login" %>

<div class="container login">
	<div class="panel panel-default">

		<%--Heading--%>
		<div class="panel-heading">
			<h3 class="anonymous panel-title">Sign in to <%= Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName %></h3>
			<h3 class="authenticated panel-title" style="display: none;">You are logged in to <%= Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName %></h3>
		</div>

		<%--Body--%>
		<div class="panel-body">
			<div class="alert" style="display: none">
				<button type="button" class="close" data-hide="alert">&times;</button>
				<div></div>
			</div>

			<%--Anonymous display--%>
			<div class="anonymous">
				<%--Inputs--%>
				<div class="row">
					<div class="col-md-4">
						<div class="form-group">
							<label>Email</label>
							<input class="form-control" id="email" type="email" />
						</div>
						<div class="form-group">
							<label>Password</label>
							<input class="form-control" id="password" type="password" />
						</div>
					</div>
				</div>

				<%--Commands--%>
				<div class="row">
					<div class="col-md-4">
						<input class="btn btn-primary" data-loading-text="Authenticating" type="submit" value="Sign In" onclick="xmlauth.login(); return false;" />
					</div>
				</div>
			</div>

			<%--Authenticated display--%>
			<div class="authenticated" style="display: none;">
				<input class="btn btn-default btn-primary" type="submit" value="Logout" onclick="xmlauth.logout(); return false;" />
			</div>
		</div>

		<%--Footer--%>
		<div class="panel-footer anonymous">
			<div>New to <%= Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName %>? <a href="/#!/create" onclick="xmlauth.load('create');">Create an Account</a>.</div>
			<div><a href="/#!/reset" onclick="xmlauth.load('reset');">Forgot your password?</a></div>
		</div>
	</div>
</div>