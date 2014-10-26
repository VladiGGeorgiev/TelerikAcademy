<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Employees_Orders.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager" runat="server" />
        Employees
        <asp:GridView runat="server" ID="GridViewEmployees" OnSelectedIndexChanging="GridViewEmployees_SelectedIndexChanging"
                     DataKeyNames="EmployeeID" AutoGenerateColumns="false" ItemType="Employees_Orders.Employee">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <th>Name</th>
                                <th>Title</th>
                                <th>Phone</th>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Button runat="server" CommandName="Select" Text="Select" CommandArgument="<%# Item.EmployeeID %>" OnCommand="Unnamed_Command" />
                                <td><%#: Item.FirstName + " " + Item.LastName %></td>
                                <td><%#: Item.Title %></td>
                                <td><%#: Item.HomePhone %></td>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        
        Orders:
        <asp:UpdatePanel ID="UpdatePanelORders" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
               <asp:GridView ID="GridViewOrders" runat="server"  AutoGenerateColumns="false" ItemType="Employees_Orders.Order">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <td><%#: Item.RequiredDate %></td>
                                <td><%#: Item.ShipAddress %></td>
                                <td><%#: Item.ShipName %></td>
                                <td><%#: Item.OrderDate %></td>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:UpdateProgress ID="UpdateProgressDemo" runat="server">
            <ProgressTemplate>
                Updating ...
            </ProgressTemplate>
        </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>
    </form>
</body>
</html>
