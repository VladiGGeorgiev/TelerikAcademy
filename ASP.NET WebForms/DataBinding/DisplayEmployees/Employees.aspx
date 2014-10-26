<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="DisplayEmployees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/bootstrap.css" rel="stylesheet" />
    <link href="styles/Site.css" rel="stylesheet" />
</head>
<body>
    <h1>All employees</h1>
    <form id="form1" runat="server">
        <asp:EntityDataSource ID="EntityDataSourceEmployees" runat="server" 
            ConnectionString="name=NORTHWNDEntities" 
            DefaultContainerName="NORTHWNDEntities" 
            EnableDelete="True" 
            EnableFlattening="False" 
            EnableInsert="True" 
            EnableUpdate="True" 
            EntitySetName="Employees">
        </asp:EntityDataSource>
        <asp:GridView 
            CssClass="table table-hover" 
            ID="GridView1" runat="server" 
            AllowPaging="True" 
            AllowSorting="True" 
            AutoGenerateColumns="False" 
            DataKeyNames="EmployeeID" 
            DataSourceID="EntityDataSourceEmployees">
            
            <Columns>
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:HyperLinkField Text="Get more info" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="EmpDetails.aspx?EmployeeID={0}" /> 
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
