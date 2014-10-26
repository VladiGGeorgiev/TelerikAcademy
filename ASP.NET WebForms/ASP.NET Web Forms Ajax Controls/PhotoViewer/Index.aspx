<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PhotoViewer.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
  
<html xmlns="http://www.w3.org/1999/xhtml" >  
<head runat="server">  
    <title>Untitled Page</title>  
    <style type="text/css">  
    </style>

</head>  
<body>  
<form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
        <h1>My Slideshow</h1>

        <asp:Image ID="Image1" runat="server" Height="250" />
        <ajaxToolkit:SlideShowExtender ID="Image1_SlideShowExtender" runat="server" 
            Enabled="True" ImageDescriptionLabelID="txtDesc"
            SlideShowServiceMethod="GetSlides" AutoPlay="true" 
            NextButtonID="btnNext" PreviousButtonID="btnPrev"
            TargetControlID="Image1">
        </ajaxToolkit:SlideShowExtender>
        <br />
        <asp:Button ID="btnPrev" runat="server" Text="<" />
        <asp:Button ID="btnNext" runat="server" Text=">" />
        <asp:Label ID="txtDesc" runat="server" Text="Label" />
    </form> 
</body>  
</html>  