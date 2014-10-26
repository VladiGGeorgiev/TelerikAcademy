<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupEdit.aspx.cs" Inherits="DevSocialMe.Admin.GroupEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox runat="server" ID="TextBoxUpdatedGroupTitle" />
    <asp:Button Text="Save" ID="EditMyGroup" CommandName="EditGroup"
        OnCommand="EditMyGroup_Command" runat="server" />
</asp:Content>
