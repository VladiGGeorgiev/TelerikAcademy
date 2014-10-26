<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ASP.NET_Web_Forms_User_Controls.Index" %>
<%@ Register tagprefix="userControls"
Assembly="ASP.NET Web Forms User Controls"
Namespace="ASP.NET_Web_Forms_User_Controls"%>

<%@ Register src="MyMenu.ascx" tagname="MyMenu"
tagprefix="userControls" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <userControls:MyMenu runat="server" ID="linkMenu" >
        <Items>
            <userControls:MenuItem Title="YouTube" Href="http://www.youtube.com/" runat="server" />
            <userControls:MenuItem Title="Google" Href="http://www.google.com/" runat="server" />
            <userControls:MenuItem Title="Facebook" Href="http://www.facebook.com/" runat="server" />
            <userControls:MenuItem Title="Twitter" Href="http://www.twitter.com/" runat="server" />
        </Items>
    </userControls:MyMenu>
    </div>
    </form>
</body>
</html>
