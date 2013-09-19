<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Account-Create.ascx.cs" Inherits="Conekt.XmlAuthentication.Web.App_UserControls.Xml.Authentication.Account_Create" %>

<div class="container login">
	<div class="panel panel-default create">

		<%--Heading--%>
		<div class="panel-heading">
			<h3 class="panel-title">Create an account for <%= Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName %></h3>
		</div>

		<%--Body--%>
		<div class="panel-body">
			<div class="alert" style="display: none">
				<button type="button" class="close" data-hide="alert">&times;</button>
				<div></div>
			</div>

			<div class="content">
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
						<input class="btn btn-primary" data-loading-text="Creating" type="submit" value="Create" onclick="xmlauth.accountCreate(); return false;" />
					</div>
				</div>
			</div>
			
			<div class="success" style="display: none;">
				Success.
			</div>
		</div>

		<%--Footer--%>
		<div class="panel-footer anonymous">
			<div>Already have an account? <a href="/#!/login" onclick="xmlauth.load('login');">Login</a>.</div>
		</div>

	</div>
</div>