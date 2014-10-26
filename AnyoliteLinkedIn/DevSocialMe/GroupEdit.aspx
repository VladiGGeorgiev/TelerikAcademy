<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupEdit.aspx.cs" Inherits="DevSocialMe.GroupEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="TextBoxUpdatedGroupTitle" />
    <asp:Button Text="Save" ID="EditMyGroup" class="btn btn-success" CommandName="EditGroup"
        OnCommand="EditMyGroup_Command" runat="server" />
</asp:Content>
