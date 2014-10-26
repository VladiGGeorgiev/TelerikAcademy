<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SkillEdit.aspx.cs" Inherits="DevSocialMe.Admin.SkillEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox runat="server" ID="TextBoxUpdatedSkillName" />
    <asp:Button Text="Save" ID="EditMySkill" CommandName="EditSkill"
        OnCommand="EditMySkill_Command" runat="server" />
</asp:Content>
