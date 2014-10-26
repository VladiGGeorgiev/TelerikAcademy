<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Locations.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server" 
            ConnectionString="name=LocationsEntities" 
            DefaultContainerName="LocationsEntities" 
            EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
            EntitySetName="Continents">
        </asp:EntityDataSource>

        <asp:ListBox ID="ListBoxContinents" runat="server" 
            DataSourceID="EntityDataSourceContinents" 
            DataTextField="Name"
            DataValueField="ContinentId"
            AutoPostBack="True"
            OnSelectedIndexChanged="ListBoxContinents_OnSelectedIndexChanged">
            
        </asp:ListBox>
        
        <h2 ID="CountriesTitle" runat="server"></h2>
        <asp:GridView ID="GridViewCountries" runat="server"
            AllowPaging="True" AllowSorting="True"
            DataKeyNames="CountryId" AutoGenerateColumns="False"
            OnSelectedIndexChanged="GridViewCountries_OnSelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ShowEditButton="True" ShowInsertButton="True" ShowDeleteButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language"/>
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population"/>
            </Columns>
        </asp:GridView>
        
        <h2 ID="TownsTitle" runat="server"></h2>
        <asp:ListView ID="ListViewTowns" ItemType="Locations.Town" runat="server">
            <LayoutTemplate>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="town">
                    Town name: <%#: Item.Name %> <br/>
                    Population: <%#: Item.Population %> <br/>
                </div>
            </ItemTemplate>
        </asp:ListView>
        
    </form>
</body>
</html>
