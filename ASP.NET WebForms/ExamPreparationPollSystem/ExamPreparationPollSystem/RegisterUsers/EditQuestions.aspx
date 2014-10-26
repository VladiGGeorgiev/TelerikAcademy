<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
     AutoEventWireup="true" CodeBehind="EditQuestions.aspx.cs" 
    Inherits="ExamPreparationPollSystem.EditQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridViewQuestions" runat="server"
        AutoGenerateColumns="false" DataKeyNames="QuestionId"
        AllowSorting="true"
        ItemType="ExamPreparationPollSystem.Models.Question"
        AllowPaging="true" PageSize="2"
        SelectMethod="GridViewAllQuestions_GetData"
        DeleteMethod="GridViewQuestions_DeleteItem"
        >
        <Columns>
            <asp:BoundField DataField="Text" HeaderText="Question" SortExpression="Text" />
            <asp:HyperLinkField HeaderText="Action" Text="Edit" 
                DataNavigateUrlFields="QuestionId"
                DataNavigateUrlFormatString="EditQuestion?questionId={0}"/>
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonDeleteQuestion" 
                        Text="Delete" runat="server" 
                        CommandName="Delete"
                        CommandArgument="<%# Item.QuestionId %>"
                        OnClientClick="return confirm('Do you want to cancel?');"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <a href="EditQuestion.aspx">Create New Question</a>
</asp:Content>
