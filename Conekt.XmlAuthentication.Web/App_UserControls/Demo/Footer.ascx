<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Conekt.XmlAuthentication.Web.App_UserControls.Demo.Footer" %>

<div id="navbar" class="navbar navbar-inverse navbar-fixed-bottom quickmenu" role="navigation">
	<div class="navbar-inner">
		<ul class="nav navbar-nav">
			<li><a href="/#!/create" onclick="xmlauth.load('create');">Create Account</a></li>
			<li><a href="/#!/login" onclick="xmlauth.load('login');">Login</a></li>
			<li><a href="/#!/reset" onclick="xmlauth.load('reset');">Recover Password</a></li>
		</ul>
	</div>
</div>

<%--Script references--%>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0-rc2/js/bootstrap.min.js"></script>
<script src="/assets/scripts/xmlauthentication.min.js"></script>
<script src="/assets/scripts/demo.min.js"></script>