<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EscapingTask.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" ID="inputText"></asp:TextBox>
        <asp:Button runat="server" ID="Button" OnClick="Button_Click" Text="Show text"/>
    </form>
    <asp:Label runat="server" ID="outputText"></asp:Label>
</body>
</html>
