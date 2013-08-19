<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Landing.ascx.cs" Inherits="Conekt.XmlAuthentication.Web.App_UserControls.Demo.Content.Landing" %>

<%--Header--%>
<div class="jumbotron" id="overview">
	<div class="container">
		
		<h1>ASP.NET XML Authentication</h1>

		<p>
			Custom authentication for ASP.NET using XML
		</p>

		<a href="/#!/login" onclick="xmlauth.load('login');" class="btn btn-outline btn-large">View Demo</a>

		<ul class="jumbotron-links">
			<li>
				<a href="<%= ConfigurationSettings.AppSettings["GitHubProjectUrl"].ToString() %>">GitHub project</a>
			</li>
			<li>
				<a href="<%= ConfigurationSettings.AppSettings["GitHubDownloadUrl"].ToString() %>">Download from GitHub</a>
			</li>
			<li>Version 1.0.0</li>
		</ul>
	</div>
</div>

<%--Content--%>
<div class="container">
	<div class="row-fluid">
		<div class="readme"></div>
	</div>
</div>