<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChatCanal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-unit">
        <h1>Posts</h1>
    </div>

    <asp:ListView
        ID="ListViewPosts"
        DataKeyNames="Id"
        ItemType="ChatCanal.Models.Post"
        SelectMethod="ListViewPosts_GetData"
        InsertMethod="ListViewPosts_InsertItem"
        DeleteMethod="ListViewPosts_DeleteItem"
        UpdateMethod="ListViewPosts_UpdateItem"
        runat="server">
        <LayoutTemplate>
            <span runat="server" id="itemPlaceholder"></span>
        </LayoutTemplate>

        <EmptyDataTemplate>
            <p>No posts.</p>
        </EmptyDataTemplate>

        <ItemTemplate>
            <div>
                <asp:Literal
                    ID="LiteralPost"
                    runat="server" Mode="Encode" Text="<%# Item.Text %>">
                </asp:Literal>
                <% if (User.IsInRole("Admin"))
                   { %>
                <asp:LinkButton runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                <% } %>

                <% if (User.IsInRole("Admin") || User.IsInRole("Moderator"))
                   { %>
                <asp:LinkButton runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                <%} %>
            </div>
        </ItemTemplate>

        <EditItemTemplate>
            <asp:TextBox ID="TextBoxEditPost" runat="server" Text='<%#: Bind("Text") %>'></asp:TextBox>
            <asp:LinkButton ID="LinkButtonUpdatePost" CommandName="Update" runat="server">Update</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonCancel" CommandName="Cancel" runat="server">Cancel</asp:LinkButton>
        </EditItemTemplate>

        <InsertItemTemplate>
            <% if (User.Identity.IsAuthenticated) { %>
            <asp:TextBox ID="TextBoxInsertPost" Text='<%# Bind("Text") %>' runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButtonInsertPost" CommandName="Insert" runat="server">Inset Post</asp:LinkButton>
            <%} else { %>
            <p>Login to create posts.</p>
            <%} %>
        </InsertItemTemplate>
    </asp:ListView>

</asp:Content>
