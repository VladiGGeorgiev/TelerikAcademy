<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeesWithFormView.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:EntityDataSource ID="EntityDataSourceEmployeesNames" runat="server" 
            ConnectionString="name=NorthwndEntities" 
            DefaultContainerName="NorthwndEntities" 
            EnableFlattening="False" 
            EntitySetName="Employees">
        </asp:EntityDataSource>
        
        <asp:GridView ID="GridViewEmployees" 
            runat="server" 
            ItemType="EmployeesWithFormView.Employee"
            AllowPaging="True"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataSourceID="EntityDataSourceEmployeesNames"
            DataKeyNames="EmployeeID"
            OnSelectedIndexChanged="GridViewEmployee_OnSelectedIndexChanged"
            >
            
            <Columns>
                <asp:CommandField ShowSelectButton="True"/>
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            </Columns>
        </asp:GridView>
        
        <asp:FormView 
            ID="FormViewEmployee" runat="server" 
            DataSourceID="EntityDataSourceEmployeesNames"
            ItemType="EmployeesWithFormView.Employee">
            <ItemTemplate>
                Name: <strong><strong><%#: Item.FirstName + " " + Item.LastName %></strong></strong> <br/>
                Address: <strong><%#: Item.Address%></strong> <br/>
                BirthDate: <strong><%#: Item.BirthDate %></strong> <br/>
                City: <strong><%#: Item.City%></strong> <br/>
                Country: <strong><%#: Item.Country %></strong> <br/>
                Employee1: <strong><%#: Item.Employee1.FirstName + " " + Item.Employee1.LastName %></strong> <br/>
                Extension: <strong><%#: Item.Extension%></strong> <br/>
                HireDate: <strong><%#: Item.HireDate%></strong> <br/>
                HomePhone: <strong><%#: Item.HomePhone%></strong> <br/>
                Notes: <strong><%#: Item.Notes%></strong> <br/>
                PhotoPath: <strong><%#: Item.PhotoPath%></strong> <br/>
                PostalCode: <strong><%#: Item.PostalCode%></strong> <br/>
                Region: <strong><%#: Item.Region %></strong> <br/>
                ReportsTo: <strong><%#: Item.ReportsTo%></strong> <br/>
                Title: <strong><%#: Item.Title%></strong> <br/>
                TitleOfCourtesy: <strong><%#: Item.TitleOfCourtesy%></strong> <br/>
            </ItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
