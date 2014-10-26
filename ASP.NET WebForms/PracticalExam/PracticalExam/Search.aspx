<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="PracticalExam.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Results for Query "<asp:Literal ID="LiteralSearchTitle" runat="server" />"</h1>
    <asp:Repeater ID="RepeaterSearchResults" runat="server" ItemType="PracticalExam.Models.Book">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href="#"><%#: Item.Title %> by <%#: Item.Author %></a> (Category: <%#: Item.Category.Title %>)
            </li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
    <a href="/">Back to books</a>
</asp:Content>
