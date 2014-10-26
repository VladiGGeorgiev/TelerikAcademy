<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="DisplayEmployees.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/bootstrap.css" rel="stylesheet" />
    <link href="styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:EntityDataSource ID="EntityDataSourceEmployees" runat="server" 
            ConnectionString="name=NORTHWNDEntities" 
            DefaultContainerName="NORTHWNDEntities" 
            EnableDelete="True" 
            EnableInsert="True" 
            EnableUpdate="True" 
            EntitySetName="Employees">
        </asp:EntityDataSource>
        <asp:DetailsView CssClass="table table-hover" ID="DetailsViewEmployeeDetails" runat="server" Height="50px" Width="125px"></asp:DetailsView>
    </form>
</body>
</html>
