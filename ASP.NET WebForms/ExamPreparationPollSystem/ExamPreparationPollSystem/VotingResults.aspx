<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VotingResults.aspx.cs" Inherits="ExamPreparationPollSystem.VotingResults" %>
<asp:Content ID="ContentVotingResults" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Voting results</h1>
    <h2>
        Question: 
        <asp:Literal ID="LiteralQuestion" runat="server" />
    </h2>
    <asp:Repeater ID="RepeaterAnswerResult" runat="server" 
        ItemType="ExamPreparationPollSystem.Models.Answer">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%#: Item.Text %> -> <%#: Item.Votes %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
