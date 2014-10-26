<%@ Page Title="Sum numbers page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SumNumbers.aspx.cs" Inherits="ASP.NETIntroduction.SumNumbers" %>

<asp:Content runat="server" ID="SumContent" ContentPlaceHolderID="SumContent">
    <h2>Sum two numbers</h2>
    <asp:Label runat="server" AssociatedControlID="FirstNumber" Text="First number:"></asp:Label>
    <asp:TextBox runat="server" ID="FirstNumber"></asp:TextBox> <br/>

    <asp:Label runat="server" AssociatedControlID="SecondNumber" Text="Second number:"></asp:Label>
    <asp:TextBox runat="server" ID="SecondNumber"></asp:TextBox> <br/>

    <asp:Button runat="server" Text="Sum numbers" ID="SumButton" OnClick="SumButton_Click"/><br/>

    <asp:Label runat="server" AssociatedControlID="resultSum" Text="Result:"></asp:Label>
    <asp:TextBox runat="server" ID="resultSum"></asp:TextBox>
</asp:Content>