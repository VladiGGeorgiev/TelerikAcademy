<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="MyMenu.ascx.cs" 
    Inherits="ASP.NET_Web_Forms_User_Controls.MyMenu" %>

<asp:DataList runat="server" ID="menuList">

    <ItemTemplate>

        <a href="<%#: Eval("Href") %>"><%#: Eval("Title") %> </a>
    </ItemTemplate>

</asp:DataList>