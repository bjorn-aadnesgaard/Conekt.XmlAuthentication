<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Password-Change.ascx.cs" Inherits="Conekt.XmlAuthentication.Web.App_UserControls.Xml.Authentication.Password_Change" %>

<div class="container login">
	<div class="panel panel-default reset">
	
		<%--Header--%>
		<div class="panel-heading">
			<h3 class="panel-title">Change your password for <%= Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName %></h3>
		</div>

		<%--Content--%>
		<div class="panel-body">

			<%--Alert--%>
			<div class="alert" style="display: none;">
				<button type="button" class="close" data-hide="alert">&times;</button>
				<div></div>
			</div>

			<div class="content">

				<% if (!Page.User.Identity.IsAuthenticated && HasToken && !IsValidToken) { %>
					<%= Result.Message %>
				<% } %>

				<%--Password Reset Using Token--%>
				<% if (!Page.User.Identity.IsAuthenticated && HasToken && IsValidToken) { %>

					<%--Content--%>
					<div class="row">
						<div class="col-md-4">
							<div class="form-group">
								<label>New Password</label>
								<input class="form-control" id="newPassword" type="password" />
							</div>
						</div>
					</div>

					<%--Commands--%>
					<div class="row">
						<div class="col-md-4">
							<input class="btn btn-primary" data-loading-text="Updating" type="submit" value="Update" onclick="xmlauth.passwordChange('<%= Email %>', '<%= Token %>'); return false;" />
						</div>
					</div>

				<% } else { %>
					Please <a href="<%= VirtualPathUtility.ToAbsolute(Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.LoginUrl) %>">login</a> to continue.
				<% } %>

				<%--Password Reset When Authenticated--%>
				<% if (Page.User.Identity.IsAuthenticated) { %>
	
					<%--Content--%>
					<div class="row">
						<div class="col-md-4">
							<div class="form-group">
								<label>Old Password</label>
								<input class="form-control" id="oldPassword" type="password" />
							</div>
							<div class="form-group">
								<label>New Password</label>
								<input class="form-control" id="newPassword" type="password" />
							</div>
						</div>
					</div>

					<%--Commands--%>
					<div class="row">
						<div class="col-md-4">
							<input class="btn btn-primary" data-loading-text="Updating" type="submit" value="Update" onclick="xmlauth.passwordChange(); return false;" />
						</div>
					</div>

				<% } %>
			</div>

			<div class="success" style="display: none;">
				You may <a href="<%= VirtualPathUtility.ToAbsolute(Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.LoginUrl) %>">login</a> with your new password to continue.
			</div>
		</div>
	</div>
</div>