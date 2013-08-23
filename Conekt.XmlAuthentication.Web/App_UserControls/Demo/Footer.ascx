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
<script src="//cdnjs.cloudflare.com/ajax/libs/pagedown/1.0/Markdown.Converter.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/pagedown/1.0/Markdown.Sanitizer.min.js" ></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/highlight.js/7.3/highlight.min.js"></script>
<script src="/assets/scripts/jquery.base64<%= HttpContext.Current.IsDebuggingEnabled ? "" : ".min"  %>.js"></script>
<script src="/assets/scripts/xmlauthentication<%= HttpContext.Current.IsDebuggingEnabled ? "" : ".min"  %>.js"></script>
<script src="/assets/scripts/demo<%= HttpContext.Current.IsDebuggingEnabled ? "" : ".min"  %>.js"></script>

<script>
	hljs.tabReplace = '    ';
	hljs.initHighlightingOnLoad();
</script>