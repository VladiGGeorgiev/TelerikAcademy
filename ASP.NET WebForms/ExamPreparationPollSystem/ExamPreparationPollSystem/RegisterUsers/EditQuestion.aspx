<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="EditQuestion.aspx.cs" 
    Inherits="ExamPreparationPollSystem.RegisterUsers.EditQuestion" %>
<asp:Content ID="ContentEditQuestion" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit question</h1>
    
    <asp:TextBox ID="TextBoxQuestionText" runat="server" />
    <asp:LinkButton ID="LinkButtonSaveQuestion" Text="Save" runat="server"
        OnClick="LinkButtonSaveQuestion_Click" />

    <asp:Repeater ID="RepeaterAnswerResult" runat="server" 
        ItemType="ExamPreparationPollSystem.Models.Answer">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%#: Item.Text %> -> <%#: Item.Votes %>
                <a href="EditAnswer.aspx?id=<%# Item.AnswerId %>">Edit</a>
                <asp:LinkButton Text="Delete" runat="server" 
                    CommandName="Delete" CommandArgument="<%# Item.AnswerId %>"
                    OnClientClick="return confirm('Do you want to cancel?');"/>
                </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
