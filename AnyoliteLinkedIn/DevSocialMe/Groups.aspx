<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="DevSocialMe.Groups" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>All groups</h1>
    <asp:GridView runat="server" ID="GridViewAllGroups" DataKeyNames="GroupId"
        ItemType="DevSocialMe.Models.Group" PageSize="3" AllowPaging="true" AllowSorting="true"
        SelectMethod="GridViewAllGroups_GetData" CssClass="table table-hover table-bordered"
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
                    <asp:Button Text="Join" class="btn btn-primary" ID="ButtonJoinGroup" CommandName="JoinGroup"
                        CommandArgument="<%# Item.GroupId %>"
                        OnCommand="ButtonJoinGroup_Command" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h1>My Groups</h1>
    <asp:GridView runat="server" ID="GridViewMyGroups" DataKeyNames="GroupId"
        PageSize="3" AllowPaging="true" AllowSorting="true" CssClass="table table-hover table-bordered"
        SelectMethod="GridViewMyGroups_GetData" ItemType="DevSocialMe.Models.Group"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="CreationData" HeaderText="CreatedData" SortExpression="CreationData" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" class="btn btn-primary"
                        NavigateUrl='<%#: String.Format("GroupEdit.aspx?id={0}", Item.GroupId) %>' Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <h1>Joined Groups</h1>
    <asp:GridView runat="server" ID="GridViewJoinedGroups" DataKeyNames="GroupId" CssClass="table table-hover table-bordered"
        PageSize="3" AllowPaging="true" AllowSorting="true"
        SelectMethod="GridViewJoinedGroups_GetData" ItemType="DevSocialMe.Models.Group"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Creator" HeaderText="Creator" SortExpression="Creator" />
            <asp:BoundField DataField="CreationData" HeaderText="CreatedData" SortExpression="CreationData" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" class="btn btn-primary"
                        NavigateUrl='<%#: String.Format("GroupView.aspx?id={0}", Item.GroupId) %>' Text="View" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <a runat="server" href="CreateGroup.aspx">CreateGroup</a>
</asp:Content>
