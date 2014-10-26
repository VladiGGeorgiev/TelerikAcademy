<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="PracticalExam.Admin.EditBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView CssClass="gridview" ID="GridViewBooks" runat="server"
        AutoGenerateColumns="false" DataKeyNames="BookId"
        AllowSorting="true" 
        ItemType="PracticalExam.Models.Book"
        AllowPaging="true" PageSize="5"
        OnPageIndexChanging="GridViewBooks_PageIndexChanging"
        OnSorting="GridViewBooks_Sorting">
        <Columns>
            <asp:TemplateField  HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <%#: Item.Title.Count() > 20 ? Item.Title.Substring(0, 20) + "..." : Item.Title %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="Author" SortExpression="Author">
                <ItemTemplate>
                    <%#: Item.Author.Count() > 20 ? Item.Author.Substring(0, 20) + "..." : Item.Author %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="ISBN" SortExpression="ISBN">
                <ItemTemplate>
                    <%#: Item.ISBN %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="Web site" SortExpression="WebSite">
                <ItemTemplate>
                    <%#: Item.WebSite != null ? (Item.WebSite.Count() > 20 ? Item.WebSite.Substring(0, 20) + "..." : Item.WebSite) : "" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="Category Name" SortExpression="Category">
                <ItemTemplate>
                    <%#: Item.Category.Title.Count() > 20 ? Item.Category.Title.Substring(0, 20) + "..." : Item.Category.Title %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton Text="Edit" CssClass="link-button" ID="ButtonShowEditForm" runat="server" 
                        CommandArgument="<%# Item.BookId %>" OnCommand="ButtonShowEditForm_Command" />
                    <asp:LinkButton Text="Delete" CssClass="link-button" ID="ShowDeleteForm" runat="server" 
                        CommandArgument="<%# Item.BookId %>" OnCommand="ShowDeleteForm_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    
    <asp:FormView CssClass="panel" ID="FormViewEditBook" runat="server"
        ItemType="PracticalExam.Models.Book"
        DataKeyNames="BookId">
        <HeaderTemplate>
            <h2>Edit Book</h2>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Label Text="Title:" AssociatedControlID="TextBoxEditBookTitle" runat="server" />
            <asp:TextBox ID="TextBoxEditBookTitle" Text="<%# BindItem.Title %>" runat="server" />
            
            <asp:Label Text="Author(s):" AssociatedControlID="TextBoxEditBookAuthor" runat="server" />
            <asp:TextBox ID="TextBoxEditBookAuthor" Text="<%# BindItem.Author %>" runat="server" />

            <asp:Label Text="ISBN:" AssociatedControlID="TextBoxEditBookISBN" runat="server" />
            <asp:TextBox ID="TextBoxEditBookISBN" Text="<%# BindItem.ISBN %>" runat="server" />
            
            <asp:Label Text="Web site" AssociatedControlID="TextBoxEditBookWebSite" runat="server" />
            <asp:TextBox ID="TextBoxEditBookWebSite" Text="<%# BindItem.WebSite %>" runat="server" />
            
            <asp:Label Text="Description:" AssociatedControlID="TextBoxEditBookDescription" runat="server" />
            <asp:TextBox ID="TextBoxEditBookDescription" Text="<%# BindItem.Description %>" runat="server" />
            
            <asp:Label Text="Category:" AssociatedControlID="DropDownListEditCategories" runat="server" />
            <asp:DropDownList ID="DropDownListEditCategories" DataValueField="CategoryId" DataTextField="Title" runat="server">
            </asp:DropDownList>
            <br />
            <asp:LinkButton ID="SaveEditedBook"  CssClass="link-button"  CommandArgument="<%# Item.BookId %>" OnCommand="SaveEditedBook_Command" Text="Save" runat="server" />
            <asp:LinkButton ID="CancelEditedBook" CssClass="link-button"  CommandArgument="<%# Item.BookId %>" OnCommand="CancelEditedBook_Command" Text="Cancel" runat="server" />
        </ItemTemplate>
    </asp:FormView>

    
    <asp:FormView CssClass="panel" ID="FormViewDeleteBook" runat="server"
        ItemType="PracticalExam.Models.Book"
        DataKeyNames="BookId">
        <HeaderTemplate>
            <h2>Confirm Book Deletion?</h2>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Label Text="Title" AssociatedControlID="TextBoxEditBook" runat="server" />
            <asp:TextBox ID="TextBoxEditBook" Text="<%# BindItem.Title %>"  runat="server" disabled="disabled" />
            <asp:LinkButton  CssClass="link-button"  ID="LinkButtonDeleteBook" CommandArgument="<%# Item.BookId %>" OnCommand="LinkButtonDeleteBook_Command" Text="YES" runat="server" />
            <asp:LinkButton  CssClass="link-button"  ID="LinkButtonCancelDeleteBook" OnCommand="LinkButtonCancelDeleteBook_Command" Text="No" runat="server" />
        </ItemTemplate>
    </asp:FormView>
    <br />
    <asp:LinkButton CssClass="link-button" ID="LinkButtonShowCreateBookForm" OnCommand="LinkButtonShowCreateBookForm_Command" Text="Create new book" runat="server" />
    <asp:Panel  CssClass="panel"  ID="PanelCreateBook" runat="server" Visible="false">
        <h2>Create New Book</h2>
        <asp:Label Text="Title:" AssociatedControlID="TextBoxAddBookTitle" runat="server" />
        <asp:TextBox ID="TextBoxAddBookTitle" Text="" runat="server" />
        
        <asp:Label Text="Author:" AssociatedControlID="TextBoxAddBookAuthor" runat="server" />
        <asp:TextBox ID="TextBoxAddBookAuthor" Text="" runat="server" />
        
        <asp:Label Text="ISBN:" AssociatedControlID="TextBoxAddBookISBN" runat="server" />
        <asp:TextBox ID="TextBoxAddBookISBN" Text="" runat="server" />
        
        <asp:Label Text="Web site:" AssociatedControlID="TextBoxAddBookWebSite" runat="server" />
        <asp:TextBox ID="TextBoxAddBookWebSite" Text="" runat="server" />
        
        <asp:Label Text="Description:" AssociatedControlID="TextBoxAddBookDescription" runat="server" />
        <asp:TextBox ID="TextBoxAddBookDescription" Text="" runat="server" />
        
        <asp:Label Text="Category:" AssociatedControlID="DropDownListCategories" runat="server" />
        <asp:DropDownList ID="DropDownListCategories" DataValueField="CategoryId" DataTextField="Title" runat="server">
        </asp:DropDownList>

        <br />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonCreateBook" OnCommand="LinkButtonCreateBook_Command" Text="Save" runat="server" />
        <asp:LinkButton CssClass="link-button" ID="LinkButtonCancelCreateBook" OnCommand="LinkButtonCancelCreateBook_Command" Text="Cancel" runat="server" />
    </asp:Panel>
    <br />
    <br />
    <a href="/">Back to books</a>
</asp:Content>
