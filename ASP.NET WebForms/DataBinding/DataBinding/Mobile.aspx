<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mobile.aspx.cs" Inherits="DataBinding.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/bootstrap.css" rel="stylesheet" />
    <link href="styles/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.0.3.js"></script>
</head>
<body>
    <h1>Mobile search</h1>
    <form id="form1" runat="server">
        <asp:Label AssociatedControlID="DropDownListProducer" Text="Choose producer:" runat="server"></asp:Label>
        <asp:DropDownList 
            ID="DropDownListProducer"
            DataTextField="Name"
            DataValueField="Name"
            OnSelectedIndexChanged="DropDownListProducers_Change"
            CssClass="dropdown"
            AutoPostBack="True" 
            runat="server"/>
        <br/>
        <asp:Label runat="server" AssociatedControlID="DropDownListModel" Text="Choose model:"></asp:Label>
        <asp:DropDownList 
            ID="DropDownListModel" 
            DataTextField="Name"
            DataValueField="Name"
            CssClass="dropdown"
            AutoPostBack="True" 
            runat="server"/>
        <br/>
        <div id="extras-container">
            <asp:Label Text="Select extras:" AssociatedControlID="CheckBoxListExtras" runat="server"></asp:Label>
            <asp:CheckBoxList 
                ID="CheckBoxListExtras" 
                DataTextField="Name"
                runat="server"/>
        </div>
        <div id="engine-container">
            <asp:Label ID="Label1"  Text="Select engine:" AssociatedControlID="RadioButtonListEngines" runat="server"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonListEngines" runat="server"/>
              
        </div>
        <asp:Button ID="Submit" Text="Submit info" CssClass="btn btn-info" OnClick="Submit_Click" runat="server"/>
    </form>
    <asp:Literal ID="LiteralCollectedInfo" runat="server"></asp:Literal>
</body>
</html>
