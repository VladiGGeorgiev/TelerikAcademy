<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Messages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager" runat="server" />
        
        <asp:UpdatePanel ID="UpdatePanelMessages" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:ListView runat="server" ID="ListViewMessages" ItemType="Messages.Message">
                    <ItemTemplate>
                        <p><%#: Item.Text %></p>
                    </ItemTemplate>
                </asp:ListView>
                <asp:TextBox ID="NewMessage" runat="server" />
                <br />
                <asp:Button ID="AddMessage" runat="server" Text="Send" OnClick="AddMessage_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
