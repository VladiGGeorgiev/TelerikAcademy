<%@ Page Title="" 
    Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true"
    CodeBehind="CreateGroup.aspx.cs" 
    Inherits="DevSocialMe.CreateGroup" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <asp:TextBox runat="server"  id="NewGroupTitle" />
        <br />
        <asp:Button runat="server" ID="ButtonCreateGroup" class="btn btn-primary" Text="Create" CommandName="CreateGroup"
             OnCommand="ButtonCreateGroup_Command" />
</asp:Content>