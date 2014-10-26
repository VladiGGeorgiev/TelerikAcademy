<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StudentsRegistration.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="registrationForm" runat="server">
        <asp:Label runat="server" AssociatedControlID="firstName" Text="First name: "></asp:Label>
        <asp:TextBox CssClass="input-group-sm" runat="server" ID="firstName"></asp:TextBox> <br/>
        <asp:Label ID="Label1" Text="Last name: " runat="server" AssociatedControlID="lastName"></asp:Label>
        <asp:TextBox runat="server" ID="lastName"></asp:TextBox><br/>
        <asp:Label ID="Label2" Text="Faculty number:" runat="server" AssociatedControlID="facultyNumber"></asp:Label>
        <asp:TextBox runat="server" ID="facultyNumber"></asp:TextBox><br/>
        <asp:Label ID="Label5" Text="University:" runat="server" AssociatedControlID="dropDownListUniversity"></asp:Label>
        <asp:DropDownList runat="server" ID="dropDownListUniversity">
            <asp:ListItem Value="1" Selected="True">Sofia University</asp:ListItem>
            <asp:ListItem Value="2">TU Sofia</asp:ListItem>
            <asp:ListItem Value="3">UNSS</asp:ListItem>
            <asp:ListItem Value="4">Medical University</asp:ListItem>
        </asp:DropDownList>
       <br/>
        <asp:Label ID="Label3" Text="Speciality:" runat="server" AssociatedControlID="dropDownListSpeciality"></asp:Label>
        <asp:DropDownList runat="server" ID="dropDownListSpeciality">
            <asp:ListItem Value="1" Selected="True">Computer science</asp:ListItem>
            <asp:ListItem Value="2">Psichology</asp:ListItem>
            <asp:ListItem Value="3">Physics</asp:ListItem>
            <asp:ListItem Value="4">Information Technologies</asp:ListItem>
        </asp:DropDownList>
        <br/>
        <asp:Label ID="Label4" Text="Courses: " runat="server" AssociatedControlID="listBoxCourses"></asp:Label>
        <asp:ListBox runat="server" SelectionMode="Multiple" ID="listBoxCourses">
            <asp:ListItem>Electronics</asp:ListItem>    
            <asp:ListItem>Human behaviour</asp:ListItem>    
            <asp:ListItem>Mathematics</asp:ListItem>    
            <asp:ListItem>Physics</asp:ListItem>    
        </asp:ListBox>
       <br/>
        <asp:Button runat="server" ID="Submit" Text="Submit" OnClick="Submit_Click"/>
    </form>
    <div runat="server" ID="resultInfo"></div>
</body>
</html>