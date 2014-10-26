<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="MyMenu.ascx.cs"
    Inherits="DevSocialMe.MyMenu" %>

<asp:Repeater runat="server" ID="menuList">
    <ItemTemplate>
        <li>
            <asp:HyperLink
                NavigateUrl='<%# String.Format("{0}", Eval("Href"))%>'
                Text='<%#: String.Format("{0}", Eval("Title"))%>'
                runat="server" />
        </li>
    </ItemTemplate>
</asp:Repeater>
