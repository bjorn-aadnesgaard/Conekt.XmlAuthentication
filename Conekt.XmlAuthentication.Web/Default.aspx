<%@ Page Language="C#" MasterPageFile="~/Demo/Demo.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Conekt.XmlAuthentication.Web.Default" %>
<%@ Register TagPrefix="Demo" TagName="landing" Src="~/App_UserControls/Demo/Content/Landing.ascx" %>

<asp:Content ContentPlaceHolderID="head" runat="server" />
<asp:Content ContentPlaceHolderID="content" runat="server">
	<Demo:Landing runat="server" />
</asp:Content>