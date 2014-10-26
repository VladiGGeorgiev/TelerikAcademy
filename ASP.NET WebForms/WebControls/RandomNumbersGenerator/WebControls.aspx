<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebControls.aspx.cs" Inherits="RandomNumbersGenerator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random generator</title>
    <link href="styles/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <label for="startNumber">From: </label>
        <asp:TextBox runat="server" ID="startNumber"></asp:TextBox>
        <label for="endNumber">To: </label>
        <asp:TextBox runat="server" ID="endNumber"></asp:TextBox>
        <asp:Button CssClass="btn btn-danger" runat="server" Text="Generate number" ID="GenerateNumber" OnClick="GenerateNumber_Click"/>  
    </form>
    <asp:Label runat="server" ID="generatedNumber"></asp:Label>
</body>
</html>
