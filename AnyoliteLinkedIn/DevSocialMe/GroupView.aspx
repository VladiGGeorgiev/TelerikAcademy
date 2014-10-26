<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupView.aspx.cs" Inherits="DevSocialMe.GroupView" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:UpdatePanel ID="UpdatePanelGroupMessages" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="AllGroupMessages">
                <asp:ListView runat="server" ID="ListViewGroupMessages" ItemType="DevSocialMe.Models.Message">
                    <ItemTemplate>
                        <div class="GroupMessage">
                        <p class="GroupMessageContent"><asp:Literal runat="server" ID="LitemMessageContent" Text="<%#: BindItem.Content %>" /></p>
                        <p class="GroupMessageDateCreated"><asp:Literal runat="server" ID="LiteralMessageDateCreated" Text="<%#: BindItem.DateCreated %>" /></p>
                        <p class="GroupMessageUserName"><asp:LinkButton runat="server" ID="ButtonViewUser" 
                            CommandArgument="<%#: BindItem.User.UserName %>" CommandName="ViewUser" OnCommand="ButtonViewUser_Command"
                             Text="<%#: BindItem.User.FullName %>" /></p>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                 </div>
                <asp:TextBox ID="NewMessage" runat="server" />
                <br />
                <asp:Button ID="AddMessage" runat="server" class="btn btn-success" Text="Send" OnClick="AddMessage_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
       
</asp:Content>