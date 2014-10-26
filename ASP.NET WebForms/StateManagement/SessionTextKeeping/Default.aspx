<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SessionTextKeeping.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MainForm" runat="server">
        <asp:TextBox ID="TextBoxInput" runat="server" />
        <asp:Button ID="ButtonSaveText" OnClick="ButtonSaveText_Click" Text="Save text" runat="server" />
    </form>
    <asp:Label ID="LabelOutputText" runat="server" />
</body>
</html>
