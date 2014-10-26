<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExamPreparationPollSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewQuestions" runat="server"
        ItemType="ExamPreparationPollSystem.Models.Question">
        <LayoutTemplate>
            <div id="ItemPlaceholder" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <%#: Item.Text %>
                <asp:Repeater ID="RepeaterAnswers" runat="server" 
                    ItemType="ExamPreparationPollSystem.Models.Answer"
                    DataSource="<%# Item.Answers %>">
                    <HeaderTemplate>
                        <ul class="answers">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <%#: Item.Text %>
                            <asp:LinkButton ID="LinkButtonVote" Text="Vote" runat="server" 
                                CommandName="Vote" CommandArgument="<%#: Item.AnswerId %>"
                                OnCommand="LinkButtonVote_Command"/>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </li>
        </ItemTemplate>
        
    </asp:ListView>
</asp:Content>
