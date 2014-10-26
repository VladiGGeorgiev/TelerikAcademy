<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllResults.aspx.cs" Inherits="ExamPreparationPollSystem.AllResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridViewAllQuestions" runat="server"
        AutoGenerateColumns="false" DataKeyNames="QuestionId"
        OnSelectedIndexChanged="GridViewAllQuestions_SelectedIndexChanged"
        AllowSorting="true"
        AllowPaging="true" PageSize="2"
        SelectMethod="GridViewAllQuestions_GetData"
        >
        <Columns>
            <asp:BoundField DataField="Text" HeaderText="Question" SortExpression="Text" />
            <asp:CommandField ShowSelectButton="true" HeaderText="Action" />
        </Columns>
    </asp:GridView>

    <asp:Repeater ID="RepeaterAllResultsAnswers"
        ItemType="ExamPreparationPollSystem.Models.Answer" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%#: Item.Text %> -> <%# Item.Votes %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
