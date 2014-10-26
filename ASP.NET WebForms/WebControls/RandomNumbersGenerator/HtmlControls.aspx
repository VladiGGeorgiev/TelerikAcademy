<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlControls.aspx.cs" Inherits="RandomNumbersGenerator.HtmlControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <input type="number" runat="server" ID="startNumber" name="name" value="" placeholder="Start number" />
        <input type="number" runat="server" ID="endNumber" name="name" value="" placeholder="End number" />
        <input type="button" class="btn btn-info" runat="server" ID="ButtonGenerateNumber" OnServerClick="ButtonGenerateNumber_Click" name="name" value="Generate number" />
    </form>
    <div runat="server" id="generatedNumber"></div>
</body>
</html>
