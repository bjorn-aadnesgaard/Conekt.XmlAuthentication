<%@ Page Language="C#" MasterPageFile="~/Demo/Demo.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Conekt.XmlAuthentication.Web.Demo.Default" %>
<%@ Register TagPrefix="XmlAuth" TagName="AccountCreate" Src="~/App_UserControls/Xml/Authentication/Account-Create.ascx" %>

<asp:Content ContentPlaceHolderID="head" runat="server" />
<asp:Content ContentPlaceHolderID="content" runat="server">
	<XmlAuth:AccountCreate runat="server" />
</asp:Content>
