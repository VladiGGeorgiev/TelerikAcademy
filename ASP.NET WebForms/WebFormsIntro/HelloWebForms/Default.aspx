<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelloWebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" CssClass="label-info" ID="LabelName" Text="Your name:" AssociatedControlID="TextBoxName"></asp:Label>
        <asp:TextBox runat="server" CssClass="input-sm" ID="TextBoxName"></asp:TextBox>
        <asp:Button ID="Button" CssClass="btn btn-info" OnClick="Button_Click" Text="Say hallo" runat="server"/>
    </form>
    <asp:Label runat="server" ID="HelloContainer"></asp:Label>
</body>
</html>
