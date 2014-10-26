<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="DevSocialMe.Friends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Users: </h1>
    <asp:Repeater runat="server" ID="RepeaterUsers" ItemType="DevSocialMe.Models.ApplicationUser">
        <HeaderTemplate>
            <ul id="all-user-profiles">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <div class="full-name"><strong><%#: Item.FullName %></strong></div>
                <asp:Image class="img-rounded avatarImg" ImageUrl="<%#: Item.AvatarUrl %>" runat="server" Width="100" AlternateText="User avatar image" />
                <div class="email"><%#: Item.Email %></div>
                <a href="Profile.aspx?username=<%#: Item.UserName %>" class="btn btn-primary">View profile</a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
