<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AllEmployeesInfoRepeater.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:EntityDataSource ID="EntityDataSourceEmployees" runat="server" 
            ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" 
            EnableFlattening="False" 
            EntitySetName="Employees">
        </asp:EntityDataSource>
        
        <asp:Repeater ID="RepeaterTemplatedEmployees" runat="server" 
            DataSourceID="EntityDataSourceEmployees"  ItemType="AllEmployeesInfoRepeater.Employee">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            
            <ItemTemplate>
                <li>
                    <p><%#: Item.FirstName + " " + Item.LastName %></p>
                    <p><%#: Item.Address %></p>
                    <p><%#: Item.BirthDate %></p>
                    <p><%#: Item.City %></p>
                    <p><%#: Item.Country %></p>
                    <p><%#: Item.Extension %></p>
                    <p><%#: Item.HireDate %></p>
                    <p><%#: Item.HomePhone %></p>
                    <p><%#: Item.Notes %></p>
                    <p><%#: Item.PhotoPath %></p>
                    <p><%#: Item.PostalCode %></p>
                    <p><%#: Item.Region %></p>
                    <p><%#: Item.Title %></p>
                    <p><%#: Item.TitleOfCourtesy %></p>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        
    </form>
</body>
</html>
