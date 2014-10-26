<%@ Page Title="Edit Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DevSocialMe.Admin.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>DevSocialMe all users</h1>
    <asp:GridView CssClass="table table-hover" runat="server" ID="GridViewAllUsers" ItemType="DevSocialMe.Models.ApplicationUser"
        PageSize="10" AllowPaging="true" AllowSorting="true" SelectMethod="GridViewAdminUsers_GetData"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink CssClass="navbar-link" ID="userEditAdminLink" runat="server" 
                        NavigateUrl='<%#: String.Format("UserEdit.aspx?id={0}", Item.Id) %>' Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
