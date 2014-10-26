<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PracticalExam._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Books</h1>
    <div class="search-button">
        <asp:TextBox ID="TextBoxSearch" runat="server" />
        <asp:LinkButton ID="LinkButtonSearch" Text="Seach" OnCommand="LinkButtonSearch_Command" runat="server" />
    </div>
    <asp:ListView ID="ListViewCategories" runat="server"
        ItemType="PracticalExam.Models.Category">
        <LayoutTemplate>
            <div id="ItemPlaceholder" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="category-container">
                <h2><%#: Item.Title %></h2>
                <asp:Repeater ID="RepeaterBooks" runat="server"
                    ItemType="PracticalExam.Models.Book"
                    DataSource="<%# Item.Books %>">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="BookDetails?id=<%# Item.BookId %>">
                                "<%#: Item.Title %>"
                                <i>by <%#: Item.Author %></i>
                            </a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Literal ID="NoResults" runat="server" />
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
