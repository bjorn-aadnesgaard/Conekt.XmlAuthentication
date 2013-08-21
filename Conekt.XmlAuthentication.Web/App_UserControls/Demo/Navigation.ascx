<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="Conekt.XmlAuthentication.Web.App_UserControls.Demo.Navigation" %>

<div id="navbar" class="navbar navbar-inverse navbar-fixed-top" role="navigation">
    <div class="navbar-inner">
		
		<ul class="nav navbar-nav projects">
			<li class="dropdown">
				<a class="dropdown-toggle" data-toggle="dropdown">
					<span class="navbar-toggle">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</span>
				</a>
				<ul class="dropdown-menu pull-left">
					<li><a href="#">
						<span class="glyphicon glyphicon-shopping-cart"></span>
						<h4>Billing</h4>
						<h6>Coming soon</h6>
					</a></li>
					<li class="active"><a href="/">
						<span class="glyphicon glyphicon-lock"></span>
						<h4>ASP.NET XML Authentication</h4>
						<h6>Custom authentication for ASP.NET using XML</h6>
					</a></li>
				</ul>
			</li>
		</ul>
			
		<div class="navbar-header">
			<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
				<span class="sr-only">Toggle navigation</span>
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
			</button>
			<a class="navbar-brand" href="/#!/" onclick="xmldemo.start();">
				<%= Conekt.XmlAuthentication.Configuration.ConfigurationManager.GetConfiguration().Settings.ApplicationName %>
			</a>
		</div>

		<div class="collapse navbar-collapse navbar-ex1-collapse navbar-right">
			<ul class="nav navbar-nav">
				<li><a href="<%= ConfigurationSettings.AppSettings["GitHubDownloadUrl"].ToString() %>" title="Coming soon">
					<i class="glyphicon glyphicon-download"></i>
					Download from GitHub
				</a></li>
			</ul>
		</div>

    </div>
</div>