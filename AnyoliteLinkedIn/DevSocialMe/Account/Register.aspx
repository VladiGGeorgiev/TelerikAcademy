<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DevSocialMe.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>       
    </hgroup>
    <p class="text-error">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset class="form-horizontal">
        <legend>Create a new account.</legend>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="control-label">User name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="UserName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-error" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-error" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="FullName" CssClass="control-label">Full name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="FullName" />
               <asp:RequiredFieldValidator runat="server" ControlToValidate="FullName"
                    CssClass="text-error" ErrorMessage="The full name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="control-label">Email</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Email" AutoCompleteType="Email" />
                <asp:RegularExpressionValidator
                    id="RegularExpressionValidatorEmail"
                    runat="server" ForeColor="Red" Display="Dynamic"
                    ErrorMessage="Email address is incorrect!"
                    ControlToValidate="Email" EnableClientScript="False"
                    ValidationExpression=
                        "[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Summary" CssClass="control-label">Summary</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Summary" />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" ID="StatusLabel" CssClass="control-label" AssociatedControlID="FileUploadControl" Text="Avatar: " />
            <div class="controls">
                <asp:FileUpload ID="FileUploadControl" runat="server" />
            </div>
        </div>
        <div class="form-actions no-color">
            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn" />
        </div>
    </fieldset>

</asp:Content>
