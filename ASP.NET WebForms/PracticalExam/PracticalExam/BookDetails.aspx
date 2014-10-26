<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="PracticalExam.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>
    <asp:FormView ID="FormViewBook" runat="server"
        ItemType="PracticalExam.Models.Book">
        <ItemTemplate>
            <p class="book-title"><strong><%#: Item.Title %></strong></p>
            <p class="book-author">by <strong><%#: Item.Author %></strong></p>
            <p class="book-isbn">ISBN: <strong><%#: Item.ISBN %></strong></p>
            <p class="book-site">Web site: <strong><a href="<%#: Item.WebSite %>"><%#: Item.WebSite %></a></strong></p>
            <div class="row fluid">
                <p><%#: Item.Description %></p>
            </div>
            <div class="back-link"><a href="/">Back to books</a></div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
