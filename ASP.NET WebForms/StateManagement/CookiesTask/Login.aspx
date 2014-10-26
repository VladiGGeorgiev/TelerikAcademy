<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CookiesTask.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label AssociatedControlID="TextBoxInputName" Text="Enter your name" runat="server" /> <br />
        <asp:TextBox ID="TextBoxInputName" runat="server" />
        <asp:Button ID="ButtonSendName" OnClick="ButtonSendName_Click" Text="Send" runat="server" />
    </form>
</body>
</html>
