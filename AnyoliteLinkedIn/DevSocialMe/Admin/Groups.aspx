<%@ Page Title="Edit Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="DevSocialMe.Admin.Groups" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>DevSocialMe all groups</h1>
    <asp:GridView CssClass="table table-hover" runat="server" ID="GridViewAllGroups" DataKeyNames="GroupId"
        ItemType="DevSocialMe.Models.Group" PageSize="10" AllowPaging="true" AllowSorting="true"
        SelectMethod="GridViewAllGroups_GetData"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="CreationData" HeaderText="CreatedData"
                SortExpression="CreationData" />
            <asp:BoundField DataField="Creator" HeaderText="Creator"
                SortExpression="Creator" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Button Text="DELETE" CssClass="btn-block" ID="ButtonDeleteGroup" CommandName="DeleteGroup"
                        CommandArgument="<%# Item.GroupId %>"
                        OnCommand="ButtonDeleteGroup_Command" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink CssClass="navbar-link" ID="HyperLink1" runat="server" 
                        NavigateUrl='<%#: String.Format("GroupEdit.aspx?id={0}", Item.GroupId) %>' Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
