<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DevSocialMe.Profile" %>

<asp:Content ID="ContentProfile" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Profile of <%#: Request.Params["username"]  %></h1>
    <asp:Image runat="server" ID="ImageUser" CssClass="profileImage img-rounded" />
    <br />
    <span class="boldText">Full Name:</span>
    <asp:Literal runat="server" ID="LiteralFullName" />
    <br />
    <span class="boldText">Email:</span>
    <asp:Literal runat="server" ID="LiteralEmail" />
    <br />
    <span class="boldText">Summary:</span>
    <asp:Literal runat="server" ID="LiteralSummary" />

    <h2>
        <asp:Literal runat="server" ID="LiteralSkills" /></h2>
    <ul runat="server" class="skillsList">
        <asp:Repeater runat="server" ItemType="DevSocialMe.Models.Skill" ID="RepeaterSkills">
            <ItemTemplate>
                <li class="skillsLines"><span class="skillInfo"><span class="boldText">Name: </span><%#: Item.Name %> <span class="boldText">Votes: <%# Item.Votes.Count() %></span></span>
                    <asp:Button Text="Endorce" runat="server" CommandName="Endorce" CssClass="btn btn-info endorceBtn" ID="ButtonEndorce" CommandArgument="<%# Item.Name %>" OnCommand="ButtonEndorce_Command" />
                    <asp:Repeater runat="server" DataSource="<%# Item.Votes %>" ItemType="DevSocialMe.Models.Vote">
                        <ItemTemplate>
                            <asp:ImageButton class="img-rounded" ImageUrl="<%#Item.User.AvatarUrl %>"
                                runat="server" ID="ImageButtonViewProfile" CommandName="View"
                                CommandArgument="<%#: Item.User.UserName %>" OnCommand="ImageButtonViewProfile_Command"
                                CssClass="linkButtons img-rounded" ToolTip="<%#: Item.User.UserName %>" />
                        </ItemTemplate>
                    </asp:Repeater>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <asp:Button CssClass="btn btn-warning showHideBtn" Text="Show/Hide Skills Form" runat="server"
        ID="ShowHideSkillsForm" CommandName="ShowHideSkillsForm" OnCommand="ShowHideSkillsForm_Command" />

    <asp:Panel runat="server" ID="PanelAddSkill" Visible="false" CssClass="addSkillForm">
        <asp:Literal Text="Skill Name:" runat="server" />
        <asp:TextBox runat="server" ID="TextBoxSkillName" />
        <br />
        <asp:Button CssClass="btn btn-success addSkillBtn" Text="Add Skill" runat="server"
            ID="ButtonAddSkill" CommandName="AddSkill" OnCommand="ButtonAddSkill_Command" />
    </asp:Panel>
    <h2>
        <asp:Literal runat="server" ID="LiteralGroups" /></h2>
    <asp:GridView ID="GridViewGroups" runat="server" CssClass="table table-hover table-bordered"
        AutoGenerateColumns="False" SelectMethod="GridViewGroups_GetData"
        DeleteMethod="GridViewGroups_DeleteItem"
        AllowSorting="True" ItemType="DevSocialMe.Models.Group"
        DataKeyNames="GroupId" AllowPaging="True" PageSize="4">

        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Name" SortExpression="Title" />
            <asp:BoundField DataField="CreationData" HeaderText="Created Data" SortExpression="CreationData" />
            <asp:BoundField DataField="Creator" HeaderText="Creator" SortExpression="Creator" />
        </Columns>
    </asp:GridView>
</asp:Content>
