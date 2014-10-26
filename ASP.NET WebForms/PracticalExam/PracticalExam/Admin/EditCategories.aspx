<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" 
    Inherits="PracticalExam.Admin.EditCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView CssClass="gridview"  ID="GridViewCategories" runat="server"
        AutoGenerateColumns="false" DataKeyNames="CategoryId"
        AllowSorting="true" 
        ItemType="PracticalExam.Models.Category"
        AllowPaging="true" PageSize="5"
        OnPageIndexChanging="GridViewCategories_PageIndexChanging"
        OnSorting="GridViewCategories_Sorting"
        >
        <Columns>
            <asp:TemplateField  HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <%#: Item.Title.Count() > 20 ? Item.Title.Substring(0, 20) + "..." : Item.Title %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton  CssClass="link-button"  Text="Edit" ID="ButtonShowEditForm" runat="server" 
                        CommandArgument="<%# Item.CategoryId %>" OnCommand="ButtonShowEditForm_Command" />
                    <asp:LinkButton CssClass="link-button" Text="Delete" ID="ShowDeleteForm" runat="server" 
                        CommandArgument="<%# Item.CategoryId %>" OnCommand="ShowDeleteForm_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:FormView CssClass="panel" ID="FormViewEditCategory" runat="server"
        ItemType="PracticalExam.Models.Category"
        DataKeyNames="CategoryId">
        <HeaderTemplate>
            <h2>Edit Category</h2>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Label Text="Category" AssociatedControlID="TextBoxEditCategory" runat="server" />
            <asp:TextBox ID="TextBoxEditCategory" Text="<%# BindItem.Title %>" runat="server" />
            <br />
            <asp:LinkButton CssClass="link-button" ID="SaveEditedCategory" CommandArgument="<%# Item.CategoryId %>" OnCommand="SaveEditedCategory_Command" Text="Save" runat="server" />
            <asp:LinkButton CssClass="link-button" ID="CancelEditCategory" CommandArgument="<%# Item.CategoryId %>" OnCommand="CancelEditCategory_Command" Text="Cancel" runat="server" />
        </ItemTemplate>
    </asp:FormView>
    
    <asp:FormView CssClass="panel" ID="FormViewDeleteCategory" runat="server"
        ItemType="PracticalExam.Models.Category"
        DataKeyNames="CategoryId">
        <HeaderTemplate>
            <h2>Delete Category</h2>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="panel">
            <asp:Label Text="Category" AssociatedControlID="TextBoxEditCategory" runat="server" />
            <asp:TextBox ID="TextBoxEditCategory" Text="<%# BindItem.Title %>"  runat="server" disabled="disabled" />
            <br />
            <asp:LinkButton CssClass="link-button" ID="LinkButtonDeleteCategory" CommandArgument="<%# Item.CategoryId %>" OnCommand="LinkButtonDeleteCategory_Command" Text="OK" runat="server" />
            <asp:LinkButton CssClass="link-button" ID="LinkButtonCancelDeleteCategory" OnCommand="LinkButtonCancelDeleteCategory_Command" Text="Cancel" runat="server" />
            </div>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <asp:LinkButton CssClass="link-button" ID="LinkButtonShowCreateCategory" OnCommand="LinkButtonShowCreateCategory_Command" Text="Create category" runat="server" />
    <asp:Panel CssClass="panel" ID="PanelCreateCategory" runat="server" Visible="false">
            <h2>Create New Category</h2>
            <asp:Label Text="Category" AssociatedControlID="TextBoxAddCategory" runat="server" />
            <asp:TextBox ID="TextBoxAddCategory" Text="" runat="server" />
            <br />
            <asp:LinkButton CssClass="link-button" ID="LinkButtonCreateCategory" OnCommand="LinkButtonCreateCategory_Command" Text="Create" runat="server" />
            <asp:LinkButton CssClass="link-button" ID="LinkButtonCancelCreateCategory" OnCommand="LinkButtonCancelCreateCategory_Command" Text="Cancel" runat="server" />
    </asp:Panel>
    <br />
    <br />
    <a href="/">Back to books</a>
</asp:Content>
